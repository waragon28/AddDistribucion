using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework
{
    public class Sb1Initialize : Base
    {

        /// <summary>
        ///  seteo el framework
        /// </summary>
        /// <param name="application"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public static bool SetFramework(SAPbouiCOM.Application application, SAPbobsCOM.Company company)
        {
            bool ret = false;
            try
            {
              
                oApplication = application;
                oCompany = company;
                ret = true;
            }
            catch (Exception ex)        /// <summary>
            {

                throw ex;
            }
            ;

            return ret;
        }

        public static bool SetFramework( SAPbobsCOM.Company company)
        {
            bool ret = false;
            try
            {
                
                oCompany = company;
                ret = true;
            }
            catch (Exception ex)        /// <summary>
            {

                throw ex;
            }
            ;

            return ret;
        }           
                
     



    }// fin de la clase
}// fin del namespace
