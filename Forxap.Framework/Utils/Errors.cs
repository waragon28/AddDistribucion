using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Forxap.Framework.UI;

namespace Forxap.Framework.Utils
{
    public  class Errors : Base
    {


        /// <summary>
        /// Obtiene el mensaje del último error desde SB1 DI API
        /// </summary>
        /// <returns></returns>
        public static Sb1Error GetLastErrorMessage(SAPbobsCOM.Company oCompany)
        {
            int errorCode;
            string errorMessage;

            oCompany.GetLastError(out errorCode, out errorMessage);
            return new Sb1Error(oCompany.CompanyName, errorCode, errorMessage);
        }


        
        /// <summary>
        /// Obtiene el mensaje del último error desde SB1 DI API
        /// </summary>
        /// <returns></returns>
        public static Sb1Error GetLastErrorMessage()
        {
            int errorCode;
            string errorMessage;
            
            oCompany.GetLastError(out errorCode, out errorMessage);
            return new Sb1Error(errorCode, errorMessage);
        }

        public static Sb1Error GetLastErrorFromHRException(Exception exception)
        {
            int errorCode;
            string errorMessage;

            errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(exception);
            errorMessage = exception.Message;

            return new Sb1Error(errorCode, errorMessage);
        }

        public static Sb1Error GetLastErrorFromHRException(string objectName, Exception exception)
        {
            int errorCode;
            string errorMessage;

            errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(exception);
            errorMessage = string.Format("Objeto : {0}, {1} ", objectName , exception.Message);

            return new Sb1Error(errorCode, errorMessage);
        }

        
        public static Sb1Error GetLastErrorFromHRException(SAPbobsCOM.Company oCompany, Exception exception)
        {
            int errorCode;
            string errorMessage;

            errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(exception);
            errorMessage = exception.Message;

            return new Sb1Error(oCompany.CompanyName, errorCode, errorMessage);
        }


        /// <summary>
        /// Handle Return Code
        /// Throws Exception if Return Code != 0
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="errorDescription"></param>
        public static void HandleErrorWithException(SAPbobsCOM.Company oCompany, int returnCode, string errorDescription)
        {
            if (returnCode == 0)
                return;

            var error = GetLastErrorMessage(oCompany);
            throw new Exception("{errorDescription}: {error.Code} {error.Message}");
        }

        public static void HandleErrorWithException()
        {
            throw new NullReferenceException();
        }

        public static void HandleErrorWithExceptionNullCompany()
        {
            throw new NullReferenceException("Compañia es nulo");
        }

        public static void HandleErrorWithExceptionNullSBObob()
        {
            throw new NullReferenceException("SBObob es nulo");
        }
        
        public static void HandleErrorWithExceptionNullRecordSet()
        {
            throw new NullReferenceException("RecordSet es nulo");
        }

        public static void HandleErrorWithExceptionNullDataTable()
        {
            throw new NullReferenceException("DataTable es nulo");
        }

        public static void HandleErrorWithExceptionNullDbDataSource()
        {
            throw new NullReferenceException("DbDataSource es nulo");
        }

        public static void HandleErrorWithExceptionNullMatrix()
        {
            throw new NullReferenceException("Matrix es nulo");
        }



        public static void  HandleErrorWithException(SAPbobsCOM.Company oCompany, string errorDescription)
        {
          

            var error = GetLastErrorMessage(oCompany);
            throw new Exception(errorDescription);



        }

        /// <summary>
        /// para la UI
        /// </summary>
        /// <param name="oApplication"></param>
        /// <param name="oCompany"></param>
        /// <param name="returnCode"></param>
        /// <param name="errorDescription"></param>
        /// <returns></returns>
        public static bool HandleErrorWithMessageBox(SAPbouiCOM.Application oApplication, SAPbobsCOM.Company oCompany, int returnCode, string errorDescription = "Error")
        {
            if (returnCode == 0)
                return true;

            var error = GetLastErrorMessage(oCompany);
            var errorMessage = "{errorDescription}: {error.Code} {error.Message}";
            oApplication.StatusBar.SetText(errorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            oApplication.MessageBox(errorMessage);


            return false;
        }

        public static bool HandleErrorWithMessageBox( int returnCode, string errorDescription = "Error")
        {
            if (returnCode == 0)
                return true;

            var error = GetLastErrorMessage(oCompany);
            var errorMessage = "{errorDescription}: {error.Code} {error.Message}";

            Forxap.Framework.UI.Sb1Messages.ShowError(oApplication, errorMessage);

            oApplication.StatusBar.SetText(errorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            oApplication.MessageBox(errorMessage);


            return false;
        }









    }// fin de la clase


    [DebuggerDisplay("{Code}: {Message}")]
    public class Sb1Error
    {

        private int _code = 0;
        private string _message = string.Empty;

        private string _companyName = string.Empty;
        private DateTime _date;
        private string _parameter = string.Empty;

        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (_code == value)
                    return;
                _code = value;
            }
        }



        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message == value)
                    return;
                _message = value;

            }
        }



        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }



        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }



        public string Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }


        public Sb1Error()
        {

        }


        public Sb1Error(int errorCode, string errorMessage)
        {
            Code = errorCode;
            Message = errorMessage;
        }

        public Sb1Error(string companyName, int errorCode, string errorMessage)
        {
            CompanyName = companyName;
            Code = errorCode;
            Message = errorMessage;
        }

        public Sb1Error(string companyName, string parameter, int errorCode, string errorMessage)
        {
            CompanyName = companyName;
            Parameter = parameter;
            Code = errorCode;
            Message = errorMessage;
        }


    }

}// fin del namespace
