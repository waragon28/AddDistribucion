using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forxap.Framework.ServiceLayer
{
    public class Connection : Base
    {



        public IRestResponse Connect()
        {
            dynamic json;
            /*Asignamos los valores a las variables globales para mantenerlos*/
            string url = string.Empty;

            url = UrlServiceLayer;
            IRestResponse response = null;

             Globals.CompanyName = CompanyName; 
             Globals.UserName = UserName;

             Globals.UserPassword = UserPassword;
             Globals.UrlServiceLayer = UrlServiceLayer;


            // si la variable global no tiene el sesionID entonces lo obtengo desde el company
            if (Globals.ConnectionContexSAP.Length == 0)
            {
                Globals.ConnectionContexSAP = Globals.Application.Company.GetServiceLayerConnectionContext(UrlServiceLayer);
            }
            string[] credenciales;
            string[] sessions;


            credenciales = Globals.ConnectionContexSAP.Split(';');
            sessions = credenciales[0].ToString().Split('=');

            Globals.SessionId = sessions[1]; // obtiene la sessionID del SAP
            Globals.AddonClient = AddonType.SAP;


            if (string.IsNullOrEmpty(Globals.SessionId))
            {
                var client = new RestClient(Globals.UrlServiceLayer + "Login");

                var request = new RestRequest(Method.POST);
                client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
                request.AddParameter
                    (
                    "application/json; charset=utf-8",
                    "{\"CompanyDB\":\"" + Globals.CompanyName + "\",\"UserName\":\"" + Globals.UserName + "\",\"Password\":\"" + Globals.UserPassword + "\"}",
                    ParameterType.RequestBody
                    );


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = client.Execute(request);

                if (response.StatusCode.ToString() != SLResources.OK)
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
                        json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());


                        Globals.SessionId = json.SessionId.ToString();
                        Globals.Version = json.Version.ToString();
                        Globals.SessionTimeout = json.SessionTimeout.ToString();


                        Globals.IsConnected = true;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

            }

            return response;
        } // fin del metodo Connect


        public bool Disconnect()
        {
            dynamic json;

            var client = new RestClient(string.Format("{0}{1}{2}", BaseUri,UrlServiceLayer, SLResources.LOGOUT));

            var request = new RestRequest(Method.POST);
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
                    ErrorCode = json.error.code.ToString();
                    ErrorMessage = json.error.message.ToString();

                    Globals.IsConnected= false;
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



    }// fin de la clase

}// fin del namespace
