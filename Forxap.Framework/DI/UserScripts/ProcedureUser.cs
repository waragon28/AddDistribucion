using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbobsCOM;

using Forxap.Framework.Utils;
using System.IO;

namespace Forxap.Framework.DI.QueryManager
{
    public class Sb1ProcedureUser :Base, IDisposable
    {

        public bool CreateProcedure(string fileName, out Sb1Error sb1Error)
        {
            bool ret = false;
            string queryScript = string.Empty;
            sb1Error = null;
            SAPbobsCOM.Recordset oRecordset;
            StreamReader sr = new StreamReader(fileName);

            while (sr.Peek() >= 0)
            {
                queryScript += sr.ReadLine() + " ";
            }

             oRecordset = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (oRecordset == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

               try
                 {


                   oRecordset.DoQuery(queryScript);

                }
                catch (Exception ex)
                {
                    throw;
                }

                finally
                {
                    if (oRecordset != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                }
            
            return ret;
        }

        public bool CreateProcedure(string procedureAlias,string fileName , out Sb1Error sb1Error)
        {

            bool ret = false;
            int retCode = 0;


            sb1Error = null;
            string queryScript = string.Empty;
            
            SAPbobsCOM.UserQueries oUserQueries = (UserQueries)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserQueries);

            try
            {
                // debo abrir el archivo y ponerlo en una variable

                StreamReader sr = new StreamReader(fileName);
                
                while (sr.Peek() >= 0)
                {
                    queryScript +=sr.ReadLine() + " " ;
                }

                oUserQueries.QueryCategory = -1;
                oUserQueries.QueryType = UserQueryTypeEnum.uqtStoredProcedure;
                //oUserQueries.ProcedureAlias = "TestSP";
                //oUserQueries.ProcedureName = queryScript;

                oUserQueries.ProcedureAlias = "TestSP"; ;
                oUserQueries.ProcedureName = "\"MySPName\"";

                int iRet = oUserQueries.Add();

                Sb1Error sbqError;
                sbqError = Errors.GetLastErrorMessage();
                Forxap.Framework.UI.Sb1Messages.ShowMessageBox(sbqError.Message.ToString());
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowMessageBox("Hola");
          
            }


        
            return ret;
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
        ~Sb1ProcedureUser()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion



    }// fin de la clase


}// fin del namespace
