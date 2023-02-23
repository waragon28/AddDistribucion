using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;
using Forxap.Framework.Utils;
using Vistony.Distribucion.Constans;

namespace Vistony.Distribucion.Win
{
    class Program
    {
        //  public static SAPbouiCOM.Form oForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AddonMessageInfo addonMessageInfo = new AddonMessageInfo();

            try
            {
                Application oApp = null;
                
               
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    oApp = new Application(args[0]);
                }
                ApplicationEvent ApplicationEvents = new ApplicationEvent();
                SB1_MainMenuEvent MainMenuEvents = new SB1_MainMenuEvent();
                SB1_FormMenuEvent FormMenuEvents = new SB1_FormMenuEvent();
                ApplicationItemEvent ApplicationItemEvents = new ApplicationItemEvent();
                FormDataEvent FormEvents = new FormDataEvent();

                ItemEvent ItemEvents = new ItemEvent();


                /// Eventos que se ejecutan en toda la aplicación
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(ApplicationEvents.SB1_Application_AppEvent);
                /// Eventos del menu de la pantalla principal de SAP
                Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(MainMenuEvents.SB1_Application_MainMenuEvent);
                /// Eventos del menu dentro de un formulario especifico
                Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(FormMenuEvents.SB1_Application_FormMenuEvent);

                Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(FormEvents.SB1_Application_FormDataEvent);


              //  Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(ItemEvents.SB1_Application_ItemEvent);
                /// Eventos que se ejecutan en toda la aplicación 
        //        Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(ApplicationItemEvents.SB1_Application_ItemEvent);

                if (Sb1Connection.ConnectToSAP())
                {

                    oApp.Run();

                }

            }
            catch (Exception ex)
            {


                if (Errors.GetLastErrorFromHRException(ex).Code == -7202)
                    System.Windows.Forms.MessageBox.Show(addonMessageInfo.MessageIdiomaSAPNotRunning(Sb1Globals.Idioma));
                else
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }




    }// fin de la clase

}// menu del namespace
