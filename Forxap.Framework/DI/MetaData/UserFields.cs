using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;
using SAPbouiCOM;
using Forxap.Framework.Constants;
using Forxap.Framework.Utils;

namespace Forxap.Framework.DI
{
    public class Sb1UserFields : Base, IDisposable
    {
        /// <summary>
        ///  metodo para usarlo en el modulo intercompany
        /// </summary>
        /// <param name="oCompany"></param>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldDescription"></param>
        /// <param name="mandatory"></param>
        /// <param name="fieldType"></param>
        /// <param name="size"></param>
        /// <param name="fieldSubType"></param>
        /// <param name="validValues"></param>
        /// <param name="defaultValue"></param>
        /// <param name="linkedTable"></param>
        /// <param name="linkedUDO"></param>
        /// <returns></returns>
        public Sb1Error CreateUserField(SAPbobsCOM.Company oCompany, string tableName, string fieldName, string fieldDescription, BoYesNoEnum mandatory,
            BoFieldTypes fieldType = BoFieldTypes.db_Alpha, int size = 50, BoFldSubTypes fieldSubType = BoFldSubTypes.st_None,
            IDictionary<string, string> validValues = null, string defaultValue = null, string linkedTable = null, string linkedUDO = null)
        {
            UserFieldsMD oUserFieldsMD = null;
            Sb1Error sb1Error = null;
            int fieldID = -1;
            int retCode = -1;
            int errorNumber ;
            //   bool ret = false;
            string errorMessage = string.Empty;
            bool existField = false;

            try
            {
                oUserFieldsMD = oCompany.GetBusinessObject(BoObjectTypes.oUserFields) as UserFieldsMD;

                if (oUserFieldsMD == null)
                    throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));


                existField = GetFieldID(oCompany, tableName, fieldName, ref fieldID);

              //  existField = oUserFieldsMD.GetByKey(tableName, fieldID);
                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                //existField = GetFieldID(oCompany, tableName, fieldName, ref fieldID);

                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                if (!existField)
                {



                    //if (fieldID != 0) return;

                    oUserFieldsMD.TableName = tableName;
                    oUserFieldsMD.Name = fieldName;
                    oUserFieldsMD.Description = fieldDescription;
                    oUserFieldsMD.Type =   fieldType;
                    oUserFieldsMD.SubType =  fieldSubType;
                    oUserFieldsMD.LinkedTable = linkedTable;
                    oUserFieldsMD.LinkedUDO = linkedUDO;
                    // oUserFieldsMD.LinkedSystemObject = BoObjectTypes. .no BoYesNoEnum mandatory, ;
                    oUserFieldsMD.Size = size;
                    oUserFieldsMD.EditSize = size;
                    oUserFieldsMD.DefaultValue = defaultValue;
                    oUserFieldsMD.Mandatory = mandatory;

             


                    if (validValues != null)
                    {
                        foreach (var validValue in validValues)
                        {
                            oUserFieldsMD.ValidValues.Value = validValue.Key;
                            oUserFieldsMD.ValidValues.Description = validValue.Value;
                            oUserFieldsMD.ValidValues.Add();
                        }
                    }


                    // verifico si se agrego de manera correcta el campo a la tabla
                    retCode = oUserFieldsMD.Add();




                    if (retCode != 0)
                    {
                        sb1Error = Utils.Errors.GetLastErrorMessage(oCompany);
                    }
                    else
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(oCompany.CompanyName, errorNumber = 0, string.Format("{0}: {1} {2}", "Campo ", fieldName, ", se creo con exito"));


                    }

                    //quiere decir que no encontro el campo que desean actualizar
                }

