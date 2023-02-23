using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using SAPbobsCOM;


namespace Forxap.Framework.DI.Helper
{
    public  class Database
    {

        /// <summary>
        /// Get SQL Version
        /// </summary>
        public static SqlVersion GetSqlVersion(SAPbobsCOM.Company oCompany)
        {

            Recordset recordSet = null;
            string  version;
            string  fullVersion;


            recordSet =  (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            recordSet.DoQuery("SELECT SERVERPROPERTY('productversion') as Version");
            

            fullVersion = recordSet.Fields.Item("Version").Value.ToString();
            version = fullVersion.Split('.')[0];



                switch (version)
                {
                    case "9":
                        return SqlVersion.Mssql2005;
                    case "10":
                        return SqlVersion.Mssql2008;
                    case "11":
                        return SqlVersion.Mssql2012;
                    case "12":
                        return SqlVersion.Mssql2014;
                    case "13":
                        return SqlVersion.Mssql2016;
                   
                    default:
                        return SqlVersion.Mssql;
                }
            
        }

        public enum SqlVersion
        {
            Mssql,
            Mssql2005,
            Mssql2008,
            Mssql2012,
            Mssql2014,
            Mssql2016
        }

    }// fin de la clase


}//fin del namespace
