using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;
using SAPbouiCOM;
using Forxap.Framework.Utils;



namespace Forxap.Framework.DI
{
    public class Sb1UserObjects : Base, IDisposable
    {

        //public Errors.Sb1Error CreateUDO(SAPbobsCOM.Company oCompany, string tableName, string tableDescription, SAPbobsCOM.BoUTBTableType tableType)
        //{
        //    Errors.Sb1Error sb1Error = null;


        //    return sb1Error;
        //}

        public void CreateUDO(SAPbobsCOM.Company oCompany, SAPbobsCOM.BoYesNoEnum canCancel, SAPbobsCOM.BoYesNoEnum canClose, SAPbobsCOM.BoYesNoEnum canCreateDefaultForm,
  SAPbobsCOM.BoYesNoEnum canDelete, SAPbobsCOM.BoYesNoEnum canFind, SAPbobsCOM.BoYesNoEnum canYearTransfer, string childTableName, string objectCode, string objectName, SAPbobsCOM.BoYesNoEnum manageSeries, SAPbobsCOM.BoUDOObjType objectType, string tableName)
        {
            SAPbobsCOM.UserObjectsMD oUserObjectMD = null;
            int retCode = 0;
            Sb1Error sb1Error = null;

            try
            {


                oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));

                if (!oUserObjectMD.GetByKey(objectCode))
                {
                    oUserObjectMD.CanCancel = canCancel;
                    oUserObjectMD.CanClose = canClose;
                    oUserObjectMD.CanCreateDefaultForm =  canCreateDefaultForm;
                  

                    oUserObjectMD.CanDelete = canDelete;
                    oUserObjectMD.CanFind = canFind;
                    oUserObjectMD.CanYearTransfer = canYearTransfer;
                    oUserObjectMD.ChildTables.TableName = childTableName;
                    oUserObjectMD.Code = objectCode;
                    oUserObjectMD.Name = objectName;
                    oUserObjectMD.ManageSeries = manageSeries;

                    oUserObjectMD.ObjectType = objectType;
                    oUserObjectMD.TableName = tableName;


                    /// registro el objeto dentro de SAP
                    retCode = oUserObjectMD.Add();


                    if (retCode != 0)
                    {

                        sb1Error = Utils.Errors.GetLastErrorMessage(oCompany);
                    }

                    else
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        //  sb1Error = new Utils.Errors.Sb1Error(oCompany.CompanyName, errorNumber = 0, string.Format("{0}: {1} {2}", "Objeto ", fieldName, ", se creo con exito"));

                    }

                }
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(string.Format("Error : {1}", ex.Message.ToString()));

            }

            finally
            {
                if (oUserObjectMD != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
            }
        }

        public Sb1Error CreateUDO(SAPbobsCOM.BoYesNoEnum canCancel, SAPbobsCOM.BoYesNoEnum canClose, SAPbobsCOM.BoYesNoEnum canCreateDefaultForm,
SAPbobsCOM.BoYesNoEnum canDelete, SAPbobsCOM.BoYesNoEnum canFind, SAPbobsCOM.BoYesNoEnum canYearTransfer, SAPbobsCOM.BoYesNoEnum canApprove, SAPbobsCOM.BoYesNoEnum canArchive,SAPbobsCOM.BoYesNoEnum canLog, string templateID, string childTableName, string objectCode, string objectName, SAPbobsCOM.BoYesNoEnum manageSeries, SAPbobsCOM.BoUDOObjType objectType, string tableName, int fatherMenuID, string menuID , string menuCaption)
        {
            SAPbobsCOM.UserObjectsMD oUserObjectMD = null;
            int retCode = 0;
            Sb1Error sb1Error = null;

            try
            {
              //  oCompany.StartTransaction();

                oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));

                if (!oUserObjectMD.GetByKey(objectCode))
                {
                    //oUserObjectMD.CanCancel = canCancel;
                    //oUserObjectMD.CanClose = canClose;
                    //oUserObjectMD.CanCreateDefaultForm = BoYesNoEnum.tNO;// canCreateDefaultForm;

                    //oUserObjectMD.CanDelete = canDelete;
                    //oUserObjectMD.CanFind = canFind;
                    //oUserObjectMD.CanYearTransfer = canYearTransfer;
                    //oUserObjectMD.ChildTables.TableName = childTableName;
                    //oUserObjectMD.Code = objectCode; // objectCode;
                    //oUserObjectMD.ManageSeries = manageSeries;
                    //oUserObjectMD.Name = objectName;
                    //oUserObjectMD.ObjectType = BoUDOObjType.boud_Document; // objectType; boud_Document
                    //oUserObjectMD.TableName = tableName;

                    //oUserObjectMD.CanApprove = canApprove;
                    //oUserObjectMD.CanArchive = canArchive;
                    //oUserObjectMD.CanLog = canLog;
                    //oUserObjectMD.TemplateID = templateID;


                    
                    oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
                    oUserObjectMD.CanCancel = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.CanClose = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.CanCreateDefaultForm = SAPbobsCOM.BoYesNoEnum.tNO;
                    oUserObjectMD.CanDelete = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.CanYearTransfer = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.ChildTables.TableName = "MIX_FAC_FAC1";
                    oUserObjectMD.Code = "MIX_FAC";
                    oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tYES;
                    oUserObjectMD.Name = "MIX Factoring";
                    oUserObjectMD.ObjectType = SAPbobsCOM.BoUDOObjType.boud_Document;
                    oUserObjectMD.TableName = "MIX_FAC_OFAC"; 
                    
                    
                    
                    
                    
                    
                    

                    //oUserObjectMD.FatherMenuID = fatherMenuID;
                    //oUserObjectMD.MenuUID = menuID.ToString();
                    //oUserObjectMD.MenuCaption = menuCaption;

                    //oUserObjectMD.OverwriteDllfile = BoYesNoEnum.tNO;


                    
                    //oUserObjectMD.ChildTables.Add();


                    //oUserObjectMD.FindColumns.ColumnAlias = "DocEntry";
                    //oUserObjectMD.FindColumns.ColumnDescription = "DocEntry";

                    //oUserObjectMD.FindColumns.Add();

                    /// registro el objeto dentro de SAP
                    retCode = oUserObjectMD.Add();


                    //SAPbobsCOM.UserObjectsMD oUserObjectMD = null;
                    //oUserObjectMD = ((SAPbobsCOM.UserObjectsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD)));
                    //oUserObjectMD.CanCancel = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.CanClose = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.CanCreateDefaultForm = SAPbobsCOM.BoYesNoEnum.tNO;
                    //oUserObjectMD.CanDelete = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.CanFind = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.CanYearTransfer = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.ChildTables.TableName = "SM_MOR1";
                    //oUserObjectMD.Code = "SM_MOR";
                    //oUserObjectMD.ManageSeries = SAPbobsCOM.BoYesNoEnum.tYES;
                    //oUserObjectMD.Name = "SM_Meal_Order";
                    //oUserObjectMD.ObjectType = SAPbobsCOM.BoUDOObjType.boud_Document;
                    //oUserObjectMD.TableName = "SM_OMOR";
                    //lRetCode = oUserObjectMD.Add(); 


                    if (retCode != 0)
                    {

                        sb1Error = Utils.Errors.GetLastErrorMessage(oCompany);
                    }

                    else if (retCode == -1)
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(oCompany.CompanyName, retCode = 0, string.Format("{0}: {1} {2}", "Objeto ", tableName, ", se creo con exito"));

                    }

            

                }

                else
                {
                    sb1Error = new Sb1Error(oCompany.CompanyName, retCode = 0, string.Format("{0}: {1} {2}", "Objeto ", tableName, ", ya existe"));
                }

              //  oCompany.EndTransaction(BoWfTransOpt.wf_Commit);
            }
            catch (Exception ex)
            {
               // oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
                Forxap.Framework.UI.Sb1Messages.ShowError(string.Format("Error : {1}", ex.Message.ToString()));

            }

            finally
            {
                if (oUserObjectMD != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
            }

            return sb1Error;
        }

        /// <summary>
        /// Metodo para registrar un UDO
        /// </summary>
        /// <param name="canCancel"></param>
        /// <param name="canClose"></param>
        /// <param name="canCreateDefaultForm"></param>
        /// <param name="canDelete"></param>
        /// <param name="canFind"></param>
        /// <param name="canYearTransfer"></param>
        /// <param name="canApprove"></param>
        /// <param name="canArchive"></param>
        /// <param name="canLog"></param>
        /// <param name="manageSeries"></param>
        /// <param name="objectCode"></param>
        /// <param name="objectName"></param>
        /// <param name="tableName"></param>
        /// <param name="findColumns1"></param>
        /// <param name="findColumns2"></param>
        /// <param name="childTables"></param>
        /// <param name="objectType"></param>
        public void AddUDO(SAPbobsCOM.BoYesNoEnum canCancel, SAPbobsCOM.BoYesNoEnum canClose, SAPbobsCOM.BoYesNoEnum canCreateDefaultForm, SAPbobsCOM.BoYesNoEnum canDelete, SAPbobsCOM.BoYesNoEnum canFind, SAPbobsCOM.BoYesNoEnum canYearTransfer, SAPbobsCOM.BoYesNoEnum canApprove, SAPbobsCOM.BoYesNoEnum canArchive, SAPbobsCOM.BoYesNoEnum enableEnhancedForm, SAPbobsCOM.BoYesNoEnum canLog, SAPbobsCOM.BoYesNoEnum manageSeries, string objectCode, string objectName, string tableName, IDictionary<string, string> findColumns, IDictionary<string, string> FormColumns, string logTableName = "", List<string> childTables = null, SAPbobsCOM.BoUDOObjType objectType = SAPbobsCOM.BoUDOObjType.boud_Document)
        {

            oCompany.StartTransaction();
            SAPbobsCOM.UserObjectsMD oUserObjectMD = null; 
            try
            {
                oUserObjectMD = (SAPbobsCOM.UserObjectsMD)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD);


                if (!oUserObjectMD.GetByKey(objectCode))
                {
                    oUserObjectMD.CanCancel = canCancel;
                    oUserObjectMD.CanClose = canClose;
                    oUserObjectMD.CanCreateDefaultForm = canCreateDefaultForm;
                    oUserObjectMD.CanDelete = canDelete;
                    oUserObjectMD.CanFind = canFind;
                 
                    oUserObjectMD.CanApprove = canApprove;
                    oUserObjectMD.CanArchive = canArchive;


                    oUserObjectMD.EnableEnhancedForm = enableEnhancedForm;

                    // si ingresaron por lo menos un campo para el formulario por defecto

                    if (FormColumns != null)
                    {
                        foreach (var formColumn in FormColumns)
                        {
                            oUserObjectMD.FormColumns.FormColumnAlias = formColumn.Key;
                            oUserObjectMD.FormColumns.FormColumnDescription = formColumn.Value;
                            oUserObjectMD.FormColumns.Add();
                        }
                    }

                    // si ingresaron por lo menos un campo de búsqueda
 
                        if (findColumns != null)
                        {
                            foreach (var findColumn in findColumns)
                            {
                                
                                if ((Convert.ToInt32(findColumn.Key)) == 0)
                                {
                                    oUserObjectMD.FindColumns.ColumnAlias = findColumn.Value;
                                    oUserObjectMD.FindColumns.Add();
                                }
                                else
                                {
                                    oUserObjectMD.FindColumns.SetCurrentLine((Convert.ToInt32(findColumn.Key)));
                                    oUserObjectMD.FindColumns.ColumnAlias = findColumn.Value;
                                    oUserObjectMD.FindColumns.Add();
                                }
                            }
                        }



                    

                    oUserObjectMD.CanLog = canLog;
                    oUserObjectMD.LogTableName = logTableName;
                    oUserObjectMD.CanYearTransfer = canYearTransfer;
                    oUserObjectMD.ExtensionName = "";

                    // recorro las tablas hijas
                    if (childTables != null)
                    {
                        foreach (var childTable in childTables)
                        {
                            oUserObjectMD.ChildTables.TableName  = childTable.ToString();

                            oUserObjectMD.ChildTables.Add();
                        }
                    }

              


                    oUserObjectMD.ManageSeries = manageSeries;
                    oUserObjectMD.Code = objectCode;
                    oUserObjectMD.Name = objectName;
                    oUserObjectMD.ObjectType = objectType;
                    oUserObjectMD.TableName = tableName;

                    // SAPbobsCOM.BoUDOObjType.boud_Document ; boud_MasterData boud_MasterData



                    if (oUserObjectMD.Add() != 0)
                        throw new Exception(oCompany.GetLastErrorDescription());
                    else
                        oCompany.EndTransaction(BoWfTransOpt.wf_Commit);

                }
            }
            catch (Exception ex)
            {
                oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
                throw ex;
              
            }

            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserObjectMD);
                oUserObjectMD = null;
                GC.WaitForPendingFinalizers();
                GC.Collect();
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
        ~Sb1UserObjects()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }// fin de la clase

}// fin del namespad
