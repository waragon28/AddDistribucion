using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forxap.Framework;
using System.Net;
using System.IO;
using System.Configuration;

namespace Forxap.Framework.ServiceLayer
{
    public class Sb1Initialize : Base
    {
     
        /// <summary>
        ///  seteo el framework
        /// </summary>
        /// <param name="application"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public static bool SetFrameworkServiceLayer(SAPbouiCOM.Application application, SAPbobsCOM.Company company)
        {
            bool ret = false;
            try
            {
                oApplication  = application;
                bobsCompany  =  company;

             //   Globals.AddonClient = addonType;

                //seteo la UrlServiceLayer
                string serviceLayerAddress = string.Empty;

                

                serviceLayerAddress = ConfigurationSettings.AppSettings["UrlServiceLayer"];

                // Paso 1

                // obtengo los parametros de conexión si estan corriendo desde un addon de SAP
                Globals.ConnectionContexSAP =   application.Company.GetServiceLayerConnectionContext(serviceLayerAddress);

               

            //    Globals.SessionId = 


                //Paso 2:
                try
                {
                    var request = WebRequest.Create(serviceLayerAddress + "Items?$top=1") as HttpWebRequest;
                    request.AllowAutoRedirect = false;
                    request.Timeout = 30 * 1000;
                    request.ServicePoint.Expect100Continue = false;
                    request.CookieContainer = new CookieContainer();
                    ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

                 
                    string[] cookieItems = Globals.ConnectionContexSAP.Split(';');
                    foreach (var cookieItem in cookieItems)
                    {
                        string[] parts = cookieItem.Split('=');
                        if (parts.Length == 2)
                        {
                            request.CookieContainer.Add(request.RequestUri, new Cookie(parts[0].Trim(), parts[1].Trim()));
                        }
                    }
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                      Forxap.Framework.UI.Sb1Messages.ShowError("Error al obtener un Producto");
                      
                    }
                    string responseContent = null;
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                    Forxap.Framework.UI.Sb1Messages.ShowMessageBox(responseContent);
                }
                catch (System.Exception )
                {
                   // SBO_Application.MessageBox(ex.ToString(), 1, "Err", "", "");
                }


                ret = true;
            }
            catch (Exception ex)        /// <summary>
            {

                throw ex;
            }
            ;

            return ret;
        }

        public static bool SetFramework(SAPbouiCOM.Application application, SAPbobsCOM.Company company)
        {
            bool ret = false;
            string serviceLayerAddress = string.Empty;
            string[] credenciales;
            string[] sessions;

            try
            {
                serviceLayerAddress = ConfigurationSettings.AppSettings["UrlServiceLayer"];

                // obtengo los parametros de conexión si estan corriendo desde un addon de SAP
                Globals.ConnectionContexSAP = application.Company.GetServiceLayerConnectionContext(serviceLayerAddress);

                Globals.Application = application;
                

                

                credenciales = Globals.ConnectionContexSAP.Split(';');
                sessions = credenciales[0].ToString().Split('=');

                Globals.SessionId = sessions[1]; // obtiene la sessionID del SAP
                Globals.AddonClient = AddonType.SAP;


                //oCompany = company;
                ret = true;
            }
            catch (Exception ex)        /// <summary>
            {

                throw ex;
            }
            ;

            return ret;
        }



        private int PlayServiceLayer()
        {
            string serviceLayerAddress = "https://hanaserver:50000/b1s/v1";
            string sConnectionContext = null;

            //Paso 1: Obtengo desde el cookie la Session del Service Layer 
            try
            {
                sConnectionContext = oApplication.Company.GetServiceLayerConnectionContext(serviceLayerAddress);
            }
            catch (System.Exception ex)
            {
              //  continue;
            }

            if (sConnectionContext == null)
            {
                Forxap.Framework.UI.Sb1Messages.ShowMessageBox("Error al obtener credeneciales del Service Layer");
                return -1;
            }
            //Paso 2: Envío la solicitud con la session obtenida desde el cookie
            try
            {
                var request = WebRequest.Create(serviceLayerAddress + "/Items?$top=1") as HttpWebRequest;
                request.AllowAutoRedirect = false;
                request.Timeout = 30 * 1000;
                request.ServicePoint.Expect100Continue = false;
                request.CookieContainer = new CookieContainer();
                ServicePointManager.ServerCertificateValidationCallback +=  delegate { return true; }; 
                string[] cookieItems = sConnectionContext.Split(';');

                foreach (var cookieItem in cookieItems)
                {
                    string[] parts = cookieItem.Split('=');
                    if (parts.Length == 2)
                    {
                        request.CookieContainer.Add(request.RequestUri, new Cookie(parts[0].Trim(), parts[1].Trim()));
                    }
                }


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                  Forxap.Framework.UI.Sb1Messages.ShowMessageBox("Get item error");
                    return -1;
                }
                string responseContent = null;
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseContent = reader.ReadToEnd();
                }
               Forxap.Framework.UI.Sb1Messages.ShowMessageBox(responseContent);
            }
            catch (System.Exception ex)
            {
              Forxap.Framework.UI.Sb1Messages.ShowMessageBox(ex.ToString());
            }
            return 0;
        }


    }// fin de la clase


}// fin del namespace
