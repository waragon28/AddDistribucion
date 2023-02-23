using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbouiCOM;


using System.Globalization; 
using System.Reflection; 
 
//    using Database.Attributes; 


namespace Forxap.Framework.Extensions
{
    public static class DbDataSourcesExtensions
    {
     

        /// <summary> 
        /// Obtiene un dateTime. 
        /// </summary> 
        /// <param name="dbDataSource">el DbDataSource.</param> 
        /// <param name="columnName">Id de la Columna.</param> 
        /// <param name="rowIndex">Indice del registro.</param> 
        /// <returns></returns> 
        public static DateTime? GetDateTime(this DBDataSource dbDataSource, string columnName, int rowIndex) 
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");

             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio.");


            
            var sourceValue = dbDataSource.GetValue(columnName, rowIndex); 
            
            if (string.IsNullOrEmpty(sourceValue)) 
             { 
                 return null; 
             } 
 
 
             var value = DateTime.ParseExact(sourceValue, "yyyyMMdd", CultureInfo.InvariantCulture); 
             return value; 
         }


        /// <summary>
        /// retorma un numero 
        /// </summary>
        /// <param name="dbDataSources"></param>
        /// <param name="datasourceName"></param>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static double GetDouble(this DBDataSources dbDataSources, string datasourceName, string columnName, int rowIndex)
        {
            double ret = 0;

            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 


            try
            {
                DBDataSource dataSource = dbDataSources.Item(datasourceName);
                ret = Convert.ToDouble(dataSource.GetValue(columnName, rowIndex));
            }
            catch
            {
            }            

            return ret;
        }

        public static void SetString(this DBDataSources dbDataSources, string datasourceName, string columnName, string value)
        {

            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(datasourceName))
                throw new ArgumentException("No puede ser nulo o vacio."); 

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 



