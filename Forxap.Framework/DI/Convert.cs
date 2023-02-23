using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;

using System.Data;

namespace Forxap.Framework.Utils
{
   public class oConvert : Base
    {

     //private DataTable ConvertRS2DT(SAPbobsCOM.Recordset RS)
     //  {
     //      DataTable dtTable = new DataTable();
     //      DataColumn NewCol;
     //      DataRow NewRow;
     //      int ColCount;
     //      try
     //      {
     //          for (ColCount = 0; (ColCount <= RS.Fields.Count); ColCount++)
     //          {
     //              //1;
     //              string dataType = System.Select;
     //              RS.Fields.Item[ColCount].Type;
     //              SAPbobsCOM.BoFieldTypes.db_Alpha;
     //              dataType = (dataType + String);
     //              SAPbobsCOM.BoFieldTypes.db_Date;
     //              dataType = (dataType + DateTime);
     //              SAPbobsCOM.BoFieldTypes.db_Float;
     //              dataType = (dataType + Double);
     //              SAPbobsCOM.BoFieldTypes.db_Memo;
     //              dataType = (dataType + String);
     //              SAPbobsCOM.BoFieldTypes.db_Numeric;
     //              dataType = (dataType + Decimal);
     //              dataType = (dataType + String);
     //              Columns.Add(NewCol);
     //          }

     //          do
     //          {
     //              NewRow = dtTable.NewRow;
     //              //populate column the row we re creating;
     //              for (ColCount = 0; (ColCount <= RS.Fields.Count); ColCount++)
     //              {
     //                  1;
     //                  NewRow.Item[RS.Fields.Item[ColCount].Name] = RS.Fields.Item[ColCount].Value;
     //              }


     //              dtTable.Rows.Add(NewRow);
     //              RS.MoveNext();
     //          } while (RS.EoF);

     //          return dtTable;
     //      }
     //      catch (Exception ex)
     //      {
     //          //MsgBox(ex.ToString&Chr(10Unknown&, Error, converting, SAP, Recordset, to, DataTable, MsgBoxStyle.Exclamation);
     //          return null;
     //      }

     //  }

       public void Convert2()
       {
           SBObob sboBob = new SBObob();

           //sboBob.ConvertValidValueToEnumValue();
           //sboBob.ConvertEnumValueToValidValue();
       }

    }// fin de la clase
}// fin del namespace
