using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

using System.Windows.Forms;
using Forxap.Framework.DI;
using Forxap.Framework.DI.QueryManager;

namespace Forxap.Framework.Utils
{
   public   class Sb1XmlFile : Base
    {

       /// <summary>
       ///  Lee las tablas de usuario desde un archivo xml
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadUserTables(string xmlFile)
       {
           XmlDocument xmlDocument = new XmlDocument();
           Sb1UserTables userTables = new Sb1UserTables();


           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);


               /// cargo el nodo con toda la lista de las tablas
               XmlNodeList nodeListTables = xmlDocument.GetElementsByTagName("UserTables");

               ///obtengo una de las tablas
               XmlNodeList nodeListTable = ((XmlElement)nodeListTables[0]).GetElementsByTagName("UserTablesMD");

               /// recorro los nodos de una tabla
               foreach (XmlElement nodo in nodeListTable)
               {

                   int i = 0;

                   // puedo leer los atributos asi leo el codigo de la tabla y la decripción
                   XmlAttributeCollection nodoAtributos =  nodo.Attributes;

                   XmlNodeList nTableName = nodo.GetElementsByTagName("TableName");

                   XmlNodeList nTableDescription = nodo.GetElementsByTagName("TableDescription");

                   XmlNodeList nTableType = nodo.GetElementsByTagName("TableType");

                   XmlNodeList nArchivable = nodo.GetElementsByTagName("Archivable");
                   XmlNodeList nArchiveDateField = nodo.GetElementsByTagName("ArchiveDateField"); 


                   Sb1Error sb1Error = userTables.CreateUserTable
                       (
                       nTableName[i].InnerText.Trim(), 
                       nTableDescription[i].InnerText.Trim(), 
                       (SAPbobsCOM.BoUTBTableType)Enum.Parse(typeof(SAPbobsCOM.BoUTBTableType),nTableType[i].InnerText),
                       (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum),nArchivable[i].InnerText),
                        nArchiveDateField[i].InnerText.Trim()
                       );

