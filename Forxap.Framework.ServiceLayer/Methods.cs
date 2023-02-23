using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;



namespace Forxap.Framework.ServiceLayer
{
    public  class Methods : Base
    {



            /// <summary>
        /// Obtiene un conjunto de datos ejemplo un query con los proveedores, clientes etc
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="objectKey"></param>
        /// <returns></returns>
        public IRestResponse GET(string endPoint, string objectKey)
        {
            dynamic json;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string absoluteURI;



            if (objectKey != string.Empty)
            {
                
                absoluteURI = string.Format("{0}{1}({2})", UrlServiceLayer, endPoint, objectKey);
            }
            else
            {
                absoluteURI =  UrlServiceLayer + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.GET);

         
                Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();
                // abro la conexión
                conection.Connect();
          

            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddCookie("B1SESSION", Forxap.Framework.ServiceLayer.Globals.SessionId);
            request.AddCookie("ROUTEID", ".node0");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            string code = string.Empty;

            code = response.StatusCode.ToString();

            if (!(response.StatusCode.ToString() == SLResources.CREATED || response.StatusCode.ToString() == SLResources.OK))
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());

                    if (json != null)
                    {
                        this.ErrorCode = json["error"]["code"].ToString();
                        this.ErrorMessage = json["error"]["message"]["value"].ToString();

                        this.ActionSuccess = false;
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

                    this.ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            //            return json;





            return response;
        }// fin del metodo GET





