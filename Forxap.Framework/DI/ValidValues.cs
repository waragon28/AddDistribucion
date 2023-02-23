using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM;
using SAPbobsCOM;

namespace Forxap.Framework.DI
{
    public  class ValidValues : Base
    {

        public static Dictionary<string,string> GetValidValues(string tableID, string aliasID )
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            strSQL = string.Format(" SELECT T1.\"FldValue\", T1.\"Descr\" FROM CUFD T0 INNER JOIN UFD1 T1 ON T0.\"TableID\" = T1.\"TableID\" AND T0.\"FieldID\" = T1.\"FieldID\" WHERE T1.\"TableID\" = '{0}' And T0.\"AliasID\" = '{1}' ", tableID,aliasID ); 

            oRecordSet.DoQuery(strSQL);
            list.Add("", "");


            while (!oRecordSet.EoF)
            {
                list.Add(oRecordSet.Fields.Item(0).Value.ToString(), oRecordSet.Fields.Item(1).Value.ToString());
                oRecordSet.MoveNext();
            }

            return list;
        }



        public static Dictionary<string, string> GetQueryCombos(string store)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            strSQL = store;

            oRecordSet.DoQuery(strSQL);
            list.Add("", "");

            while (!oRecordSet.EoF)
            {
                list.Add(oRecordSet.Fields.Item(0).Value.ToString(), oRecordSet.Fields.Item(1).Value.ToString());
                oRecordSet.MoveNext();
            }

            return list;
        }

    }// fin de la clase


}// fin del namespace
