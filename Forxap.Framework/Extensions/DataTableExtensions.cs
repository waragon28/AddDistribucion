using System.Text;

 
 



using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Globalization; 
using System.Linq; 
using System.Reflection; 
using System.Xml.Linq; 
using System.Xml.XPath; 
 
 
//using Common; 

 
//using JetBrains.Annotations;  
using SAPbouiCOM;
//using Types; 


namespace Forxap.Framework.Extensions
{
    public static class DataTableExtensions
    {

         /// <summary> 
         /// Gets the date time. 
         /// </summary> 
         /// <param name="dataTable">The data table.</param> 
         /// <param name="columnId">The column identifier.</param> 
         /// <param name="rowIndex">Index of the row.</param> 
         /// <returns></returns> 
         /// <exception cref="System.ArgumentException">columnId</exception> 
         //public static DateTime? GetDateTime(this DataTable dataTable, string columnId, int rowIndex) 
         //{ 
         //    DataColumn column = dataTable. .GetColumn(columnId, rowIndex); 
 
 
         //    if (column.Type != BoFieldsType.ft_Date) 
         //    { 
         //        throw new ArgumentException
         //            ( 
         //            $"Expected '{columnId}' to be of type 'BoFieldsType.ft_Date' but is '{dataTable.Columns.Item(columnId).Type}' instead.",nameof(columnId)
         //           ); 
         //    } 

 
         //    var data = dataTable.GetValue(columnId, rowIndex); 
         //    var value = Convert.ToDateTime(data); 
         //    return value; 
         //} 


         public static DataColumn GetColumn(this DataTable dataTable, string columnId, int rowIndex) 
         { 
             //if (rowIndex.OutsideRange(0, dataTable.Rows.Count - 1)) 
             //{ 
             //    return null; 
             //} 
         
          

             if (dataTable == null)
                 throw new ArgumentNullException("dataTable");
             
 
             if (string.IsNullOrEmpty(columnId)) 
                 throw new ArgumentException("No puede ser nulo o vacio."); 
 
 
             var column = dataTable.Columns.Cast<DataColumn>().First(c => columnId.Equals(c.Name)); 
             if (column == null) 
             { 
                 throw new ArgumentException( "DataTable '{dataTable.UniqueID}' no contiene una columna con el id '{columnId}'.",
                     columnId); 
             } 
 
 
             return column; 
          }



         public static string GetString(this DataTable dataTable,  string columnId, int rowIndex) 
         {

             if (dataTable == null)
                 throw new ArgumentNullException("dataTable");

             if (string.IsNullOrEmpty(columnId))
                 throw new ArgumentException("ColumnID No puede ser nulo o vacio."); 
 
             if ( rowIndex <0 )
                throw new ArgumentException("RowIndex No puede ser nulo o vacio.");

            string ret = dataTable.GetValue(columnId, rowIndex).ToString().Trim();

             return ret;
         }


        /// <summary> 
         /// Obtener el datetime. 
         /// </summary> 
         /// <param name="dataTable">el datatable.</param> 
         /// <param name="columnId">el Id de la columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <returns></returns> 
         /// <exception cref="System.ArgumentException">columnId</exception> 
         public static DateTime GetDateTime(this DataTable dataTable, string columnId, int rowIndex) 
         {

             if (dataTable == null)
                 throw new ArgumentNullException("dataTable");

             if (string.IsNullOrEmpty(columnId))
                 throw new ArgumentException("No puede ser nulo o vacio."); 
             
             DataColumn column = dataTable.GetColumn(columnId, rowIndex); 
 
 
             if (column.Type != BoFieldsType.ft_Date) 
             { 
                 throw new ArgumentException( 
                     "Se esperaba '{columnId}' sea de tipo 'BoFieldsType.ft_Date' pero es de tipo '{dataTable.Columns.Item(columnId).Type}' ", 
                     columnId); 
             } 
 
 
             var data = dataTable.GetValue(columnId, rowIndex); 
             var value = Convert.ToDateTime(data); 
             return value; 
         } 


         /// <summary> 
         /// Obtener el double. 
         /// </summary> 
         /// <param name="dataTable">el datatable.</param> 
         /// <param name="columnId">el Id de la columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <returns></returns> 
         public static double GetDouble(this DataTable dataTable, string columnId, int rowIndex) 
         {
             if (dataTable == null)
                 throw new ArgumentNullException("dataTable");

             if (string.IsNullOrEmpty(columnId))
                 throw new ArgumentException("No puede ser nulo o vacio."); 
             
             var data = dataTable.GetValue(columnId, rowIndex); 
             double value = Convert.ToDouble(data); 
             return value; 
         } 



        /// <summary> 
         /// Obtener el  int. 
         /// </summary> 
         /// <param name="dataTable">el datatable.</param> 
         /// <param name="columnId">el Id de la columna.</param> 
         /// <param name="rowIndex">Indice del registro.</param> 
         /// <returns></returns> 
         public static int? GetInt(this DataTable dataTable, string columnId, int rowIndex) 
         { 
             int? value = null;

             if (dataTable == null)
                 throw new ArgumentNullException("dataTable");

             if (string.IsNullOrEmpty(columnId))
                 throw new ArgumentException("No puede ser nulo o vacio."); 

             object  data = dataTable.GetValue(columnId, rowIndex); 

             if (data.ToString().Length> 0)
             { 
                value = Convert.ToInt32(data); 

             }
             return value; 
         } 




    }// fin de la clase

}// fin del namespace