        /// <summary>
        /// Agregar un nuevo registro a un objeto de sap (Socio de negocio, items, etc etc)
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public IRestResponse POST(string endPoint, string body)
        {
            // Paso 1 , debo verificar si estan invocando desde un Addon dentro de SAP o desde  un aplicativo externo


            dynamic json;
     
            reintentar:

            var client = new RestClient(UrlServiceLayer + endPoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            if (Globals.AddonClient == AddonType.API)
            {


            }

            Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();

                // abro la conexión
                conection.Connect();


            //   request.AddCookie(B1Session, Globals.SessionId);
            ///  request.AddCookie(RoutedId, Node0);
            client.Proxy = WebRequest.GetSystemWebProxy();
           // request.AddParameter(SLResources.CONTENTTYPE, body, ParameterType.RequestBody);

            request.AddCookie("B1SESSION", Forxap.Framework.ServiceLayer.Globals.SessionId);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", (object)body, ParameterType.RequestBody);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (!(response.StatusCode.ToString() == SLResources.CREATED || response.StatusCode.ToString() == SLResources.OK))
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    this.ErrorCode = json["error"]["code"].ToString();
                    this.ErrorMessage = json["error"]["message"]["value"].ToString();

                    this.ActionSuccess = false;


                    if (this.ErrorCode == "301")
                    {
                        // obtengo un nuevo sessionID 

                        Globals.ConnectionContexSAP = Globals.Application.Company.GetServiceLayerConnectionContext(UrlServiceLayer);
                        string[] credenciales;
                        string[] sessions;


                        credenciales = Globals.ConnectionContexSAP.Split(';');
                        sessions = credenciales[0].ToString().Split('=');

                        Globals.SessionId = sessions[1]; // obtiene la sessionID del SAP

                        // ahora debo intentar nuevamente intentar el envio al servicelayer

                        goto reintentar;

                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            

            // cierro la conexión si no se encuentran en un Addon de SAP
            if (Globals.AddonClient != AddonType.SAP)
            {
                // cierro la conexión
                conection.Disconnect();
            }
            return response;

        }// fin del metodo POST


        // enviar directo el endpoint ejemplo para cerrar, cancelar un documento
        public IRestResponse POST(string endPoint)
        {
            // Paso 1 , debo verificar si estan invocando desde un Addon dentro de SAP o desde  un aplicativo externo


            dynamic json;

            var client = new RestClient(UrlServiceLayer + endPoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();


            // si el addon esta dentro de SAP debo tomar la sessionID de SAP para ganar velocidad
            //if (Globals.AddonClient != AddonType.SAP)
            //{

                // abro la conexión
                conection.Connect();
            //}



            //Paso 2:
            try
            {
                //var request = WebRequest.Create(serviceLayerAddress + "Items?$top=1") as HttpWebRequest;
                //request.AllowAutoRedirect = false;
                //request.Timeout = 30 * 1000;
                //request.ServicePoint.Expect100Continue = false;
                //request.CookieContainer = new CookieContainer();
                //ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };


                //string[] cookieItems = Globals.ConnectionContexSAP.Split(';');
                //foreach (var cookieItem in cookieItems)
                //{
                //    string[] parts = cookieItem.Split('=');
                //    if (parts.Length == 2)
                //    {
                //        request.CookieContainer.Add(request.RequestUri, new Cookie(parts[0].Trim(), parts[1].Trim()));
                //    }
                //}
                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //if (response.StatusCode != HttpStatusCode.OK)
                //{
                //    Vistony.Framework.UI.Sb1Messages.ShowError("Error al obtener un Producto");

                //}


            }
            catch (System.Exception ex)
            {
                // SBO_Application.MessageBox(ex.ToString(), 1, "Err", "", "");
            }



            //   request.AddCookie(B1Session, Globals.SessionId);
            ///  request.AddCookie(RoutedId, Node0);
            client.Proxy = WebRequest.GetSystemWebProxy();
            // request.AddParameter(SLResources.CONTENTTYPE, body, ParameterType.RequestBody);

            request.AddCookie("B1SESSION", Forxap.Framework.ServiceLayer.Globals.SessionId);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            //    request.AddParameter("undefined", (object)body, ParameterType.RequestBody);


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (!(response.StatusCode.ToString() == SLResources.CREATED || response.StatusCode.ToString() == "NoContent" || response.StatusCode.ToString() == SLResources.OK))
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    this.ErrorCode = json["error"]["code"].ToString();
                    this.ErrorMessage = json["error"]["message"]["value"].ToString();

                    this.ActionSuccess = false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


            // cierro la conexión
            conection.Disconnect();


            return response;

        }// fin del metodo POST


        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="body"></param>
        /// <param name="newObjectKey">retorna el ID del objeto creado</param>
        /// <param name="sb1error">retorna un objeto con el codigo y mensaje de error</param>
        /// <returns></returns>

        //public IRestResponse POST(string endPoint, string body, ref string newObjectKey, ref Forxap.Framework.Utils.Sb1Error sb1error )
        //{
        //    // Paso 1 , debo verificar si estan invocando desde un Addon dentro de SAP o desde  un aplicativo externo


        //    dynamic json;

        //    var client = new RestClient(UrlServiceLayer + endPoint);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);


        //    Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();

        //    // abro la conexión
        //    conection.Connect();



        //    //   request.AddCookie(B1Session, Globals.SessionId);
        //    ///  request.AddCookie(RoutedId, Node0);
        //    client.Proxy = WebRequest.GetSystemWebProxy();
        //    // request.AddParameter(SLResources.CONTENTTYPE, body, ParameterType.RequestBody);

        //    request.AddCookie("B1SESSION", Forxap.Framework.ServiceLayer.Globals.SessionId);
        //    request.AddHeader("Cache-Control", "no-cache");
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("undefined", (object)body, ParameterType.RequestBody);


        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        //    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        //    IRestResponse response = client.Execute(request);

        //    if (!(response.StatusCode.ToString() == SLResources.CREATED || response.StatusCode.ToString() == SLResources.OK))
        //    {
        //        try
        //        {
        //            json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
        //            //json = js.DeserializeObject(response.Content.ToString());
        //            this.ErrorCode = json["error"]["code"].ToString();
        //            this.ErrorMessage = json["error"]["message"]["value"].ToString();

        //            sb1error.Code = Convert.ToInt32(ErrorCode.Trim());
        //            sb1error.Message = ErrorMessage;

        //            this.ActionSuccess = false;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            /*Se lee el Json y se retorna al controlador para ser formateado y leido*/
        //            json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

        //            this.ActionSuccess = true;
        //            try
        //            {
        //                switch (endPoint)
        //                {
        //                    case "Items":
        //                        newObjectKey = json["ItemCode"].ToString();
        //                        break;
        //                    case "BusinessPartners":
        //                        newObjectKey = json["CardCode"].ToString();
        //                        break;
        //                    case "BinLocations":
        //                        newObjectKey = json["BinCode"].ToString();
        //                        break;
        //                    case "Warehouses":
        //                        newObjectKey = json["WarehouseCode"].ToString();
        //                        break;

        //                    case "OIGN":
        //                        newObjectKey = json["DocNum"].ToString();
        //                        break;


        //                    default:
        //                        newObjectKey = json["DocEntry"].ToString();
        //                        break;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }

        //    // cierro la conexión
        //    conection.Disconnect();


        //    return response;

        //}// fin del metodo POST



        /// <summary>
        /// Actualiza un objeto de SAP
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="objectKey"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public IRestResponse PATCH(string endPoint, int? objectKey, string body)
        {
            dynamic jsonResponse;

            reintentar:

            Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();

            // abro la conexión
            conection.Connect();

            string absoluteURI = string.Empty;

            if (objectKey !=0) 
            {
                absoluteURI = string.Format("{0}{1}({2})", UrlServiceLayer, endPoint, objectKey);
            }
            else
            {
                absoluteURI = UrlServiceLayer + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.PATCH);
            request.AddCookie("B1SESSION", Globals.SessionId);
            request.AddCookie("ROUTEID", ".node0");
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            //request.AddParameter("undefined", (object)body, ParameterType.RequestBody);



            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            string code = string.Empty;

            code = response.StatusCode.ToString();

            if (response.StatusCode.ToString() != "NoContent")
            {
                try
                {
                    jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //      json = js.DeserializeObject(response.Content.ToString());
                    this.ErrorCode = jsonResponse["error"]["code"].ToString();
                    this.ErrorMessage = jsonResponse["error"]["message"]["value"].ToString();

                    // si hubo un error de timeOut debo volver a obtener el sessionID
                    if (this.ErrorCode == "301")
                    {
                        // obtengo un nuevo sessionID 

                        Globals.ConnectionContexSAP = Globals.Application.Company.GetServiceLayerConnectionContext(UrlServiceLayer);
                        string[] credenciales;
                        string[] sessions;


                        credenciales = Globals.ConnectionContexSAP.Split(';');
                        sessions = credenciales[0].ToString().Split('=');

                        Globals.SessionId = sessions[1]; // obtiene la sessionID del SAP

                        // ahora debo intentar nuevamente intentar el envio al servicelayer

                        goto reintentar;

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
                    //   jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    this.ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            if (Globals.AddonClient != AddonType.SAP)
            {
                // cierro la conexión
                conection.Disconnect();
            }
            return response;
        }// fin del metodo PATCH



        /// <summary>
        /// Actualiza un objeto de SAP mientras su KEY sea una cadena
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="objectKey"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public IRestResponse PATCH(string endPoint, string objectKey, string body)
        {
            dynamic jsonResponse;

            reintentar:
            Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();

            // abro la conexión
            conection.Connect();

            string absoluteURI = string.Empty;

            if (objectKey != string.Empty)
            {
                absoluteURI =string.Format("{0}{1}('{2}')",UrlServiceLayer,endPoint,objectKey );
            }
            else
            {
                absoluteURI =  UrlServiceLayer + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.PATCH);
            request.AddCookie("B1SESSION", Globals.SessionId);
            request.AddCookie("ROUTEID",".node0");
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            //request.AddParameter("undefined", (object)body, ParameterType.RequestBody);



            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            string code = string.Empty;

            code = response.StatusCode.ToString();

            if (response.StatusCode.ToString() != "NoContent")
            {
                try
                {
                    jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
              //      json = js.DeserializeObject(response.Content.ToString());
                   this.ErrorCode = jsonResponse["error"]["code"].ToString();
                   this.ErrorMessage = jsonResponse["error"]["message"]["value"].ToString();

                    if (this.ErrorCode == "301")
                    {
                        // obtengo un nuevo sessionID 

                        Globals.ConnectionContexSAP = Globals.Application.Company.GetServiceLayerConnectionContext(UrlServiceLayer);
                        string[] credenciales;
                        string[] sessions;


                        credenciales = Globals.ConnectionContexSAP.Split(';');
                        sessions = credenciales[0].ToString().Split('=');

                        Globals.SessionId = sessions[1]; // obtiene la sessionID del SAP

                        // ahora debo intentar nuevamente intentar el envio al servicelayer

                        goto reintentar;

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
                 //   jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    this.ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            // cierro la conexión
            if (Globals.AddonClient != AddonType.SAP)
            {
                // cierro la conexión
                conection.Disconnect();
            }
            return response;
        }// fin del metodo PATCH




        public dynamic DELETE(string endPoint, string objectKey)
        {
            dynamic json;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string absoluteURI;

            if (objectKey != string.Empty)
            {
                absoluteURI = string.Format("{0}{1}{2}{(3)} ", BaseUri, UrlServiceLayer, endPoint, objectKey);
            }
            else
            {
                absoluteURI = BaseUri + UrlServiceLayer + endPoint;
            }

            var client = new RestClient(absoluteURI);

            var request = new RestRequest(Method.DELETE);
            client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
            request.AddCookie(SLResources.B1SESSION, Globals.SessionId);
            request.AddCookie(SLResources.ROUTEID,SLResources.NOBE0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() != SLResources.NOCONTENT)
            {
                try
                {
                    json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());
                    //json = js.DeserializeObject(response.Content.ToString());
                    this.ErrorCode = json["error"]["code"].ToString();
                    this.ErrorMessage  = json["error"]["message"]["value"].ToString();

                    this.ActionSuccess  = false;
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

                    this.ActionSuccess = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return json;
        }// fin del



    }// fin de la clase

}// fin del namespace
