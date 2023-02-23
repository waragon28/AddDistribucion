using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;


namespace Forxap.Framework.UI
{
    public  class Sb1Messages : Base
    {
        public static void ShowError(SAPbouiCOM.Application application, string message )
        {
            application.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        }

        public static void ShowError(string message)
        {
            oApplication.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        }

        public static void ShowError(string message, SAPbouiCOM.BoMessageTime messageTime)
        {
            oApplication.StatusBar.SetText(message, messageTime, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        }

        //public static void ShowError(string message, SAPbouiCOM.BoMessageTime boMessageTime)
        //{
        //    oApplication.StatusBar.SetText(message, boMessageTime, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //}

        public static void Clear(SAPbouiCOM.Application application, string message)
        {
            application.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_None);
                
        }


        //}

        public static void ShowProgresBar(string message)
        {
            oApplication.StatusBar.CreateProgressBar(message, 1, true);

        }

        public static void ShowWarning(SAPbouiCOM.Application application, string message)
        {
            application.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        }

        public static void Clear()
        {
            oApplication.StatusBar.SetText(string.Empty, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_None);
        }

        public static void ShowWarning( string message)
        {
            oApplication.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        }

        public static void ShowWarning(string message, SAPbouiCOM.BoMessageTime boMessageTime)
        {
            oApplication.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        }

        public static void ShowSuccess(SAPbouiCOM.Application application, string message)
        {
            application.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        }

        public static void ShowSuccess( string message)
        {
            oApplication.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        }
        public static void ShowSuccess(string message, SAPbouiCOM.BoMessageTime boMessageTime)
        {
            oApplication.StatusBar.SetText(message, boMessageTime, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        }

        public static void ShowMessage(SAPbouiCOM.Application application, string message)
        {
            application.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_None);
        }

        public static void ShowMessage(string message)
        {
            oApplication.StatusBar.SetText(message, SAPbouiCOM.BoMessageTime.bmt_Medium, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        }

        public static void ShowMessage(string message, SAPbouiCOM.BoMessageTime boMessageTime)
        {
            oApplication.StatusBar.SetText(message, boMessageTime, SAPbouiCOM.BoStatusBarMessageType.smt_None);
        }

        public static bool ShowMessageBox(SAPbouiCOM.Application oApplication, SAPbobsCOM.Company oCompany, int returnCode, string errorDescription = "Error")
        {
            if (returnCode == 0)
                return true;

            //   var error = GetLastErrorMessage(oCompany);
            var errorMessage = "{errorDescription}: {error.Code} {error.Message}";
            oApplication.StatusBar.SetText(errorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            oApplication.MessageBox(errorMessage);


            return false;
        }

        public static bool ShowQuestion(string message)
        {
            bool ret = false;
            int res = 0;
            res = oApplication.MessageBox(message, 1, "Si", "No");

            if (res == 1)
                ret = true; 

            return ret;
        }

        public static int ShowMessageBox( string message)
        {
            int ret = 0;

           ret =   oApplication.MessageBox(message, 1, "Si", "No", "Cancelar");

            return ret;
        }

        public static int ShowMessageBoxWarning(string message)
        {
            int ret = 0;

            ret = oApplication.MessageBox(message, 1, "Aceptar");

            return ret;
        }

        public static bool ShowMessageBox( int returnCode, string errorDescription = "Error")
        {
            if (returnCode == 0)
                return true;

          //     var error =  GetLastErrorMessage(oCompany);
            var errorMessage = "{errorDescription}: {error.Code} {error.Message}";
            oApplication.StatusBar.SetText(errorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            oApplication.MessageBox(errorMessage);


            return false;
        }





        //public static void SendMessage(string subject, string text, string userCode, int? docNum = null, BoObjectTypes? boObjectTypes = null)
        //{
        //   CompanyService  oCompanyService = oCompany.GetCompanyService();
        //   MessagesService  oMessageService = oCompanyService.GetBusinessService(ServiceTypes.MessagesService) as MessagesService;

        //    var oMessage = oMessageService.GetDataInterface(MessagesServiceDataInterfaces.msdiMessage) as Message;
        //    try
        //    {
        //        oMessage.Subject = subject;
        //        oMessage.Text = text;
        //        oMessage.RecipientCollection.Add();
        //        oMessage.RecipientCollection.Item(0).SendInternal = BoYesNoEnum.tYES;
        //        oMessage.RecipientCollection.Item(0).UserCode = userCode;

                

        //        if (docNum.HasValue && boObjectTypes.HasValue)
        //        {
        //            //var docEntry = docNum.Value.GetDocEntry("ORDR");
        //            var docEntry = null;
        //            if (docEntry.HasValue)
        //            {
        //                var column1 = oMessage.MessageDataColumns.Add();
        //                column1.ColumnName = "Document";
        //                column1.Link = BoYesNoEnum.tYES;

        //                var line1 = column1.MessageDataLines.Add();
        //                line1.Value = docNum.ToString();
        //                line1.ObjectKey = docEntry.Value.ToString();
        //                line1.Object = ((int)boObjectTypes.Value).ToString();
        //            }
        //        }

        //        oMessageService.SendMessage(oMessage);
        //    }
        //    catch (Exception e)
        //    {
        //     //  SboApp.Logger.Error("SendMessage Error", e);
        //        throw;
        //    }
        //    finally
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oMessage);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oMessageService);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompanyService);
        //    }
        //}


    }// fin de la clase

}// fin del namespace
