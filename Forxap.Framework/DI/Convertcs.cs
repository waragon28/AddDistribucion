using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Forxap.Framework.DI
{
   public static class Convertcs
    {
       public static DataTable RsTODataTablaV2(ref SAPbobsCOM.Recordset _rs)
       {
           DataTable dt = new DataTable();
           for (int i = 0; i < _rs.Fields.Count; i++)
               dt.Columns.Add(_rs.Fields.Item(i).Description);
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

    }
}