                   if (sb1Error.Code == 0)
                       Forxap.Framework.UI.Sb1Messages.ShowSuccess("Tabla : " + sb1Error.Message);
                   else
                       Forxap.Framework.UI.Sb1Messages.ShowWarning("Error: " + sb1Error.Code + sb1Error.Message);
               }

           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile +  " Archivo no existe");
           }


       }
       /// <summary>
       /// lee campos de usuarios desde un archivo xml 
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadUserFields(string xmlFile)
       {
           XmlDocument xmlDocument = new XmlDocument();
           Sb1UserFields userFields = new Sb1UserFields();

           string fieldName = string.Empty;
           string fieldType = string.Empty;
           int size = 0;
           string fieldDescription = string.Empty;

           string fieldSubType = string.Empty;
           string linkedTable = string.Empty;
           string defaultValue = string.Empty;
           string tableName = string.Empty;
           int fieldID = 0;
           string mandatory = string.Empty;
           int editSize = 0;

           string linkedUDO = string.Empty;
           IDictionary<string, string> validValues = null; 


           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               try
               {
                   // si el archivo existe entonces lo intenta leer
                   xmlDocument.Load(xmlFile);

                   /// cargo el nodo con toda la lista de los campos
                   XmlNodeList nodeListFields = xmlDocument.GetElementsByTagName("UserFields");

                   ///obtengo uno de los campos
                   XmlNodeList nodeListField = ((XmlElement)nodeListFields[0]).GetElementsByTagName("Field");

                   
                   /// recorro los nodos de un campo
                   foreach (XmlElement nodo in nodeListField)
                   {

                       
                       int i = 0;

                       XmlNodeList nUserFieldsMD = nodo.GetElementsByTagName("UserFieldsMD");

                       fieldName = string.Empty;
                       fieldType = string.Empty;
                       size = 0;
                       fieldDescription = string.Empty;
                       fieldSubType = string.Empty;
                       linkedTable = string.Empty;
                       defaultValue = string.Empty;
                       tableName = string.Empty;
                       fieldID = 0;
                       mandatory = string.Empty;
                       editSize = 0;

                       linkedUDO = string.Empty;
                       validValues= null ; 

                       foreach (XmlElement nodo1 in nUserFieldsMD)
                       {
                         XmlNodeList nFieldName = nodo1.GetElementsByTagName("FieldName");
                         XmlNodeList nType = nodo1.GetElementsByTagName("Type");
                         XmlNodeList nSize = nodo1.GetElementsByTagName("Size");
                         XmlNodeList nDescription = nodo1.GetElementsByTagName("Description");
                         XmlNodeList nSubType = nodo1.GetElementsByTagName("SubType");
                         XmlNodeList nLinkedTable = nodo1.GetElementsByTagName("LinkedTable");
                         XmlNodeList nDefaultValue = nodo1.GetElementsByTagName("DefaultValue");
                         XmlNodeList nTableName = nodo1.GetElementsByTagName("TableName");
                         XmlNodeList nFieldID = nodo1.GetElementsByTagName("FieldID");
                         
                         XmlNodeList nEditSize = nodo1.GetElementsByTagName("EditSize");
                         XmlNodeList nMandatory = nodo1.GetElementsByTagName("Mandatory");

                         

                         fieldName = nFieldName[i].InnerText.Trim();
                         fieldType = nType[i].InnerText.Trim();
                         size = Convert.ToInt32( nSize[i].InnerText.Trim());
                         fieldDescription = nDescription[i].InnerText.Trim();
                         fieldSubType = nSubType[i].InnerText.Trim();
                         linkedTable = nLinkedTable[i].InnerText.Trim()?? string.Empty;
                         defaultValue = nDefaultValue[i].InnerText.Trim();
                         tableName = nTableName[i].InnerText.Trim();
                         fieldID = Convert.ToInt32( nFieldID[i].InnerText.Trim());
                         mandatory = nMandatory[i].InnerText.Trim(); 
                         editSize = Convert.ToInt32( nEditSize[i].InnerText.Trim());                       }

                       
                       
                       nUserFieldsMD.Item(0).InnerText.Trim().ToString();

                       string a = nodo.GetElementsByTagName("UserFieldsMD").Item(0).InnerText;
                       
                       XmlNodeList nValidValuesMD = nodo.GetElementsByTagName("ValidValuesMD");

                       foreach (XmlElement nodo2 in nValidValuesMD)
                       {
                           XmlNodeList nRows = nodo2.GetElementsByTagName("row");

                           
                           string valueRow = string.Empty;
                           string descriptionRow = string.Empty;
                           validValues = new Dictionary<string, string>();

                           foreach (XmlElement nRow in nRows)
                           {
                               XmlNodeList nValue = nRow.GetElementsByTagName("Value");
                               XmlNodeList nDescription = nRow.GetElementsByTagName("Description");

                               valueRow = nValue[i].InnerText.Trim();
                               descriptionRow = nDescription[i].InnerText.Trim();
               
                               validValues.Add(valueRow,descriptionRow);
                           }
                       }


                       Sb1Error sb1Error = userFields.CreateUserField
                           (
                           tableName, 
                           fieldName, 
                           fieldDescription, 
                           (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), mandatory), 
                           ((SAPbobsCOM.BoFieldTypes)Enum.Parse(typeof(SAPbobsCOM.BoFieldTypes), fieldType)), 
                           size, 
                           ((SAPbobsCOM.BoFldSubTypes)Enum.Parse(typeof(SAPbobsCOM.BoFldSubTypes), fieldSubType)), 
                           validValues, 
                           defaultValue, 
                           linkedTable, 
                           linkedUDO
                           );


                       if (sb1Error.Code == 0)
                           Forxap.Framework.UI.Sb1Messages.ShowSuccess("Campo : " + sb1Error.Message);
                       else if ((sb1Error.Code != -2035) && (sb1Error.Code != -1109)) 
                           Forxap.Framework.UI.Sb1Messages.ShowWarning("Error: " + sb1Error.Code + sb1Error.Message);
                   }



               }
               catch (Exception exception)
               {
                   Sb1Error sb1Error = Errors.GetLastErrorFromHRException(fieldName, exception); 
               }
               
           }
           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }

       }
       public static void LoadUserTables(string xmlFile, out SAPbouiCOM.DataTable oDataTable)
       {
           XmlDocument xmlDocument = new XmlDocument();
           Sb1UserTables userTables = new Sb1UserTables();

           oDataTable = null;


           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);


               /// cargo el nodo con toda la lista de las tablas
               XmlNodeList nodeListTables = xmlDocument.GetElementsByTagName("UserTables");

               ///obtengo una de las tablas
               XmlNodeList nodeListTable = ((XmlElement)nodeListTables[0]).GetElementsByTagName("UserTablesMD");

               /// recorro los nodos de una tabla
               foreach (XmlElement nodo in nodeListTable)
               {

                   int i = 0;

                   // puedo leer los atributos asi leo el codigo de la tabla y la decripción
                   XmlAttributeCollection nodoAtributos = nodo.Attributes;

                   XmlNodeList nTableName = nodo.GetElementsByTagName("TableName");

                   XmlNodeList nTableDescription = nodo.GetElementsByTagName("TableDescription");

                   XmlNodeList nTableType = nodo.GetElementsByTagName("TableType");

                   XmlNodeList nArchivable = nodo.GetElementsByTagName("Archivable");
                   XmlNodeList nArchiveDateField = nodo.GetElementsByTagName("ArchiveDateField");


                   Sb1Error sb1Error = userTables.CreateUserTable
                       (
                       nTableName[i].InnerText.Trim(),
                       nTableDescription[i].InnerText.Trim(),
                       (SAPbobsCOM.BoUTBTableType)Enum.Parse(typeof(SAPbobsCOM.BoUTBTableType), nTableType[i].InnerText),
                       (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), nArchivable[i].InnerText),
                        nArchiveDateField[i].InnerText.Trim()
                       );

                   if (sb1Error.Code == 0)
                       Forxap.Framework.UI.Sb1Messages.ShowSuccess("Tabla : " + sb1Error.Message);
                   else
                       Forxap.Framework.UI.Sb1Messages.ShowWarning("Error: " + sb1Error.Code + sb1Error.Message);
               }

           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }


       }
       /// <summary>
       ///  lee el menu desde un archivo xml
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadAddonMenu(string xmlFile)
       {
           try
           {
               //  
               XmlDocument xmlDocument = new System.Xml.XmlDocument();
               string stringXML = string.Empty;

               // verificar que el archivo exista
               if (File.Exists(xmlFile))
               {
                   xmlDocument.Load(xmlFile);
                   stringXML = xmlDocument.InnerXml;

                   oApplication.LoadBatchActions(ref stringXML);


               }

               else
               {
                   Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
               }
               
           }
           catch (Exception ex)
           {  
             oApplication.SetStatusBarMessage(ex.Message.ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, true);
           }
       }
       /// <summary>
       /// lee objetos de usuarios desde un archivo XML 
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadUserObject(string xmlFile)
       {

           XmlDocument xmlDocument = new XmlDocument();
           Sb1UserObjects sb1UserObjects = new Sb1UserObjects();

           List<string> childTables = null;
           
           IDictionary<string, string> formColumns = null;
           IDictionary<string, string> findColumns = null; 


           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);


               
               /// cargo el nodo con toda la lista de los objetos
               XmlNodeList nodeListObjects = xmlDocument.GetElementsByTagName("UserObjects");

               ///obtengo uno de los objetos
               XmlNodeList nodeListObject = ((XmlElement)nodeListObjects[0]).GetElementsByTagName("UserObject");

                   

               /// recorro los nodos de un Objeto
               foreach (XmlElement nodo in nodeListObject)
               {

                   int i = 0;

                   XmlNodeList nCanCancel = nodo.GetElementsByTagName("CanCancel");
                   string canCancel = nCanCancel[i].InnerText.Trim();

                   XmlNodeList nCanClose = nodo.GetElementsByTagName("CanClose");
                   string canClose = nCanClose[i].InnerText.Trim();

                   XmlNodeList nCanDelete = nodo.GetElementsByTagName("CanDelete");
                   string canDelete = nCanDelete[i].InnerText.Trim();

                   XmlNodeList nCanFind = nodo.GetElementsByTagName("CanFind");
                   string canFind = nCanFind[i].InnerText.Trim();

                   XmlNodeList nCanYearTransfer = nodo.GetElementsByTagName("CanYearTransfer");
                   string canYearTransfer = nCanYearTransfer[i].InnerText.Trim();

                   XmlNodeList nCanApprove = nodo.GetElementsByTagName("CanApprove");
                   string canApprove = nCanApprove[i].InnerText.Trim();

                   XmlNodeList nCanArchive = nodo.GetElementsByTagName("CanArchive");
                   string canArchive = nCanArchive[i].InnerText.Trim();

                   XmlNodeList nCanLog = nodo.GetElementsByTagName("CanLog");
                   string canLog = nCanLog[i].InnerText.Trim();

                   XmlNodeList nCanCreateDefaultForm = nodo.GetElementsByTagName("CanCreateDefaultForm");
                   string canCreateDefaultForm = nCanCreateDefaultForm[i].InnerText.Trim();


                   XmlNodeList nEnableEnhancedForm = nodo.GetElementsByTagName("EnableEnhancedForm");
                   string enableEnhancedForm = nEnableEnhancedForm[i].InnerText.Trim();

                   
                   



                   XmlNodeList nObjectType = nodo.GetElementsByTagName("ObjectType");
                   string objectType = nObjectType[i].InnerText.Trim();

                   


                   XmlNodeList nTableName = nodo.GetElementsByTagName("TableName");
                   string tableName = nTableName[i].InnerText.Trim();

                   XmlNodeList nLogTableName = nodo.GetElementsByTagName("LogTableName");
                   string logTableName = nLogTableName[i].InnerText.Trim();

                   XmlNodeList nChildTables = null;
                   nChildTables = nodo.GetElementsByTagName("ChildTables");

                   XmlNodeList nFindColumns = null;
                   nFindColumns = nodo.GetElementsByTagName("FindColumns");

                   XmlNodeList nFormColumns = null;
                   nFormColumns = nodo.GetElementsByTagName("FormColumns");

               

                   

                   XmlNodeList nObjectCode = nodo.GetElementsByTagName("ObjectCode");
                   string objectCode = nObjectCode[i].InnerText.Trim();

                   XmlNodeList nObjectName = nodo.GetElementsByTagName("ObjectName");
                   string objectName = nObjectName[i].InnerText.Trim();

                   XmlNodeList nManageSeries = nodo.GetElementsByTagName("ManageSeries");
                   string manageSeries = nManageSeries[i].InnerText.Trim();

  
                   XmlNodeList nFatherMenuID = nodo.GetElementsByTagName("FatherMenuID");
                   int  fatherMenuID = 0;
                   if  (nFatherMenuID[i].InnerText.Trim().Length > 0)
                       fatherMenuID = Convert.ToInt32(nFatherMenuID[i].InnerText.Trim());

                   XmlNodeList nMenuID = nodo.GetElementsByTagName("MenuID");
                   string menuID = nMenuID[i].InnerText.Trim();

                   //XmlNodeList nMenuCaption = nodo.GetElementsByTagName("MenuCaption");
                   //string menuCaption = nMenuCaption[i].InnerText.Trim();


                   //XmlNodeList nChildTables = nodo.GetElementsByTagName("ChildTables");

                   childTables = null;
                   
                   //recorro el listao de tablas hijas que forman el objeto
                   foreach (XmlElement nodo2 in nChildTables)
                   {
                       XmlNodeList nRows = nodo2.GetElementsByTagName("row");



                       
                       childTables = new List<string>();

                       foreach (XmlElement nRow in nRows)
                       {
                           string tableNameChild = string.Empty;

                           XmlNodeList nValue = nRow.GetElementsByTagName("TableName");


                           tableNameChild = nValue[i].InnerText.Trim();


                           childTables.Add(tableNameChild);
                       }
                   }

                   //recorro el listado de campos que seran criterios de busqueda que forman el objeto
                   foreach (XmlElement nodo2 in nFindColumns)
                   {
                       XmlNodeList nRows = nodo2.GetElementsByTagName("row");


                       string lineIDRow = string.Empty;
                       string columnAliasRow = string.Empty;


                       findColumns = new Dictionary<string, string>();

                       foreach (XmlElement nRow in nRows)
                       {
                           XmlNodeList nLineID = nRow.GetElementsByTagName("LineID");
                           XmlNodeList nColumnAlias = nRow.GetElementsByTagName("ColumnAlias");

                           lineIDRow = nLineID[i].InnerText.Trim();
                           columnAliasRow = nColumnAlias[i].InnerText.Trim();

                           findColumns.Add(lineIDRow, columnAliasRow);
                       }



                   }



                   //recorro el listado de campos que seran parte del formulario de tipo Matrix 
                   foreach (XmlElement nodo2 in nFormColumns)
                   {
                       XmlNodeList nRows = nodo2.GetElementsByTagName("row");


                       string columnAlias = string.Empty;
                       string columnDescription = string.Empty;


                       formColumns = new Dictionary<string, string>();

                       foreach (XmlElement nRow in nRows)
                       {
                           XmlNodeList nColumnAlias = nRow.GetElementsByTagName("FormColumnAlias");
                           XmlNodeList nColumnDescription = nRow.GetElementsByTagName("FormColumnDescription");

                           columnAlias       =      nColumnAlias[i].InnerText.Trim();
                           columnDescription =      nColumnDescription[i].InnerText.Trim();

                           formColumns.Add(columnAlias, columnDescription);
                       }



                   }



                   SAPbobsCOM.BoUDOObjType boUDOObjType = (SAPbobsCOM.BoUDOObjType)Enum.Parse(typeof(SAPbobsCOM.BoUDOObjType), objectType);


                   SAPbobsCOM.BoYesNoEnum  CanCancel = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canCancel);
                   SAPbobsCOM.BoYesNoEnum  CanClose = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canClose);
                   SAPbobsCOM.BoYesNoEnum  CanCreateDefaultForm = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canCreateDefaultForm);
                   SAPbobsCOM.BoYesNoEnum  EnableEnhancedForm = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), enableEnhancedForm); 
                   SAPbobsCOM.BoYesNoEnum  CanDelete = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canDelete);
                   SAPbobsCOM.BoYesNoEnum  CanFind = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canFind);
                   SAPbobsCOM.BoYesNoEnum  CanYearTransfer = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canYearTransfer);
                   SAPbobsCOM.BoYesNoEnum  CanApprove = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canApprove);
                   SAPbobsCOM.BoYesNoEnum  CanArchive = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canArchive);
                   SAPbobsCOM.BoYesNoEnum  CanLog = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), canLog);

                   

                   SAPbobsCOM.BoYesNoEnum  ManageSeries = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), manageSeries); 
                   
                

                    sb1UserObjects.AddUDO
                       (
                       CanCancel,
                       CanClose,
                       CanCreateDefaultForm,
                       CanDelete,
                       CanFind,

                       CanYearTransfer,
                       CanApprove,
                       CanArchive,
                       EnableEnhancedForm,
                       CanLog,
                       ManageSeries,
                       objectCode,
                       objectName,
                       tableName,
                       findColumns,
                       formColumns,
                       
                       logTableName,
                       childTables,
                       boUDOObjType

                       
                       );

          
               }

           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }


       }
       /// <summary>
       /// lee los permisos de usuarios desde un archivo XML 
       /// </summary>
       /// <param name="xmlFile"></param>
       public static Sb1Error LoadUserPermission(string xmlFile)
       {
           XmlDocument xmlDocument = new XmlDocument();
           Sb1Error sb1Error = new Sb1Error();
           Sb1UserPermissions sb1UserPermissions = new Sb1UserPermissions();

    
           List<string> formTypes = null;
           List<string> listForms = null;


              // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);

               /// cargo el nodo con toda la lista de los permisos
               XmlNodeList nodeListPermissions = xmlDocument.GetElementsByTagName("UserPermissions");

               ///obtengo la lista de los permisos 
               XmlNodeList nodeListPermission = ((XmlElement)nodeListPermissions[0]).GetElementsByTagName("UserPermission");


                 /// recorro los nodos de un Objeto
               foreach (XmlElement nodo in nodeListPermission)
               {
                   int i = 0;

                   XmlNodeList nPermissionId = nodo.GetElementsByTagName("PermissionId");
                   string permissionId = nPermissionId[i].InnerText.Trim();

                   XmlNodeList nName = nodo.GetElementsByTagName("Name");
                   string permissionName = nName[i].InnerText.Trim();

                   XmlNodeList nOptions = nodo.GetElementsByTagName("Options");
                   string options = nOptions[i].InnerText.Trim();

                   XmlNodeList nLevel = nodo.GetElementsByTagName("Level");
                   int level = -1;
                   if (nLevel[i].InnerText.Trim().Length > 0)
                   {
                        level = Convert.ToInt32(nLevel[i].InnerText.Trim());
                   }
                   XmlNodeList nParentID = nodo.GetElementsByTagName("ParentID");
                   string parentID = nParentID[i].InnerText.Trim();

                   XmlNodeList nForms = nodo.GetElementsByTagName("Forms");


                   foreach (XmlElement nodo2 in nForms)
                   {
                       XmlNodeList nRows = nodo2.GetElementsByTagName("row");




                       listForms = new List<string>();

                       foreach (XmlElement nRow in nRows)
                       {
                           string formName = string.Empty;

                           XmlNodeList nValue = nRow.GetElementsByTagName("Form");


                           formName = nValue[i].InnerText.Trim();


                           listForms.Add(formName);
                       }
                   }


                   SAPbobsCOM.BoUPTOptions  boUPTOptions = (SAPbobsCOM.BoUPTOptions)Enum.Parse(typeof(SAPbobsCOM.BoUPTOptions), options);


                   sb1UserPermissions.CreatePermission
                       (
                        permissionId,
                        permissionName,
                        boUPTOptions,
                        parentID,
                        listForms,
                        level

                       );
                      // userObjects.AddUDO

               }
           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }
           return sb1Error;
       }
       /// <summary>
       /// lee los permisos de usuarios desde un archivo XML 
       /// </summary>
       /// <param name="xmlFile"></param>
       public static Sb1Error LoadUserScripts(string xmlFile)
       {
           XmlDocument xmlDocument = new XmlDocument();
           
           Sb1Error sb1Error = new Sb1Error();
           Sb1QueryCategory sb1QueryCategory = new Sb1QueryCategory();
           Sb1QueryUser sb1UserQuery = new Sb1QueryUser();
           Sb1ProcedureUser sb1ProcedureUser = new Sb1ProcedureUser();

           

           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);

               /// cargo el nodo con toda la lista de los user scripts
               XmlNodeList nodeListUserScripts = xmlDocument.GetElementsByTagName("UserScripts");

               ///obtengo la lista de las Categorias 
               XmlNodeList nodeListCategories = ((XmlElement)nodeListUserScripts[0]).GetElementsByTagName("UserCategory");

               ///obtengo la lista de los Queries 
               XmlNodeList nodeListQueries = ((XmlElement)nodeListUserScripts[0]).GetElementsByTagName("UserQuery");

               ///obtengo la lista de los stored procedures 
               XmlNodeList nodeListStoredProcedures = ((XmlElement)nodeListUserScripts[0]).GetElementsByTagName("UserProcedure");



               /// recorro los nodos de las categorias
               foreach (XmlElement nodo in nodeListCategories)
               {
           

                   XmlNodeList nCategoryName = nodo.GetElementsByTagName("CategoryName");
                   string categoryName = nCategoryName[0].InnerText.Trim();

                   sb1QueryCategory.CreateCategory
                       (
                        categoryName,
                        out sb1Error
                       );

               }/// fin de las categorias



               /// recorro los nodos de los querys
               foreach (XmlElement nodo in nodeListQueries)
               {


                   XmlNodeList nCategoryName = nodo.GetElementsByTagName("CategoryName");
                   string categoryName = nCategoryName[0].InnerText.Trim();

                   XmlNodeList nQueryName = nodo.GetElementsByTagName("QueryName");
                   string queryName = nQueryName[0].InnerText.Trim();

                   XmlNodeList nFileName = nodo.GetElementsByTagName("FileName");
                   string fileName = nFileName[0].InnerText.Trim();

                   string serverType =  Forxap.Framework.Base.oCompany.DbServerType.ToString();

           

                   string pathFileName = System.Windows.Forms.Application.StartupPath;
    

                   if (serverType.Contains("Hana"))
                   {
                       pathFileName +=  Constants.UserFiles.FolderHana;
                       pathFileName += fileName; 
                   }

                   else if (serverType.Contains("SQL"))
                   {

                       pathFileName += Constants.UserFiles.FolderSQL;
                       pathFileName += fileName;

                   }


              
                   sb1UserQuery.CreateQuery
                  
                       (
                        categoryName,
                        queryName,
                        pathFileName,

                        out sb1Error
                       );

               }/// fin de los querys


               /// recorro los nodos de los storedProcedures
               foreach (XmlElement nodo in nodeListStoredProcedures)
               {



                   XmlNodeList nFileName = nodo.GetElementsByTagName("FileName");
                   string fileName = string.Empty;

                   string serverType = Forxap.Framework.Base.oCompany.DbServerType.ToString();



               
                   foreach (XmlElement file in nFileName)
                   {
                       string pathFileName = System.Windows.Forms.Application.StartupPath;


                       if (serverType.Contains("HANA"))
                       {
                           // pathFileName += Constants.UserFiles.FolderHana;
                            pathFileName += Constants.UserFiles.FolderHana;
                            pathFileName += fileName;
                       }

                       else if (serverType.Contains("SQL"))
                       {

                           pathFileName += Constants.UserFiles.FolderSQL;
                           pathFileName += fileName;

                       }
                       pathFileName += file.InnerText.Trim();
                       try
                       {


                           sb1ProcedureUser.CreateProcedure

                               (
                                pathFileName,
                                out sb1Error
                               );

                       }
                       catch (Exception ex)
                       {

                           if (Errors.GetLastErrorFromHRException(ex).Code == -7202)
                               Forxap.Framework.UI.Sb1Messages.ShowMessageBox(Errors.GetLastErrorFromHRException(ex).Message);


                       }

                   }
               }/// fin de los stored procedure

               
           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }
           return sb1Error;
       }
       /// <summary>
       ///  Lee los procedimientos almacenados desde un archivo xml
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadUserProcedures(string xmlFile)
       {
           XmlDocument xmlDocument = new XmlDocument();
           Sb1UserTables userTables = new Sb1UserTables();


           // verificar que el archivo exista
           if (File.Exists(xmlFile))
           {
               // si el archivo existe entonces lo intenta leer
               xmlDocument.Load(xmlFile);


               /// cargo el nodo con toda la lista de los procedures
               XmlNodeList nodeListTables = xmlDocument.GetElementsByTagName("UserProcedures");

               ///obtengo una de los procedures
               XmlNodeList nodeListTable = ((XmlElement)nodeListTables[0]).GetElementsByTagName("UserProcedureMD");

               /// recorro los nodos de un procedure
               foreach (XmlElement nodo in nodeListTable)
               {

                   int i = 0;

                   XmlNodeList nProcedureName = nodo.GetElementsByTagName("ProcedureName");
                   XmlNodeList nProcedureDescription = nodo.GetElementsByTagName("ProcedureDescription");
                   XmlNodeList nFileName = nodo.GetElementsByTagName("FileName");
                   XmlNodeList nVersion = nodo.GetElementsByTagName("Version");
                   XmlNodeList nCreateDate = nodo.GetElementsByTagName("CreateDate");


                   Sb1Error sb1Error = userTables.CreateUserTable
                       (
                       nProcedureName[i].InnerText.Trim(),
                       nProcedureDescription[i].InnerText.Trim(),
                       (SAPbobsCOM.BoUTBTableType)Enum.Parse(typeof(SAPbobsCOM.BoUTBTableType), nFileName[i].InnerText),
                       (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), nCreateDate[i].InnerText),
                        nCreateDate[i].InnerText.Trim()
                       );

                   if (sb1Error.Code == 0)
                       Forxap.Framework.UI.Sb1Messages.ShowSuccess("Procedure : " + sb1Error.Message);
                   else
                       Forxap.Framework.UI.Sb1Messages.ShowWarning("Error: " + sb1Error.Code + sb1Error.Message);
               }

           }

           else
           {
               Forxap.Framework.UI.Sb1Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
           }


       }
       /// <summary>
       ///  Leo el Icono del Addon 
       /// </summary>
       /// <param name="xmlFile"></param>
       public static void LoadAddonIcon(string iconFile , string addonMenuItem)
       {
            try
            {

            

               string path = string.Empty;
               SAPbouiCOM.MenuItem oMenuItem;
               path = System.Windows.Forms.Application.StartupPath;
               path += iconFile;

               oMenuItem = SAPbouiCOM.Framework.Application.SBO_Application.Menus.Item(addonMenuItem);
               oMenuItem.Image = path;
            }
            catch (Exception ex)
            {
                
            }
        }
    }// fin de la clase

}// fin del namespace
