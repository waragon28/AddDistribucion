//using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Forxap.Framework.ServiceLayer;

namespace Forxap.FrameWork
{

  
    public  class ServiceLayer : BaseSL
    {
        public static bool ActionSuccess { get; set; }
        public static string ErrorCode { get; set; }
        public static string ErrorMessage { get; set; }


        
        
        /// <summary>
        /// Realiza la conexion al Service Layer
        /// </summary>
        /// <param name="companyDB"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static  bool Connect(string companyDB, string userName, string password)
        {
            dynamic json;
            /*Asignamos los valores a la clase para mantenerlos*/

            Globals.SetCredentials(companyDB, userName, password);


            var client = new RestClient(BaseUri + AbsolutUriPrefix  + Login);

            var request = new RestRequest(Method.POST);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();

            var jsonCredentials = new
            {
                CompanyDB = Globals.CompanyDB, // ASIGNO A QUE BASE DE DATOS SE VA CONECTAR
                UserName = Globals.UserName, // ASIGNO EL USUARIO DEL SERVICE LAYER
                Password = Globals.Password,  // ASIGNO EL PASSWORD DEL USUARIO QUE SE LOGEA AL SERVICE LAYER
              
            };


            request.AddParameter(ContentType, JsonConvert.SerializeObject( jsonCredentials) , ParameterType.RequestBody);
          
         //   request.AddParameter(ContentType, "{\"CompanyDB\":\"" + Globals.CompanyDB + "\",\"UserName\":\"" + Globals.UserName + "\",\"Password\":\"" + Globals.Password + "\"}", ParameterType.RequestBody);
          
                                    

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() !=  ResourceSL.OK)
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    if (json != null)
                    {
                        ErrorCode = json.error.code.ToString();
                        ErrorMessage = json.error.message.ToString();
                        Globals.IsConnected = false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    // si la conexión se realizo de manera correcta 

                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
         
                    // envio los valores de las credenciales y los guardo como variables globables
                    Globals.SetSessionsValues(json); 
                    
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            }



            return Globals.IsConnected;
        }// fin del metodo Connect


        /// <summary>
        /// Desconecta del service layer
        /// </summary>
        /// <returns></returns>
        public static bool Disconnect()
        {
            dynamic json;

            var client = new RestClient(BaseUri + AbsolutUriPrefix +  ResourceSL.LOGOUT);

            var request = new RestRequest(Method.POST);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddCookie(ResourceSL.B1SESSION, Globals.SessionId);
            request.AddCookie(ResourceSL.ROUTEID,ResourceSL.NODE0);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != NoContent)
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    ErrorCode = json.error.code.ToString();
                    ErrorMessage = json.error.message.ToString();

                    Globals.IsConnected = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    Globals.IsConnected = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return true;
        }


        /// <summary>
        /// Obtiene un conjunto de datos ejemplo un query con los proveedores, clientes,items, etc
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="key"> el ID del objeto que seas obtener</param>
        /// <param name="criterion"> filtro, o nombre de campos que seas obtener</param>
        /// <returns></returns>
        public static  dynamic GET(string endPoint, string key = null, string criterion = null)
        {
            dynamic json;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string absoluteURI;

            if (key.Length > 2)
            {
                absoluteURI = BaseUri + AbsolutUriPrefix + endPoint + "(" + key + ")";
            }
            else
            {
                absoluteURI = BaseUri  + AbsolutUriPrefix  + endPoint;
            }

            if (criterion != null)
            {
                absoluteURI += "?$" + criterion;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.GET);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddCookie(ResourceSL.B1SESSION, Globals.SessionId);
            request.AddCookie(ResourceSL.ROUTEID,  ResourceSL.NODE0);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != ResourceSL.OK)
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());

                    if (json != null)
                    {
                        ErrorCode = json["error"]["code"].ToString();
                        ErrorMessage = json["error"]["message"]["value"].ToString();

                        ActionSuccess = false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    /*Se lee el Json y se retorna al controlador para ser formateado y leido*/
                    //json = js.DeserializeObject(response.Content.ToString());
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                     ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return json;
        }



        /// <summary>
        /// Agregar un nuevo registro a un objeto de sap (Socio de negocio, items, etc etc)
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static dynamic POST(string endPoint, string body)
        {
            dynamic json;
            //JavaScriptSerializer js = new JavaScriptSerializer();

            var client = new RestClient(BaseUri  + AbsolutUriPrefix +  endPoint);

            var request = new RestRequest(Method.POST);
            request.AddCookie(B1Session, Globals.SessionId);
            request.AddCookie(RoutedId, Node0);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddParameter(ResourceSL.CONTENTTYPE, body, ParameterType.RequestBody);
            


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (!(response.StatusCode.ToString() == ResourceSL.CREATED || response.StatusCode.ToString() == ResourceSL.OK))
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    ErrorCode = json["error"]["code"].ToString();
                    ErrorMessage = json["error"]["message"]["value"].ToString();

                    ActionSuccess = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    /*Se lee el Json y se retorna al controlador para ser formateado y leido*/
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    ActionSuccess = true;
                    try
                    {
                        switch (endPoint)
                        {
                            case "Items":
                            //    NewObjectKey = json["ItemCode"].ToString();
                                break;
                            case "BusinessPartners":
                            //    NewObjectKey = json["CardCode"].ToString();
                                break;
                            case "BinLocations":
                             //   NewObjectKey = json["BinCode"].ToString();
                                break;
                            case "Warehouses":
                             //   NewObjectKey = json["WarehouseCode"].ToString();
                                break;
                            default:
                             //   NewObjectKey = json["DocEntry"].ToString();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return json;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="key"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static dynamic PATCH(string endPoint, string key, dynamic body)
        {
            dynamic jsonResponse;
            string absoluteURI = string.Empty;

            if (key != string.Empty)
            {
                absoluteURI = BaseUri + AbsolutUriPrefix + endPoint + "(" + key + ")";
            }
            else
            {
                absoluteURI = BaseUri +  AbsolutUriPrefix  + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.PATCH);


            request.AddCookie(B1Session, Globals.SessionId);
            request.AddCookie(RoutedId, Node0);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddParameter(ContentType, body, ParameterType.RequestBody);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != NoContent)
            {
                try
                {
                    jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    ErrorCode = jsonResponse["error"]["code"].ToString();
                    ErrorMessage = jsonResponse["error"]["message"]["value"].ToString();

                    //this.actionSuccess = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    /*Se lee el Json y se retorna al controlador para ser formateado y leido*/
                    //json = js.DeserializeObject(response.Content.ToString());
                    jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return jsonResponse;
        }




        public static dynamic DELETE(string endPoint, string key)
        {
            dynamic json;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string absoluteURI;

            if (key != "")
            {
                absoluteURI = BaseUri + AbsolutUriPrefix + endPoint  + "(" + key + ")";
            }
            else
            {
                absoluteURI = BaseUri + AbsolutUriPrefix + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.DELETE);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddCookie(B1Session, Globals.SessionId);
            request.AddCookie(RoutedId, Node0);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != NoContent)
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    ErrorCode = json["error"]["code"].ToString();
                    ErrorMessage  = json["error"]["message"]["value"].ToString();

                    ActionSuccess = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    /*Se lee el Json y se retorna al controlador para ser formateado y leido*/
                    //json = js.DeserializeObject(response.Content.ToString());
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return json;
        }



    }// fin de la clase



}// fin del namespace
