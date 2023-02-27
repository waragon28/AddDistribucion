using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbobsCOM;

using Forxap.Framework.Utils;

namespace Forxap.Framework.DI
{
    public class Sb1Admin : Base
    {
        public static  string  GetRUC ()
        {
            string ret = string.Empty;

            AdminInfo adminInfo;

            adminInfo  = oCompany.GetCompanyService().GetAdminInfo();

            ret = adminInfo.FederalTaxID;

           

           return ret;
        }

        public static string GetLocalCurerncy()
        {
            string ret = string.Empty;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            ret = adminInfo.LocalCurrency;


            return ret;
        }

        public static string GetDateSeparator()
        {
            string ret = string.Empty;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            ret = adminInfo.DateSeparator;


            return ret;
        }

        /// <summary>
        /// Obtiene el Codigo de Impuestos que tiene seteado
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultTaxCode()
        {
            string ret = string.Empty;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();
            ret = adminInfo.DefaultTaxCode;


            return ret;
        }

        public static string GetSystemCurrency()
        {
            string ret = string.Empty;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            ret = adminInfo.SystemCurrency;

           

            return ret;
        }

        public static double GetTaxPercentage()
        {
            double ret = 0;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            ret =adminInfo.TaxPercentage;

           // CompanyInfo companyInfo;

            //PathAdmin pathAdmin = oCompany.GetCompanyService().GetPathAdmin();

           // pathAdmin.WordTemplateFolderPath

          
            


            return ret;
        }


        public static DateTime GetCompanyDate()
        {
            DateTime ret ;


            ret = oCompany.GetCompanyDate();

            return ret;

        }


        public static string GetCompanyTime()
        {
            string ret;


            ret = oCompany.GetCompanyTime();

            return ret;

            
        }   




        /// <summary>
        /// obtiene el Color que se encunetran las ventanas de SAP
        /// </summary>
        /// <returns></returns>
        public static  int GetColor()
        {
            int color = 0;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            color = adminInfo.CompanyColor;
            

            // esto funciona solo para la funcion 9.2 for Hana
            
                switch (color)
                {
                    case 1:
                        return 5633;
                    case 2:
                        return 5634;
                    case 3:
                        return 5635;
                    case 4:
                        return 5636;
                    case 5:
                        return 5637;
                    case 6:
                        return 5638;
                    case 7:
                        return 5639;
                    case 8:
                        return 5640;
                    case 9:
                        return 5641;

                    default:
                        return 5633;
                }

            return color;
        }
        

        public static string GetEmail()
        {
            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            return   adminInfo.eMail;

        }

        public static string GetBankCountry()
        {
            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            return adminInfo.BankCountry;

            
            
        }

        public static string GetCountry()
        {
            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            return adminInfo.Country;



        }



        public static string GetDefaultCountry()
        {
            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            return adminInfo.Country;


        }

        public static string GetDefaultState()
        {
            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            return adminInfo.State;

            


        }

        public static bool IsPrinterConnected()
        {
            bool ret = false;

            AdminInfo adminInfo;

            adminInfo = oCompany.GetCompanyService().GetAdminInfo();

            

           ret=  ConvertSAP.ToBoolean(adminInfo.IsPrinterConnected);

            return ret;

            

        }





    }// fin de la clase

}// fin del namespace
