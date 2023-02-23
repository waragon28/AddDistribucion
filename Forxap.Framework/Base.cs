using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework
{
    public  class Base
    {
        private static SAPbobsCOM.Company _oCompany;
        private static SAPbouiCOM.Application _oApplication;

        private static string version = string.Empty;
        private static string fullVersion = string.Empty;
        private static string ret = string.Empty;
        public static SAPbobsCOM.Company oCompany
        {
            get { return _oCompany; }
            set { _oCompany = value; }
        }

        public static string GetDbServerType
        {
            get 
            
            {

                fullVersion = oCompany.DbServerType.ToString();

                version = fullVersion.Split('.')[0];

                
              


              switch (version)
              {
                  case "1":
                  case "small":
                      
                      break;
                  case "2":
                  case "medium":
                      
                      goto case "1";
                  case "3":
                  case "large":
                      
                      goto case "1";
                  default:
                      Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                      break;
              }


              return ret;
            
            }

        }

       

        public static SAPbouiCOM.Application oApplication
        {
            get { return _oApplication; }
            set { _oApplication = value; }
        }


       
    }// fin de la clase


}// fin del namespace