                else
                {
                    //quiere decir que no hubo ningun error debe delvolver error 0
                    sb1Error = new Sb1Error(oCompany.CompanyName, errorNumber = 1, string.Format("{0}: {1} {2}", "Campo ", fieldName, ", ya existe"));

                }
            }
            catch (Exception exception)
            {

                sb1Error = Errors.GetLastErrorFromHRException(fieldName, exception);


                // SboApp.Logger.Error("Create Field {tableName}.{fieldName} Error: {ex.Message}", ex);

            }
            finally
            {
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }

            return sb1Error;
        }



        public  Sb1Error  CreateUserField(string tableName, string fieldName, string fieldDescription, BoYesNoEnum mandatory, 
            BoFieldTypes fieldType = BoFieldTypes.db_Alpha, int size = 50, BoFldSubTypes fieldSubType = BoFldSubTypes.st_None,
            IDictionary<string, string> validValues = null, string defaultValue = null, string linkedTable = null, string linkedUDO = null)
        {
            
            UserFieldsMD oUserFieldsMD = null;
            Sb1Error sb1Error = new Sb1Error();
            int fieldID = -1;
            int retCode = -1;
            int errorNumber = 0;
         //   bool ret = false;
            string errorMessage = string.Empty;
            bool existField = false;

            try
            {
                oUserFieldsMD = oCompany.GetBusinessObject(BoObjectTypes.oUserFields) as UserFieldsMD;

                if (oUserFieldsMD == null)
                    throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));


                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                existField = GetFieldID(tableName, fieldName, ref fieldID);


                if (!oCompany.InTransaction)
                    oCompany.StartTransaction();

                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                if (!existField)
                {



                    //if (fieldID != 0) return;

                    oUserFieldsMD.TableName = tableName;
                    oUserFieldsMD.Name = fieldName;
                    oUserFieldsMD.Description = fieldDescription;
                    oUserFieldsMD.Type =    fieldType;
                    oUserFieldsMD.SubType =  fieldSubType;
                    oUserFieldsMD.LinkedTable = linkedTable;
                    oUserFieldsMD.LinkedUDO = linkedUDO;
                    // oUserFieldsMD.LinkedSystemObject = BoObjectTypes. .no BoYesNoEnum mandatory, ;
                    oUserFieldsMD.Size = size;
                    oUserFieldsMD.EditSize = size;
                    oUserFieldsMD.DefaultValue = defaultValue;
                    oUserFieldsMD.Mandatory = mandatory;

                    

                    if (validValues != null)
                    {
                        foreach (var validValue in validValues)
                        {
                            oUserFieldsMD.ValidValues.Value = validValue.Key;
                            oUserFieldsMD.ValidValues.Description = validValue.Value;
                            oUserFieldsMD.ValidValues.Add();
                        }
                    }


                    // verifico si se agrego de manera correcta el campo a la tabla
                    retCode = oUserFieldsMD.Add();




                    if ((retCode != 0) && (retCode != -2035) && (retCode != -1109))
                    {
                        sb1Error = Utils.Errors.GetLastErrorMessage();
                      //  oCompany.EndTransaction(BoWfTransOpt.wf_RollBack);
                    }
                    else
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(oCompany.CompanyName,  errorNumber = 0, string.Format("{0}: {1}", fieldName, errorMessage));
                        oCompany.EndTransaction(BoWfTransOpt.wf_Commit);
                      
                    }

                    //quiere decir que no encontro el campo que desean actualizar
                }
            }
            catch (Exception exception)
            {

                sb1Error = Errors.GetLastErrorFromHRException(fieldName, exception);


                // SboApp.Logger.Error("Create Field {tableName}.{fieldName} Error: {ex.Message}", ex);

            }
            finally
            {
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }

            return sb1Error;
        }


        /// <summary>
        /// Crea un campo dentro de una tabla de usuario
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldDescription"></param>
        /// <param name="fieldType"></param>
        /// <param name="size"></param>
        /// <param name="fieldSubType"></param>
        /// <param name="validValues">Dropdown values</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool CreateUserField(string tableName, string fieldName, string fieldDescription, BoYesNoEnum mandatory, out Sb1Error sb1Error,
            BoFieldTypes fieldType = BoFieldTypes.db_Alpha, int size = 50, BoFldSubTypes fieldSubType = BoFldSubTypes.st_None,
            IDictionary<string, string> validValues = null, string defaultValue = null, string linkedTable =null, string linkedUDO = null)
        {
            UserFieldsMD oUserFieldsMD = null;
            sb1Error = null;
            int fieldID = -1;
            int retCode = -1;
            int errorNumber = 0;
            bool ret = false;
            string errorMessage = string.Empty;
            bool existField = false;

            try
            {
                oUserFieldsMD = oCompany.GetBusinessObject(BoObjectTypes.oUserFields) as UserFieldsMD;

                if (oUserFieldsMD == null)
                    throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));


                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                existField = GetFieldID(tableName, fieldName, ref fieldID);

                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                if (!existField)
                {



                    //if (fieldID != 0) return;

                    oUserFieldsMD.TableName = tableName;
                    oUserFieldsMD.Name = fieldName;
                    oUserFieldsMD.Description = fieldDescription;
                    oUserFieldsMD.Type = fieldType;
                    oUserFieldsMD.SubType = fieldSubType;
                    oUserFieldsMD.LinkedTable = linkedTable;
                    oUserFieldsMD.LinkedUDO = linkedUDO;
                   // oUserFieldsMD.LinkedSystemObject = BoObjectTypes. .no BoYesNoEnum mandatory, ;
                    oUserFieldsMD.Size = size;
                    oUserFieldsMD.EditSize = size;
                    oUserFieldsMD.DefaultValue = defaultValue;
                    oUserFieldsMD.Mandatory = mandatory;
                    

                    if (validValues != null)
                    {
                        foreach (var validValue in validValues)
                        {
                            oUserFieldsMD.ValidValues.Value = validValue.Key;
                            oUserFieldsMD.ValidValues.Description = validValue.Value;
                            oUserFieldsMD.ValidValues.Add();
                        }
                    }


                    // verifico si se agrego de manera correcta el campo a la tabla
                    retCode = oUserFieldsMD.Add();




                    if (retCode != 0)
                    {
                        sb1Error = Utils.Errors.GetLastErrorMessage();
                    }
                    else
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(errorNumber = 0, string.Format("{0}: {1}", fieldName, errorMessage));

                        ret = true;
                    }

                    //quiere decir que no encontro el campo que desean actualizar
                }
            }
            catch (Exception exception)
            {

                   sb1Error= Errors.GetLastErrorFromHRException(fieldName, exception);
                

                // SboApp.Logger.Error("Create Field {tableName}.{fieldName} Error: {ex.Message}", ex);
          
            }
            finally
            {
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }

            return ret;
        }



        /// <summary>
        /// Crea un campo string dentro de una tabla de usuario
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldDescription"></param>
        /// <param name="fieldType"></param>
        /// <param name="size"></param>
        /// <param name="fieldSubType"></param>
        /// <param name="validValues">Dropdown values</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool CreateUserFieldString( string tableName, string fieldName, string fieldDescription,out Sb1Error sb1Error,
            int size = 50, BoFldSubTypes fieldSubType = BoFldSubTypes.st_None,
            IDictionary<string, string> validValues = null, string defaultValue = null )
        {
            bool ret = false;
            UserFieldsMD oUserFieldsMD = null;
            int fieldID = -1;
            int retCode = -1;
            int errorNumber = 0;
            string errorMessage = string.Empty;
            bool existField = false;
            sb1Error = null;
            try
            {
                oUserFieldsMD = oCompany.GetBusinessObject(BoObjectTypes.oUserFields) as UserFieldsMD;

                if (oUserFieldsMD == null)
                    throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));


                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                existField = GetFieldID( tableName, fieldName, ref fieldID);

                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                if (!existField)
                {



                    //if (fieldID != 0) return;

                    oUserFieldsMD.TableName = tableName;
                    oUserFieldsMD.Name = fieldName;
                    oUserFieldsMD.Description = fieldDescription;
                    oUserFieldsMD.Type = BoFieldTypes.db_Alpha;
                    oUserFieldsMD.SubType = fieldSubType;
                    oUserFieldsMD.Size = size;
                    oUserFieldsMD.EditSize = size;
                    oUserFieldsMD.DefaultValue = defaultValue;

                    if (validValues != null)
                    {
                        foreach (var validValue in validValues)
                        {
                            oUserFieldsMD.ValidValues.Value = validValue.Key;
                            oUserFieldsMD.ValidValues.Description = validValue.Value;
                            oUserFieldsMD.ValidValues.Add();
                        }
                    }


                    // verifico si se agrego de manera correcta el campo a la tabla
                    retCode = oUserFieldsMD.Add();




                    if (retCode != 0)
                    {
                        sb1Error = Utils.Errors.GetLastErrorMessage();
                    }
                    else
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(errorNumber = 0, string.Format("{0}: {1}", fieldName, errorMessage));

                        ret = true;
                    }



                   // Utils.Errors.HandleErrorWithException(oCompany, retCode, errorMessage);
                }
            }
            catch (Exception ex)
            {

                sb1Error = Errors.GetLastErrorFromHRException(ex);
                // SboApp.Logger.Error("Create Field {tableName}.{fieldName} Error: {ex.Message}", ex);
            }
            finally
            {
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }


            return ret;
        }

        /// <summary>
        /// Crea un campo dentro de una tabla de usuario
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldDescription"></param>
        /// <param name="fieldType"></param>
        /// <param name="size"></param>
        /// <param name="fieldSubType"></param>
        /// <param name="validValues">Dropdown values</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public void CreateUserFieldTime(string tableName, string fieldName, string fieldDescription, Sb1Error sb1Error)
        {
            UserFieldsMD oUserFieldsMD = null;
            int fieldID = -1;
            int retCode = -1;
            int errorNumber = 0;
            string errorMessage = string.Empty;
            bool existField = false;
            sb1Error = null;

            try
            {
                oUserFieldsMD = oCompany.GetBusinessObject(BoObjectTypes.oUserFields) as UserFieldsMD;

                if (oUserFieldsMD == null)
                    throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));


                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                existField = GetFieldID(tableName, fieldName, ref fieldID);

                /// obtengo el ID del campo dentro de la tabla de SAP
                /// sino existe entonces creo el campo
                if (!existField)
                {



                    //if (fieldID != 0) return;

                    oUserFieldsMD.TableName = tableName;
                    oUserFieldsMD.Name = fieldName;
                    oUserFieldsMD.Description = fieldDescription;
                    oUserFieldsMD.Type = BoFieldTypes.db_Date;
                    oUserFieldsMD.SubType = BoFldSubTypes.st_Time;
                    oUserFieldsMD.Size = 4;
                    oUserFieldsMD.EditSize = 4;


                    //oUserFieldsMD.Type = BoFieldTypes.db_Numeric;
                    //oUserFieldsMD.SubType = BoFldSubTypes.st_None;

                    // verifico si se agrego de manera correcta el campo a la tabla
                    retCode = oUserFieldsMD.Add();




                    if (retCode != 0)
                    {

                        oCompany.GetLastError(out errorNumber, out  errorMessage);

                        // estos errores los deberia mostrar en la interfaz de usuario y enviar a un log propio

                        //resultObject = new ResultObject(errorNumber, string.Format("{0}: {1}", fieldName, errorMessage));

                    }



                    Utils.Errors.HandleErrorWithException(oCompany, retCode, errorMessage);
                }
            }
            catch (Exception ex)
            {
                sb1Error = Errors.GetLastErrorFromHRException(ex);

                // SboApp.Logger.Error("Create Field {tableName}.{fieldName} Error: {ex.Message}", ex);
                throw;
            }
            finally
            {
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }
        }


        public bool UpdateField(string tableName, string fieldName, string fieldDescription,out Sb1Error sb1Error, SAPbobsCOM.BoFieldTypes fieldType, int size = 50, BoFldSubTypes fieldSubType = BoFldSubTypes.st_None,
    IDictionary<string, string> validValues = null, string defaultValue = null)
        {

            
            bool ret = false;
            int retCode = 0;
            int errorNumber = 0;
            string errorMessage = "OK";
            int fieldId = -1;

            SAPbobsCOM.UserFieldsMD oUserFieldsMD = null;

            sb1Error =  null;


            try
            {
                // obtengo el ID del campo dentro de la tabla de SAP
                if (GetFieldID(tableName, fieldName, ref fieldId))
                {
                    oUserFieldsMD = ((UserFieldsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields)));

                    if (oUserFieldsMD == null)
                        throw new NullReferenceException(string.Format("{0}: {1}", Messages.ErrorCreateObject, Messages.UserFieldsMD));




                    if (oUserFieldsMD.GetByKey(tableName, fieldId))
                    {
                        //oUserFieldsMD.TableName = tableName;
                        //oUserFieldsMD.Name = fieldName;
                        oUserFieldsMD.Description = fieldDescription;
                        oUserFieldsMD.Type = fieldType;
                        oUserFieldsMD.SubType = fieldSubType;
                        oUserFieldsMD.Size = size;

                        oUserFieldsMD.EditSize = size;
                        //       oUserFieldsMD.Mandatory = mandatory;
                        oUserFieldsMD.DefaultValue = defaultValue;

                        if (validValues != null)
                        {
                            foreach (var validValue in validValues)
                            {
                                oUserFieldsMD.ValidValues.Value = validValue.Key;
                                oUserFieldsMD.ValidValues.Description = validValue.Value;
                                oUserFieldsMD.ValidValues.Add();
                            }
                        }

                        // actualizo el campo a la tabla
                        retCode = oUserFieldsMD.Update();




                        //quiere decir que existio algun error
                        if (retCode != 0)
                        {
                            sb1Error = Utils.Errors.GetLastErrorMessage();

                        }

                        else
                        {
                            //quiere decir que no hubi ningun error debe delvolver error 0
                            sb1Error = new Sb1Error(errorNumber = 0, string.Format("{0}: {1}", fieldName, errorMessage));

                            ret = true;
                        }
                    }

                }

                else
                {
                    //quiere decir que no encontro el campo que desean actualizar
                    sb1Error = new Sb1Error(errorNumber = -1, string.Format("{0}: {1}", fieldName, errorMessage = "no se encontro"));
                }
            }
            catch (Exception exception)
            {

                sb1Error = Errors.GetLastErrorFromHRException(exception);
            }


            // libero recursos
            finally
            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                oUserFieldsMD = null;
                GC.Collect();

            }


            return ret;

        }// fin del metodo CreateField 



        /// <summary>
        ///  El metodo elimina un campo dentro de una tabla definida por el usuario dentro de SAP
        /// </summary>
        /// <param name="oCompany"></param>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldDescription"></param>
        /// <param name="fieldType"></param>
        /// <param name="fieldSize"></param>
        public bool RemoveUserField( string tableName, string fieldName, out Sb1Error sb1Error)
        {
            int retCode = 0;
            int fieldID = -1;
            bool ret = false;

            sb1Error = null;
            int errorNumber = 0;
            string errorMessage = "OK";

            UserFieldsMD oUserFieldsMD = null;

            try
            {






                if (GetFieldID(tableName, fieldName, ref fieldID))
                {



                    oUserFieldsMD = ((UserFieldsMD)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields)));



                    // si el campo buscado es encontrado, lo elimina
                    if (oUserFieldsMD.GetByKey(tableName, fieldID))
                    {
                        retCode = oUserFieldsMD.Remove();
                    }



                    // si existio algún error
                    if (retCode != 0)
                    {

                        sb1Error = Utils.Errors.GetLastErrorMessage();

                    }

                    //sino existio ningún error debe devolver el número de error 0
                    else
                    {
                        sb1Error = new Sb1Error(errorNumber = 0, string.Format("{0}: {1}", fieldName, errorMessage));
                        ret = true;
                    }

                }// fin si no existe el campo de la tablas


                else
                {
                    // quiere decir que el campo que estan intentando eliminar no existe

                    sb1Error = new Sb1Error(errorNumber = -1, string.Format("{0}: {1}", fieldName, errorMessage = "no se encontro"));
                }
            }
            catch (Exception exception)
            {

                sb1Error = Errors.GetLastErrorFromHRException(exception);
            }

            finally
            {
                // libero recursos
                if (oUserFieldsMD != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserFieldsMD);
                    oUserFieldsMD = null;
                    GC.Collect();
                }
            }


            return ret;
        }// fin del metodo RemoveField 



        /// <summary>
        ///  retorna TRUE si encontro el campo que se esta buscando
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        private static bool GetFieldID(string tableName, string fieldName, ref int fieldID)
        {
            bool ret = false;

            string aliasID = string.Empty;
            //string prefijo = "@";
            SAPbobsCOM.Recordset recordSet = null;


            // con la tabla y el nombre del campo debo obtener el FIELDID con el que se encuentra grabado
            // select FieldId from CUFD where TableId = tableName and AliasID = FieldName

            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException( MessageInfo.Message200);

            try
            {
                //tableName = prefijo + tableName;
              //  tableName = tableName;
              //  string 
                string strSQL = string.Format("Select \"FieldID\" , \"AliasID\" from CUFD where \"TableID\" = '{0}' and \"AliasID\" = '{1}' ", tableName, fieldName);
                recordSet.DoQuery(strSQL);

                if (recordSet.RecordCount > 0)
                {
                    fieldID = Convert.ToInt32(recordSet.Fields.Item("FieldID").Value);
                    aliasID = recordSet.Fields.Item("AliasID").Value.ToString();
                }
            }
            
            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }


            /// recordSet.RecordCount > 0

            if (aliasID.Length > 0)
                ret = true;

            return ret;
        }



        /// <summary>
        ///  retorna TRUE si encontro el campo que se esta buscando
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        private static bool GetFieldID(SAPbobsCOM.Company oCompany, string tableName, string fieldName, ref int fieldID)
        {
            bool ret = false;

            string aliasID = string.Empty;
            //string prefijo = "@";
            SAPbobsCOM.Recordset recordSet = null;


            // con la tabla y el nombre del campo debo obtener el FIELDID con el que se encuentra grabado
            // select FieldId from CUFD where TableId = tableName and AliasID = FieldName

            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException(Forxap.Framework.Constants.MessageInfo.Message200);

            try
            {
                //tableName = prefijo + tableName;
                //  tableName = tableName;
                string strSQL = "''";
                tableName = "@" + tableName;

                strSQL = string.Format("Select  \"FieldID\", \"AliasID\" from CUFD where \"TableID\" = '{0}' and \"AliasID\" = '{1}' ",  tableName, fieldName);

                recordSet.DoQuery(strSQL);


                fieldID = Convert.ToInt32(recordSet.Fields.Item("FieldID").Value);
                aliasID = recordSet.Fields.Item("AliasID").Value.ToString();
            }
                catch (Exception ex)
                {
                    throw ex;
                }

            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }


            /// recordSet.RecordCount > 0

            if (aliasID.Length > 0)
                ret = true;

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
        ~Sb1UserFields()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase

}// fin del namespace
