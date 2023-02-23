using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;

namespace Forxap.Framework.DI.QueryManager
{
    public class FormattedSearches :Base
    {

        /// <summary>
        /// Seta o FormattedSearch no campo desejado
        /// </summary>
        /// <param name="queryName">Nome da Query</param>
        /// <param name="queryBody">Query</param>
        /// <param name="formID">ID do form</param>
        /// <param name="itemID">ID do item</param>
        /// <param name="colID">ID da coluna (Default -1)</param>
        /// <returns></returns>
        public bool AssignFormattedSearch(string queryName, string queryBody, string formID, string itemID, string colID = "-1")
        {
            bool functionReturnValue = false;
            functionReturnValue = false;

            SAPbobsCOM.Recordset oRS = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            SAPbobsCOM.FormattedSearches oFormattedSearches = (SAPbobsCOM.FormattedSearches)oCompany.GetBusinessObject(BoObjectTypes.oFormattedSearches);

            try
            {
                string sql = @"SELECT * FROM CSHS T0
	                        INNER JOIN OUQR T1
		                        ON T0.QueryId = T1.IntrnalKey
	                        WHERE T0.FormID = '{0}' 
	                        AND T0.ItemId	= '{1}' 
	                        AND T0.ColID	= '{2}' ";

                //sql =  SBOApp.TranslateToHana(sql);
                oRS.DoQuery(String.Format(sql, formID, itemID, colID));
                if (oRS.RecordCount == 0)
                {
                    int QueryID;
                    QueryID = CreateQuery(queryName, queryBody);
                    oFormattedSearches.Action = BoFormattedSearchActionEnum.bofsaQuery;
                    oFormattedSearches.FormID = formID;
                    oFormattedSearches.ItemID = itemID;
                    oFormattedSearches.ColumnID = colID;
                    oFormattedSearches.QueryID = QueryID;
                    oFormattedSearches.FieldID = itemID;
                    if (colID == "-1")
                    {
                        oFormattedSearches.ByField = BoYesNoEnum.tYES;
                    }
                    else
                    {
                        oFormattedSearches.ByField = BoYesNoEnum.tNO;
                    }

                    long lRetCode = oFormattedSearches.Add();
                    if (lRetCode == -2035)
                    {
                        //sql =  SBOApp.TranslateToHana(sql);
                        oRS.DoQuery("SELECT TOP 1 T0.IndexID FROM [dbo].[CSHS] T0 WHERE T0.FormID='" + formID + "' AND T0.ItemId='" + itemID + "' AND T0.ColID='" + colID + "'");

                        if (oRS.RecordCount > 0)
                        {
                            oFormattedSearches.GetByKey((int)oRS.Fields.Item(0).Value);
                            oFormattedSearches.Action = BoFormattedSearchActionEnum.bofsaQuery;
                            oFormattedSearches.FormID = formID;
                            oFormattedSearches.ItemID = itemID;
                            oFormattedSearches.ColumnID = colID;
                            oFormattedSearches.QueryID = QueryID;
                            oFormattedSearches.FieldID = itemID;
                            if (colID == "-1")
                            {
                                oFormattedSearches.ByField = BoYesNoEnum.tYES;
                            }
                            else
                            {
                                oFormattedSearches.ByField = BoYesNoEnum.tNO;
                            }
                            lRetCode = oFormattedSearches.Update();
                        }
                    }
                    if (lRetCode != 0)
                    {
                        throw new Exception(String.Format("Error al crear búsqueda formateada {0}: {1}", queryName, oCompany.GetLastErrorDescription()));
                    }
                }

                functionReturnValue = true;
            }
            catch
            {
                throw new Exception(String.Format("Error al crear query {0}: {1}", queryName, oCompany.GetLastErrorDescription()));
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
                oRS = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oFormattedSearches);
                oFormattedSearches = null;
                GC.Collect();
            }
            return functionReturnValue;
        }




        public bool ExistsQuery(string query)
        {
            query = query.Replace("'", "''");
            bool exists = false;
            string sql = "SELECT TOP 1 1 FROM OUQR WHERE CAST(QString AS NVARCHAR(MAX)) = '{0}'";
            sql = String.Format(sql, query);

            SAPbobsCOM.Recordset oRS = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            //sql = SBOApp.TranslateToHana(sql);
            oRS.DoQuery(sql);

            if (oRS.RecordCount > 0)
            {
                exists = true;
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
            oRS = null;
            GC.Collect();
            return exists;
        }

        public int CreateQuery(string QueryName, string TheQuery)
        {
            int functionReturnValue = 0;
            functionReturnValue = -1;
            SAPbobsCOM.Recordset oRS = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            SAPbobsCOM.UserQueries oQuery = (SAPbobsCOM.UserQueries)oCompany.GetBusinessObject(BoObjectTypes.oUserQueries);

            try
            {
                //SBOApp.TranslateToHana("SELECT TOP 1 INTRNALKEY FROM OUQR WHERE QCATEGORY=" + GetSysCatID() + " AND QNAME='" + QueryName + "'");
                oRS.DoQuery("SELECT TOP 1 INTRNALKEY FROM OUQR WHERE QCATEGORY=" + GetSysCatID() + " AND QNAME='" + QueryName + "'");
                if (oRS.RecordCount > 0)
                {
                    functionReturnValue = (int)oRS.Fields.Item(0).Value;
                }
                else
                {
                    oQuery.QueryCategory = GetSysCatID();
                    oQuery.QueryDescription = QueryName;
                    oQuery.Query = TheQuery;
                    if (oQuery.Add() != 0)
                    {
                        throw new Exception(String.Format("Error al  crear query {0}: {1}", QueryName, oCompany.GetLastErrorDescription()));
                    }
                    string newKey = oCompany.GetNewObjectKey();
                    if (newKey.Contains('\t'))
                    {
                        newKey = newKey.Split('\t')[0];
                    }
                    functionReturnValue = Convert.ToInt32(newKey);
                }
            }
            catch
            {
                throw new Exception(String.Format("Error al crear query {0}: {1}", QueryName, oCompany.GetLastErrorDescription()));
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
                oRS = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oQuery);
                oQuery = null;
                GC.Collect();
            }
            return functionReturnValue;
        }

        public int GetSysCatID()
        {
            int functionReturnValue = 0;
            functionReturnValue = -3;
            SAPbobsCOM.Recordset oRS = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);

            try
            {
               // SBOApp.TranslateToHana("SELECT TOP 1 CATEGORYID FROM OQCN WHERE CATNAME = 'Geral'");
                oRS.DoQuery("SELECT TOP 1 CATEGORYID FROM OQCN WHERE CATNAME = 'Geral'");
                if (oRS.RecordCount > 0)
                    functionReturnValue = Convert.ToInt32(oRS.Fields.Item(0).Value);
            }
            catch
            {
                throw new Exception(String.Format("Erro: {0}", oCompany.GetLastErrorDescription()));
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
                oRS = null;
                GC.Collect();
            }
            return functionReturnValue;
        }


    }// fin de la clase


}// fin del namespace
