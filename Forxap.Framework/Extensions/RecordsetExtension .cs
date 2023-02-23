using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Forxap.Framework.Extensions
{
   public static class RecordsetExtension
    {


       public static DataTable ToDataTable(this SAPbobsCOM.Recordset oRecordset)
       {
           DataTable dt = new DataTable("DataTable1");

           try
           {


               
               for (int i = 0; i < oRecordset.Fields.Count; i++)
                   dt.Columns.Add(oRecordset.Fields.Item(i).Description);
               while (!oRecordset.EoF)
               {
                   DataRow row = dt.NewRow();
                   for (int i = 0; i < oRecordset.Fields.Count; i++)
                       row[i] = oRecordset.Fields.Item(i).Value;
                   dt.Rows.Add(row.ItemArray);
                   oRecordset.MoveNext();
               }
               

           }
           catch (Exception ex)
           {

               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
           }

           finally
           {
               // oForm.Freeze(false);
           }

           return dt;
       }


       public static DataTable RsTODataTablaV2(ref SAPbobsCOM.Recordset _rs)
       {
           DataTable dt = new DataTable();
           for (int i = 0; i < _rs.Fields.Count; i++)
           {
               dt.Columns.Add(_rs.Fields.Item(i).Description, _rs.Fields.Item(i).GetType());
           }

           // inserta registros al datatable
           while (!_rs.EoF)
           {
               DataRow row = dt.NewRow();
               for (int i = 0; i < _rs.Fields.Count; i++)
                   row[i] = _rs.Fields.Item(i).Value;
               dt.Rows.Add(row.ItemArray);
               _rs.MoveNext();
           }


           return dt;
       }

       //public static SAPbouiCOM.DataTable  DatatableTODataTablaSAP(ref System.Data.DataTable dataTable)
       //{
       //    DataTable dt = new DataTable();
       //    for (int i = 0; i < dataTable.Fields.Count; i++)
       //    {
       //        dt.Columns.Add(dataTable.Fields.Item(i).Description);

       //    }

       //    while (!dataTable.EoF)
       //    {
       //        DataRow row = dt.NewRow();
       //        for (int i = 0; i < dataTable.Fields.Count; i++)
       //            row[i] = dataTable.Fields.Item(i).Value;
       //        dt.Rows.Add(row.ItemArray);
       //        dataTable.MoveNext();
       //    }
       //    return dt;
       //}


    }// fin de la clase

}// fin del namespace
