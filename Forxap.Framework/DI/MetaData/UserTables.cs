using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Forxap.Framework.Utils;
using Forxap.Framework.Extensions;
using SAPbobsCOM;


namespace Forxap.Framework.DI
{
    public class Sb1UserTables : Base, IDisposable
    {
        SAPbobsCOM.UserTablesMD oUserTablesMD = null;
     //   SAPbobsCOM.UserObjectsMD oUserObjectMD = null;

        /// <summary>
        ///  El metodo crea una tabla definida por el usuario, metodo para el modulo intercompany
        /// </summary>
        /// <param name="oCompany">base de datos de la compañia donde se va crear la tabla</param>
        /// <param name="tableName"></param>
        /// <param name="tableDescription"></param>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public  Sb1Error CreateUserTable(SAPbobsCOM.Company oCompany, string tableName, string tableDescription, SAPbobsCOM.BoUTBTableType tableType)
        {

            #region Variables


            bool tableExist = false;
            int retCode = 0;
            Sb1Error resultObject = null;//


            int errorNumber = 0;
            string errorMessage = Messages.OK;

            #endregion


            ///inicializo el objeto
            oUserTablesMD = ((SAPbobsCOM.UserTablesMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables)));

           
   
            if (oUserTablesMD == null)
                throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserTablesMD));



            try
            {

                /// verifico si la tabla existe para esta empresa
                tableExist = oUserTablesMD.GetByKey(tableName);


                UserProceduresMD oUserProceduresMD = new UserProceduresMD();


               


                oCompany.StartTransaction();

                /// si la tabla no existe en esta compañia  entonces creo la tabla
                if (!tableExist)
                {
                    // debo agregar el prefijo "@"?
                    oUserTablesMD.TableName = tableName;
                    oUserTablesMD.TableDescription = tableDescription;
                    oUserTablesMD.TableType =   tableType;


                    

                    // debo verificar, si la tabla se agrego correctamente
                    retCode = oUserTablesMD.Add();

                    if (retCode != 0)
                    {


                        resultObject = Utils.Errors.GetLastErrorMessage(oCompany);
                    }

                    else
                    {
                        resultObject = new Sb1Error(errorNumber, errorMessage);
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        resultObject = new Sb1Error(oCompany.CompanyName, errorNumber = 0, string.Format("{0}: {1} {2}", "Tabla ", tableName, ", se creo con exito"));

                    }
                }
                else
                {
                    // deberia actualizar la tabla, sus campos?


                    resultObject = new Sb1Error(oCompany.CompanyName, errorNumber = 20000, errorMessage = "Tabla " + tableName + " : " + Messages.ObjetExist);
                }

                oCompany.EndTransaction(BoWfTransOpt.wf_Commit);
            }
             catch (Exception )
            {

                oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
            }

            finally
            {
                // libero recursos

                if (oUserTablesMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserTablesMD);
                    oUserTablesMD = null;
                    GC.Collect();
                }
            }


            return resultObject;
        }// fin del metodo CreateUserTable
        // fin del metodo CreateUserTable
        public Sb1Error CreateUserTable(string tableName, string tableDescription, SAPbobsCOM.BoUTBTableType tableType, SAPbobsCOM.BoYesNoEnum archivable, string ArchiveDateField = null)
        {

            #region Variables


            bool tableExist = false;
            int retCode = 0;
            Sb1Error resultObject;//


            int errorNumber = 0;
            string errorMessage = Messages.OK;

            #endregion

           if (oCompany == null)
               throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserTablesMD));

            
            ///inicializo el objeto
            oUserTablesMD = ((SAPbobsCOM.UserTablesMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables)));
            
            if (oUserTablesMD == null)
                throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserTablesMD));

            

            try
            {
               //if (!oCompany.InTransaction)
               // oCompany.StartTransaction();

                /// verifico si la tabla existe para esta empresa
                tableExist = oUserTablesMD.GetByKey(tableName);

                

                /// si la tabla no existe en esta compañia  entonces creo la tabla
                if (!tableExist)
                {
                    // debo agregar el prefijo "@"?
                    oUserTablesMD.TableName = tableName;
                    oUserTablesMD.TableDescription = tableDescription;
                    oUserTablesMD.TableType = tableType;
                    oUserTablesMD.Archivable = archivable;

                    
                  //  oUserTablesMD.ArchiveDateField = ArchiveDateField;



                    // debo verificar, si la tabla se agrego correctamente
                    retCode = oUserTablesMD.Add();

                    if (retCode != 0)
                    {

                        oCompany.GetLastError(out errorNumber, out  errorMessage);
                        resultObject = new Sb1Error(errorNumber, string.Format(" {0} : {1}", tableName, errorMessage));
                        //oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
                    }

                    else
                    {
                        resultObject = new Sb1Error(errorNumber, string.Format(" {0} : {1}", tableName, " proceso de creación, exitoso"));
                        // .EndTransaction(BoWfTransOpt.wf_Commit);
                    }
                }
                else
                {
                    // deberia actualizar la tabla, sus campos?


                    resultObject = new Sb1Error(errorNumber = 20000, errorMessage = string.Format( " Tabla: {0}  {1}", tableName,  Messages.ObjetExist));
                }


              //  oCompany.EndTransaction(BoWfTransOpt.wf_Commit);
            }

            catch (Exception exception)
            {
                //ACID!

                resultObject = Errors.GetLastErrorFromHRException(tableName, exception);

                oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
            }
            finally
            {
                // libero recursos

                if (oUserTablesMD != null)
                {

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserTablesMD);
                    oUserTablesMD = null;
                    GC.Collect();
                }
            }


            return resultObject;
        }// fin del metodo CreateUserTable


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
        ~Sb1UserTables()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }// fin de la clase

}// fin del namespace
