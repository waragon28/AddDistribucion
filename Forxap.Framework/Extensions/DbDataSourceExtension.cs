using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM;
using System.Globalization;
using System.Reflection; 
 
namespace Forxap.Framework.Extensions
{
    public static  class DbDataSourceExtension
    {
        public static string GetString(this DBDataSource dbDataSource, string columnName, int recordNumber)
        {
            string ret = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("Columna, No puede ser nulo o vacio.");

            
            try
            {

                ret = dbDataSource.GetValue(columnName, recordNumber).Trim();
            }
            catch
            {


            }
            return ret;
        }
        public static string GetString(this DBDataSource dbDataSource, string columnName)
        {
            string ret = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 


            try
            {

                ret = dbDataSource.GetValue(columnName, 0).Trim();
            }
            catch
            {


            }
            return ret;
        }

        public static double GetDouble(this DBDataSource dbDataSource, string columnName)
        {
            double ret = 0;
            string tmp = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 

            
            try
            {
                tmp = dbDataSource.GetValue(columnName, 0);

                if (!string.IsNullOrEmpty(tmp))
                {
                    ret = Convert.ToDouble(tmp);
                }
            }
            catch
            {
            }

            return ret;
        }

        public static double GetDouble(this DBDataSource dbDataSource, string columnName ,int recordNumber )
        {
            double ret = 0;
            string tmp = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio.");


            try
            {
                tmp = dbDataSource.GetValue(columnName, recordNumber);

                if (!string.IsNullOrEmpty(tmp))
                {
                    ret = Convert.ToDouble(tmp);
                }
            }
            catch
            {
            }

            return ret;
        }


        //public static double? GetDouble(this DBDataSource source, string columnName)
        //{
        //    string sourceValue = source.GetValue(columnName, 0);
        //    if (string.IsNullOrEmpty(sourceValue))
        //    {
        //        return null;
        //    }


        //    var value = double.Parse(sourceValue, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
        //        CultureInfo.InvariantCulture);


        //    return value;
        //}

        public static int GetInt(this DBDataSource dbDataSource, string columnName)
        {
            int ret = 0;
            string tmp = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 

            try
            {
                tmp = dbDataSource.GetValue(columnName, 0);

                if (!string.IsNullOrEmpty(tmp))
                {
                    ret = Convert.ToInt32(tmp);
                }
            }
            catch
            {
            }

            return ret;
        }

        public static int GetInt(this DBDataSource dbDataSource, string columnName , int recordNumber)
        {
            int ret = 0;
            string tmp = string.Empty;

            if (dbDataSource == null)
                throw new ArgumentNullException("dbDataSource");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio.");

            try
            {
                tmp = dbDataSource.GetValue(columnName, recordNumber);

                if (!string.IsNullOrEmpty(tmp))
                {
                    ret = Convert.ToInt32(tmp);
                }
            }
            catch
            {
            }

            return ret;
        }    
     

    }// fin de la clase


}// fin del namespace
