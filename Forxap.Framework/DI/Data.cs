using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Framework.DI
{
    public class Sb1Data : Base, IDisposable
    {
        public  Dictionary<string, string> GetDictionaryFromUDT(string tableName)
        {


            Dictionary<string, string> listObject = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;



            strSQL = string.Format("select \"Code\",\"Name\" From \"{0}\"  ", tableName);

            oRecordSet.DoQuery(strSQL);
            listObject.Add("", "");

            while (!oRecordSet.EoF)
            {

                listObject.Add(oRecordSet.Fields.Item("Code").Value.ToString().Trim(), oRecordSet.Fields.Item("Name").Value.ToString().Trim());
                oRecordSet.MoveNext();
            }

            return listObject;

        }




        public  Dictionary<string, string> GetDictionaryFromUDT(string tableName, string[] fields)
        {


            Dictionary<string, string> listObject = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;



            strSQL = string.Format("select \"{0}\",\"{1}\" From \"{2}\" ", fields[0].Trim(), fields[1].Trim(), tableName);

            oRecordSet.DoQuery(strSQL);
            listObject.Add("", "");

            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item(fields[0].Trim()).Value.ToString().Trim().Length > 0)
                    listObject.Add(oRecordSet.Fields.Item(fields[0].Trim()).Value.ToString().Trim(), oRecordSet.Fields.Item(fields[1].Trim()).Value.ToString().Trim());
                oRecordSet.MoveNext();
            }

            return listObject;

        }



        public  object GetSingleValue(string sqlString)
        {
            object ret = null;

            

            if (!string.IsNullOrEmpty(sqlString))
            {
                SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                oRecordSet.DoQuery(sqlString);



                ret = oRecordSet.Fields.Item(0).Value;

            }

            

            return ret;

        }




        public  Dictionary<string, string> GetListFromSQL(string sqlString)
        {
            Dictionary<string, string> listObject = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRecordSet.DoQuery(sqlString);
            listObject.Add("", "");

            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item(0).Value.ToString().Trim().Length > 0)
                    listObject.Add(oRecordSet.Fields.Item(0).Value.ToString().Trim(), oRecordSet.Fields.Item(1).Value.ToString().Trim());
                oRecordSet.MoveNext();
            }

            return listObject;



        }

        public Dictionary<string, string> GetObjectFromSQL(string sqlString)
        {
            Dictionary<string, string> listObject = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRecordSet.DoQuery(sqlString);
         

            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item(0).Value.ToString().Trim().Length > 0)
                    listObject.Add(oRecordSet.Fields.Item(0).Value.ToString().Trim(), oRecordSet.Fields.Item(1).Value.ToString().Trim());
                oRecordSet.MoveNext();
            }

            return listObject;



        }
        public void GetDataTableFromSQL(string sqlString, ref SAPbouiCOM.DataTable oDataTable)
        {

            if (oDataTable != null)
            {

                oDataTable.ExecuteQuery(sqlString);

            }

        }



        public  Dictionary<string, string> GetValidValues(string tableID, string aliasID)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            strSQL = string.Format(" SELECT T1.\"FldValue\", T1.\"Descr\" FROM CUFD T0 INNER JOIN UFD1 T1 ON T0.\"TableID\" = T1.\"TableID\" AND T0.\"FieldID\" = T1.\"FieldID\" WHERE T1.\"TableID\" = '{0}' And T0.\"AliasID\" = '{1}' ", tableID, aliasID);

            oRecordSet.DoQuery(strSQL);
            list.Add("", "");


            while (!oRecordSet.EoF)
            {
                list.Add(oRecordSet.Fields.Item(0).Value.ToString(), oRecordSet.Fields.Item(1).Value.ToString());
                oRecordSet.MoveNext();
            }

            return list;
        }


        #region Disposable




        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~Sb1Data()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }



}