            try
            {
                if (value != null)
                {
                    DBDataSource dataSource = dbDataSources.Item(datasourceName);
                    dataSource.SetValue(columnName, 0, value);

                    

                }
            }
            catch 
            {
                
                
            }
            
        } 

        
         /// <summary> 
         /// Obtiene un entero. 
         /// </summary> 
         /// <param name="dbDataSource">el DbDataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <returns></returns> 
         public static int? GetInt(this DBDataSource dbDataSource, string columnName, int rowIndex) 
         {

             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");

             
             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 


            string sourceValue = dbDataSource.GetValue(columnName, rowIndex); 
             
             if (string.IsNullOrEmpty(sourceValue)) 
             { 
                 return null; 
             } 
 
 
             var value = int.Parse(sourceValue, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, 
                 CultureInfo.InvariantCulture); 
 
 
             return value; 
         }

         /// <summary> 
         /// Obtiene un entero. 
         /// </summary> 
         /// <param name="dbDataSource">el DbDataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <returns></returns> 
         public static int? GetInt(this DBDataSource dbDataSource, string columnName)
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");


             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 



             string sourceValue = dbDataSource.GetValue(columnName,0);
             
             
             if (string.IsNullOrEmpty(sourceValue))
             {
                 return null;
             }


             var value = int.Parse(sourceValue, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                 CultureInfo.InvariantCulture);


             return value;
         }

         


         /// <summary> 
         /// Setear un valor a un campo int. 
         /// </summary> 
         /// <param name="dbDataSource">El DataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <param name="value">Valor del int.</param> 
         public static void SetInt(this DBDataSource dbDataSource, string columnName, int rowIndex, int? value) 
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");


             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 




             if (value != null) 
             { 
                 dbDataSource.SetValue(columnName, rowIndex, ((int) value).ToString(CultureInfo.InvariantCulture)); 
             } 
         } 



         /// <summary> 
         /// Setear un valor a un campo string. 
         /// </summary> 
         /// <param name="dbDataSource">El DataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <param name="value">Valor del string.</param> 
         public static void SetString(this DBDataSource dbDataSource, string columnName, int rowIndex, string value) 
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");


             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 




             if (value != null) 
             { 
                 dbDataSource.SetValue(columnName, rowIndex, value); 
             } 
         } 



         
         /// <summary> 
         /// Setear un valor a un campo double. 
         /// </summary> 
         /// <param name="source">El DataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <param name="value">Valor del double.</param> 
         public static void SetDouble(this DBDataSource dbDataSource, string columnName, int rowIndex, double? value) 
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");

             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 


             if (value != null) 
             {
                 dbDataSource.SetValue(columnName, rowIndex, ((double)value).ToString(CultureInfo.InvariantCulture)); 
             } 
         } 



         /// <summary> 
         /// Setear un valor a un campo fecha. 
         /// </summary> 
         /// <param name="source">El DataSource.</param> 
         /// <param name="columnName">Id de la Columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <param name="value">Valor de Fecha.</param> 
         public static void SetDateTime(this DBDataSource dbDataSource, string columnName, int rowIndex, DateTime? value) 
         {
             if (dbDataSource == null)
                 throw new ArgumentNullException("dbDataSource");

             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 


             if (value != null) 
             {
                 dbDataSource.SetValue(columnName, rowIndex, ((DateTime)value).ToString("yyyyMMdd")); 
             } 
         }




         public static int? GetInt(this DBDataSources dbDataSources, string datasourceName, string columnName, int rowIndex)
        {
            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(datasourceName))
                throw new ArgumentException("No puede ser nulo o vacio."); 

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 

             
             DBDataSource dataSource = dbDataSources.Item(datasourceName);

            return Convert.ToInt32(dataSource.GetValue(columnName, rowIndex));
        }

         public static int? GetInt(this DBDataSources dbDataSources, string datasourceName, string columnName)
         {
             int? ret = null;

             if (dbDataSources == null)
                 throw new ArgumentNullException("dbDataSources");

             if (string.IsNullOrEmpty(datasourceName))
                 throw new ArgumentException("No puede ser nulo o vacio.");

             if (string.IsNullOrEmpty(columnName))
                 throw new ArgumentException("No puede ser nulo o vacio."); 
 
             
             
             try
             {
                 DBDataSource dataSource = dbDataSources.Item(datasourceName);

                 ret = Convert.ToInt32(dataSource.GetValue(columnName, 0));
             
             }
             catch
             {
                 
             }
             
             return ret;
         }


         public static string GetString(this DBDataSources dbDataSources, string datasourceName, string columnName, int rowIndex)
        {
            string ret = string.Empty;


            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(datasourceName))
                throw new ArgumentException("No puede ser nulo o vacio.");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 
 


            try
            {
                DBDataSource dataSource = dbDataSources.Item(datasourceName);

                return dataSource.GetValue(columnName, rowIndex);

            }
            catch 
            {
            }
            


            return ret;
        }

        public static string GetString(this DBDataSources dbDataSources, string datasourceName, string columnName)
        {
            string ret = string.Empty;

            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(datasourceName))
                throw new ArgumentException("No puede ser nulo o vacio.");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio."); 
 

            try
            {
                DBDataSource dataSource = dbDataSources.Item(datasourceName);

                ret = dataSource.GetValue(columnName, 0).Trim();
            }
            catch
            {
                
                
            }
            return ret;
        }
        // setear un valor
        public static void SetValue(this DBDataSources dbDataSources, string datasourceName, string columnName, int rowIndex,
            string value)
        {

            if (dbDataSources == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(datasourceName))
                throw new ArgumentException("No puede ser nulo o vacio.");

            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("No puede ser nulo o vacio.");




            DBDataSource source = dbDataSources.Item(datasourceName);

            source.SetValue(columnName, rowIndex, value);
        }

        //public static void Set(this DBDataSources sources, string datasourceId, string columnId, int rowIndex,
        //    double? value)
        //{
        //    DBDataSource source = sources.Item(datasourceId);

        //    source.Set(columnId, rowIndex, value);
        //}

        //public static void Set(this DBDataSources sources, string datasourceId, string columnId, int rowIndex,
        //    DateTime? value)
        //{
        //    DBDataSource source = sources.Item(datasourceId);

        //    source.Set(columnId, rowIndex, value);
        //}



    }// fin de la clase

}// fin del namespace
