using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using Forxap.Framework.Extensions;
namespace Forxap.Framework.DI.Bancos
{
  public  class Banks : Base, IDisposable

    {
        public static void GetBankList(ref SAPbouiCOM.ComboBox combobox, string moneda)
        {
            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;
            string tableName = "ODSC", tableName1 = "DSC1";
            strSQL = string.Format("select Distinct B.\"BankCode\",A.\"BankName\" From \"{0}\" A inner join \"{1}\" B ON A.\"BankCode\" = B.\"BankCode\" Where B.\"Branch\" = '{2}'  ", tableName, tableName1, moneda);
            Dictionary<string, string> listObject;

            if (combobox != null)
            {
                combobox.RemoveValidValues();
                listObject = Forxap.Framework.DI.Sb1Users.GetListFromSQL(strSQL);
                foreach (var item in listObject)
                {
                    combobox.ValidValues.Add(item.Key, item.Value);
                }

                combobox.Item.DisplayDesc = true;
            }

        }
        public static void GetBankList(ref  SAPbouiCOM.ComboBox combobox)
        {

       
            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            string tableName = "ODSC", tableName1 = "DSC1";
        
            strSQL = string.Format("select Distinct B.\"BankCode\",A.\"BankName\" From \"{0}\" A inner join \"{1}\" B ON A.\"BankCode\" = B.\"BankCode\" ", tableName, tableName1);

            oRecordSet.DoQuery(strSQL);
            
            //combobox.ValidValues.Add("", "");

            while (!oRecordSet.EoF)
            {

                combobox.ValidValues.Add(oRecordSet.Fields.Item("BankCode").Value.ToString().Trim(), oRecordSet.Fields.Item("BankName").Value.ToString().Trim());
                           
                oRecordSet.MoveNext();
            }

        }

        public static void GetMonedas(ref SAPbouiCOM.ComboBox combobox)
        {


            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            string tableName = "OCRN";

            strSQL = string.Format("select \"CurrCode\",\"CurrName\" From \"{0}\"  ", tableName);

            oRecordSet.DoQuery(strSQL);

            //combobox.ValidValues.Add("", "");

            while (!oRecordSet.EoF)
            {

                combobox.ValidValues.Add(oRecordSet.Fields.Item("CurrCode").Value.ToString().Trim(), oRecordSet.Fields.Item("CurrName").Value.ToString().Trim());

                oRecordSet.MoveNext();
            }

        }

        public static void GetAccountList(ref SAPbouiCOM.ComboBox combobox , string bankCode, string Currency)
        {
            try
            {

                SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string strSQL = string.Empty;

                string tableName = "DSC1";

                strSQL = string.Format("select \"Account\",\"GLAccount\" From \"{0}\"  where  \"BankCode\" = '{1}' AND IFNULL(\"Branch\",'{2}')='{2}'", tableName, bankCode, Currency);

                oRecordSet.DoQuery(strSQL);

                combobox.RemoveValidValues();

                while (!oRecordSet.EoF)
                {

                    combobox.ValidValues.Add(oRecordSet.Fields.Item("Account").Value.ToString().Trim(), oRecordSet.Fields.Item("GLAccount").Value.ToString().Trim());

                    oRecordSet.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void GetAccountList(ref SAPbouiCOM.ComboBox combobox)
        {
            try
            {

                SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string strSQL = string.Empty;

                string tableName = "DSC1";

                strSQL = string.Format("select \"Account\",\"GLAccount\" From \"{0}\"  where  \"BankCode\" = '{1}' AND IFNULL(\"Branch\",'{2}')='{2}'", tableName, "", "");

                oRecordSet.DoQuery(strSQL);

                combobox.RemoveValidValues();

                while (!oRecordSet.EoF)
                {

                    combobox.ValidValues.Add(oRecordSet.Fields.Item("Account").Value.ToString().Trim(), oRecordSet.Fields.Item("GLAccount").Value.ToString().Trim());

                    oRecordSet.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
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
        ~Banks()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }
}
