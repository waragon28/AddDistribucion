﻿//#define AD_BO
#define AD_PE
//#define AD_ES
//#define AD_PY
//#define AD_EC

using System;
using System.Collections.Generic;
using SAPbobsCOM;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Newtonsoft.Json;
using RestSharp;
using Vistony.Distribucion.BO;
using SAPbouiCOM;

using GoogleMapsApi;
using GoogleMapsApi.Entities.DistanceMatrix.Request;
using GoogleMapsApi.Entities.DistanceMatrix.Response;
using GoogleMapsApi.Entities.Common;
using System.Threading.Tasks;
using GoogleMapsApi.Entities.Directions.Request;

namespace Vistony.Distribucion.DAL
{
    public class EntregaDAL : BaseDAL, IDisposable
    {
        
        public void Consolidados(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string Sucural)
        {
            try
            {
                //EJECUTAR EL PROCEDIMIENTO ALMACENADO
                SAPbouiCOM.DataTable exp;
                exp = oForm.DataSources.DataTables.Item("DT_0");
                string Query = Sucural;
                exp.ExecuteQuery(Query);
                //FIN DE EJECUCION DE PROCEDIMIENTO ALMACENADO
                
                SAPbouiCOM.DataTable udt = oForm.GetDataTable("DT_1");
                oMatrix = oForm.GetMatrix("Item_2");
                SAPbouiCOM.Columns oColumns;
                oColumns = oMatrix.Columns;
                SAPbouiCOM.Column oColumn;
                var colItems = udt.Columns;

                if (udt.Columns.Count == 0)
                {
                    colItems.Add("Marca", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("DocEntry", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Entrega", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Fecha", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Numero Legal", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("FechaFinal", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("CodigoSN", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("NombreSN", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Ubigeo", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Consolidado", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("FConsolidacion", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("FReq", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Peso", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("INDIC", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Latitude", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Longitude", BoFieldsType.ft_AlphaNumeric);
                    colItems.Add("Kilometraje", BoFieldsType.ft_AlphaNumeric);
                }
                int a = udt.Rows.Count;
                if (oMatrix.RowCount > 0)
                    a = udt.Rows.Count;

                for (int oRow = 0; oRow < exp.Rows.Count; oRow++)
                {
                    udt.Rows.Add();
                    udt.SetValue("Marca", oRow, exp.GetString("Marca", oRow));
                    udt.SetValue("DocEntry", oRow, exp.GetString("DocEntry", oRow));
                    udt.SetValue("Entrega", oRow, exp.GetString("Entrega", oRow));
                    udt.SetValue("Fecha", oRow, exp.GetString("Fecha", oRow));
                    udt.SetValue("Numero Legal", oRow, exp.GetString("Numero Legal", oRow));
                    udt.SetValue("FechaFinal", oRow, exp.GetString("FechaFinal", oRow));
                    udt.SetValue("CodigoSN", oRow, exp.GetString("CodigoSN", oRow));
                    udt.SetValue("NombreSN", oRow, exp.GetString("NombreSN", oRow));
                    udt.SetValue("Ubigeo", oRow, exp.GetString("Ubigeo", oRow));
                    udt.SetValue("Consolidado", oRow, exp.GetString("Consolidado", oRow));
                    udt.SetValue("FConsolidacion", oRow, exp.GetString("FConsolidacion", oRow));
                    udt.SetValue("FReq", oRow, exp.GetString("FReq", oRow));
                    udt.SetValue("Peso", oRow, exp.GetString("Peso", oRow));
                    udt.SetValue("Latitude", oRow, exp.GetString("Latitude", oRow));
                    udt.SetValue("Longitude", oRow, exp.GetString("Longitude", oRow));
                    udt.SetValue("Kilometraje", oRow, 0);
                }

                oMatrix.Columns.Item("Col_0").DataBind.Bind("DT_1", "Marca");
                oMatrix.Columns.Item("Col_1").DataBind.Bind("DT_1", "DocEntry");
                oMatrix.Columns.Item("Col_2").DataBind.Bind("DT_1", "Entrega");
                oMatrix.Columns.Item("Col_3").DataBind.Bind("DT_1", "Fecha");
                oMatrix.Columns.Item("Col_4").DataBind.Bind("DT_1", "Numero Legal");
                oMatrix.Columns.Item("Col_5").DataBind.Bind("DT_1", "FechaFinal");
                oMatrix.Columns.Item("Col_6").DataBind.Bind("DT_1", "CodigoSN");
                oMatrix.Columns.Item("Col_7").DataBind.Bind("DT_1", "NombreSN");
                oMatrix.Columns.Item("Col_8").DataBind.Bind("DT_1", "Ubigeo");
                oMatrix.Columns.Item("Col_9").DataBind.Bind("DT_1", "Consolidado");
                oMatrix.Columns.Item("Col_10").DataBind.Bind("DT_1", "FConsolidacion");
                oMatrix.Columns.Item("Col_11").DataBind.Bind("DT_1", "FReq");
                oMatrix.Columns.Item("Col_12").DataBind.Bind("DT_1", "Peso");
                oMatrix.Columns.Item("Col_13").DataBind.Bind("DT_1", "Latitude");
                oMatrix.Columns.Item("Col_14").DataBind.Bind("DT_1", "Longitude");
                oMatrix.Columns.Item("Col_15").DataBind.Bind("DT_1", "Kilometraje");

                oColumn = oColumns.Item("Col_0");
                oMatrix.LoadFromDataSource();
                oMatrix.AutoResizeColumns();
                GetRutaOptima();
            }
            catch (Exception EX)
            {


                throw;
            }

        }

        public void GetRutaOptima()
        {
       
            // Construir la solicitud de la API de Google Maps
            RestClient client = new RestClient("https://maps.googleapis.com/maps/api/directions/json?origin=-11.7648155,-77.1600196&destination=-11.7648155,-77.1600196&waypoints=via:-11.8547872,-77.0782242|via:-11.8628667,-77.0896241|via:-11.8628667,-77.0896243&precision=high&&mode=driving&departure_time=now&avoid=tolls|highways&vehicle_type=truck&key=AIzaSyBDbOiBGhKP8rjixiTEaNdBwd23iOFe7YM");
            RestRequest request = new RestRequest(Method.POST);
            string JsonObtenerCabezera = JsonConvert.SerializeObject(request.ToString());
            dynamic result = client.Execute(request);

        }

        public void FindText(SAPbouiCOM.SBOItemEventArg pVal,int filaseleccionada, EditText EditText7, Grid Grid1)
        {
            string textoFind = string.Empty;
            string docNum = string.Empty;

            try
            {
                textoFind = EditText7.Value.Trim();

#if AD_PE
                if (textoFind.Length < 8)
                {
                    filaseleccionada = -1;
                    return;
                }

#endif


                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid1.Rows.Count - 1; row++)
                    {
                        docNum = Grid1.DataTable.GetString("Entrega", row);
                        if (docNum == textoFind)
                        {
                            Grid1.Rows.SelectedRows.Clear();
                            Grid1.Rows.SelectedRows.Add(row);
                            filaseleccionada = row;
                            return;
                        }
                    }
                }
                else
                {
                    if (filaseleccionada != -1)
                    {
                        if (Grid1.DataTable.GetValue(0, filaseleccionada).ToString() != "Y")
                        {
                            Grid1.DataTable.SetValue(0, filaseleccionada, "Y");
                        }
                        else
                        {
                            Grid1.DataTable.SetValue(0, filaseleccionada, "N");
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public void RutaMasCortaAPI_GOOGLE(string origen, List<string> destinos)
        {
            // Define los parámetros de la solicitud HTTP
            var claveAPI = "AIzaSyBDbOiBGhKP8rjixiTEaNdBwd23iOFe7YM";//API DE GOOGLE
            var unidades = "metric"; // utilizar unidades métricas (metros y segundos)
            
            // Crea una lista para almacenar los resultados de la solicitud HTTP
            var resultados = new List<dynamic>();

            // Envía solicitudes HTTP para cada destino y almacena los resultados
            foreach (var destino in destinos)
            {
                // Construye la URL de la solicitud HTTP
                var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={origen}&destination={destino}&key={claveAPI}&units={unidades}";

            }

        }
        public void UpdateEstadoConsolidadoEntrega(SAPbouiCOM.Form oForm,Grid Grid1, string tipoConsolidado, 
            string fechaConsolidado,EditText EditText8,EditText EditText9,Button Button5)
        {
            int? docEntry = 0;
            string docNum = string.Empty;
            string response = string.Empty;
            bool isUpdate = false;

            try
            {
                oForm.Freeze(true);

                int Check=0;

                for (int oRow = 0; oRow < Grid1.Rows.Count; oRow++)
                {
                    if (Grid1.DataTable.GetString("Marca", oRow) == "Y")
                    {
                        Check+=1;
                    }
                }

                for (int row = 0; row < Grid1.Rows.Count; row++)
                {
                    if (Grid1.DataTable.GetString("Marca", row) == "Y")
                    {
                        docEntry = Grid1.DataTable.GetInt("DocEntry", row);
                        docNum = Grid1.DataTable.GetString("Entrega", row);


                        ///creo el objeto que será serializado
                        EntregaConsolidado obj = new EntregaConsolidado();
                        obj.U_SYP_DT_CONSOL = tipoConsolidado;
                        obj.U_SYP_DT_FCONSOL = fechaConsolidado;
                        obj.U_SYP_DT_HCONSOL = DateTime.Now.ToString("hh:mm:ss");

                        dynamic jsonData = JsonConvert.SerializeObject(obj);

                        response = string.Empty;
                        isUpdate = false;

                        isUpdate = UpdateEstadoEntrega(docEntry, jsonData, ref response);

                        if (isUpdate)
                        {
                            Forxap.Framework.UI.Sb1Messages.ShowSuccess("Se consolido " + row + " de " + Check +" documentos.");
                        }
                        else
                        {
                            Forxap.Framework.UI.Sb1Messages.ShowError("Error de Consolidado "+ docNum);
                        }
                    }
                }

                // sete en cero los documentos seleccionados y el peso
                EditText8.SetInt(0);
                EditText9.SetDouble(0);

                Button5.Item.Click();
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }

        }

        public SAPbouiCOM.DataTable Search(SAPbouiCOM.SBOItemEventArg pVal,Form oForm,EditText EditText9,EditText EditText4, 
            EditText EditText5,string UserName,CheckBox CheckBox2, CheckBox CheckBox3,string AdminPuntoEmision,
            ComboBox ComboBox0, Grid Grid1, EditText EditText8,SAPbouiCOM.DataTable oDT)
        {
            string consolidado = string.Empty;
            string agencia = string.Empty;
            string desde = string.Empty;
            string hasta = string.Empty;
            string usuario = string.Empty;
            EditText9.Value = "0";
            try
            {
                consolidado = "N";
                agencia = "N";
                desde = EditText4.Value.Trim();
                hasta = EditText5.Value.Trim();
                usuario = UserName;

                if (CheckBox2.Checked)
                {
                    consolidado = "Y";
                }
                if (CheckBox3.Checked)
                {
                    agencia = "Y";
                }
                
                oDT.Clear();

#if AD_PE
                if (AdminPuntoEmision == "1")
                {
                    Entrega_Sucursal(ref oDT, desde, hasta, consolidado, agencia, ComboBox0.GetSelectedDescription());
                }
                else
                {
                    Entrega(ref oDT, desde, hasta, consolidado, agencia, usuario);
                }
#else
                    Entrega(ref oDT, desde, hasta, consolidado, agencia, usuario);
#endif

                SetFormatGrid(EditText8, Grid1);
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            return oDT;
        }

        private void SetFormatGrid(EditText EditText8, Grid Grid1)
        {
            EditText8.SetDouble(0);

            Grid1.AssignLineNro();
            Grid1.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid1.Columns.Item("DocEntry").Visible = false;
            Grid1.Columns.Item("Tipo").Visible = false;


#if AD_PE
            Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "15");
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#elif AD_BO
           Grid1.Columns.Item(2).TitleObject.Caption = "Factura";
           LinkedButton1.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
           Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "13");
           Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Factura";
#elif AD_ES
            Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Factura", "15");
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#elif AD_CL
            Grid1.Columns.Item(2).TitleObject.Caption = "Factura";
            LinkedButton1.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
            Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "15");
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Factura";
#elif AD_PY
            Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "13");
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#elif AD_EC
            Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "15");
#endif
            Grid1.Columns.Item("CodigoSN").LinkedObjectType(Grid1, "CodigoSN", "2");
            Grid1.Columns.Item("INDIC").Visible = false;


            Grid1.Columns.Item("Fecha").TitleObject.Caption = "Fecha Documento";
            Grid1.Columns.Item(0).TitleObject.Caption = "Marcar";


            Grid1.Columns.Item("CodigoSN").TitleObject.Caption = "Código SN";
            Grid1.Columns.Item("NombreSN").TitleObject.Caption = "Nombre SN";
            Grid1.Columns.Item("FConsolidacion").TitleObject.Caption = "Fecha Consolidación";
            Grid1.Columns.Item("HConsolidacion").TitleObject.Caption = "Hora Consolidación";
            Grid1.Columns.Item("Peso").TitleObject.Caption = "Peso Bruto";
            Grid1.Columns.Item("Peso").RightJustified = true;
            Grid1.Columns.Item("FReq").TitleObject.Caption = "Fecha Requerida";
            Grid1.ReadOnlyColumns();
            Grid1.Columns.Item(0).Editable = true;
            Grid1.AutoResizeColumns();

            // amplio el ancho de la columna
            Grid1.RowHeaders.Width += 15;

        }
        public void BuscarChoferesUbigeo(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string Sucural)
        {
            SAPbouiCOM.DataTable udt;

            string strHANA = string.Format("CALL P_VIS_DIS_LISTA_CHOFERES_UBIGEO('{0}')", Sucural);
            udt = oForm.DataSources.DataTables.Item("DT_0");
            udt.ExecuteQuery(strHANA);
            oMatrix = oForm.GetMatrix("Item_0");

            SAPbouiCOM.Columns oColumns;
            oColumns = oMatrix.Columns;
            var colItems = udt.Columns;
            // SAPbouiCOM.Column oColumn;
            oColumns = oMatrix.Columns;

            for (int oRows = 0; oRows < udt.Rows.Count; oRows++)
            {
                SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource("@VIST_UBIGEOCHOFER");
                int rowCount = 0;

                rowCount = oDatasource.Offset;

                rowCount = rowCount + 1;

                oDatasource.InsertRecord(oDatasource.Size);
                oDatasource.Offset = oDatasource.Size - 1;

                oDatasource.SetValue("Code", oRows, udt.GetString("Code", oRows));
                oDatasource.SetValue("Name", oRows, udt.GetString("Name", oRows));
                oDatasource.SetValue("U_VIS_CodUbigeo", oRows, udt.GetString("U_VIS_CodUbigeo", oRows));
                oDatasource.SetValue("U_VIS_CodChofer", oRows, udt.GetString("U_VIS_CodChofer", oRows));
                oDatasource.SetValue("U_VIS_CodZona", oRows, udt.GetString("U_VIS_CodZona", oRows));
                oDatasource.SetValue("U_VIS_VisitPoint", oRows, udt.GetString("U_VIS_VisitPoint", oRows));
                oDatasource.SetValue("U_VIS_Chofer", oRows, udt.GetString("U_VIS_Chofer", oRows));
                
                oMatrix.LoadFromDataSource();
            }
            oMatrix.LoadFromDataSource();


        }
        public SAPbouiCOM.DataTable GetInfoUsuario(string USUARIO, SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string StrHANA = string.Format("CALL P_VIS_GET_PUNTO_EMISION_USUARIO('{0}')", USUARIO);
                oDT.ExecuteQuery(StrHANA);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public SAPbouiCOM.DataTable GetEmplIMEI(string IMEI, SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string StrHANA = string.Format("CALL P_VIST_VALIDAR_IMEI('{0}')", IMEI);
                oDT.ExecuteQuery(StrHANA);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public bool ValidarIMEI(string IMEI, Recordset recordset, EditText ID_Empleado, EditText Nombre_OHEM)
        {
            bool Rspt = false;
           // recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string StrHANA = string.Format("CALL P_VIST_VALIDAR_IMEI('{0}')", IMEI);
            recordset.DoQuery(StrHANA);
            string EmpID = recordset.Fields.Item("empID").Value.ToString();
            if (EmpID != "0")
            {
                Rspt= true;
                ID_Empleado.Value = recordset.Fields.Item("empID").Value.ToString();
                Nombre_OHEM.Value = recordset.Fields.Item("lastName").Value.ToString() + " " +
                                    recordset.Fields.Item("firstName").Value.ToString() + " " +
                                   recordset.Fields.Item("middleName").Value.ToString();
            }
            else
            {
               
            }
            return Rspt;
        }
        public bool UpdateIMEI(int? EmployeeID, dynamic jsonData, ref string response)
        {
            bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;
                restResponse = methods.PATCH("EmployeesInfo", EmployeeID, jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;
                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
            }


        }
        public void Layout_Preview(string ReportName, string DocNum, Recordset oRS)
        {
            // SAPbobsCOM.Recordset oRS = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRS.DoQuery("SELECT \"GUID\" FROM OCMN WHERE \"Name\" = '" + ReportName + "' AND \"Type\" = 'C'");
            if (oRS.RecordCount > 0)
            {
                string MenuID = oRS.Fields.Item(0).Value.ToString();

                SAPbouiCOM.Framework.Application.SBO_Application.Menus.Item(MenuID).Activate();
               // form2 = (SAPbouiCOM.Form)SAPbouiCOM.Framework.Application.SBO_Application.Forms.ActiveForm;
                // ((EditText)form2.Items.Item("1000003").Specific).String = DocNum;
                //  form2.Items.Item("1").Click(BoCellClickType.ct_Regular);
            }
            else
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox("Report layout " + ReportName + " not found.", 0, "OK", null, null);
            }

        }
        public SAPbouiCOM.DataTable Entrega(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string userName)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_SEARCHOPERATIONS ('{0}','{1}','{2}','{3}','{4}')", startDate, endDate, consolidado, agencia, userName);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable GetSLD(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string AlmacenDesde, string AlmacenHasta,string Query)
        {
            try
            {
                string sSTRSQL = String.Format(Query, startDate, endDate, AlmacenDesde, AlmacenHasta);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable GetConsolidadoSLD(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string AlmacenDesde, string AlmacenHasta, string Query,string Consolidado,string Agencia)
        {
            try
            {
                string sSTRSQL = String.Format(Query, startDate, endDate, AlmacenDesde, AlmacenHasta, Consolidado, Agencia);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable Entrega_Sucursal(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string Sucursal)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_SEARCHOPERATIONS_SUCURSAL ('{0}','{1}','{2}','{3}','{4}')", startDate, endDate, consolidado, agencia, Sucursal);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SAPbouiCOM.DataTable ListPrevDespacho(SAPbouiCOM.DataTable oDT, string Desde, string Hasta, string Usuario, string chofer, int dia)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_LISTPREVASIG ('{0}','{1}','{2}','{3}')", Desde, Hasta, Usuario, chofer);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable ListPrevDespacho(string startDate, string endDate, string usuario, string chofer, string agencia, ref SAPbouiCOM.DataTable oDT)
        {
            try
            {
                //CALL "SP_VIS_DIS_LISTPREVASIGv2" ('20221121','20221121','waragon','7098785','' )
                string strSQL = String.Format("CALL \"SP_VIS_DIS_LISTPREVASIGv2\" ('{0}','{1}','{2}','{3}','{4}' )", startDate, endDate, usuario, chofer, agencia);
                oDT.ExecuteQuery(strSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public SAPbouiCOM.DataTable ListPrevDespacho_Sucursal(string startDate, string endDate, string Sucursal, string chofer, string agencia, ref SAPbouiCOM.DataTable oDT)
        {
            try
            {
                //CALL "SP_VIS_DIS_LISTPREVASIGv2" ('20221121','20221121','waragon','7098785','' )
                string strSQL = String.Format("CALL \"SP_VIS_DIS_LISTPREVASIGv2_SUCURSAL\" ('{0}','{1}','{2}','{3}','{4}' )", startDate, endDate, Sucursal, chofer, agencia);
                oDT.ExecuteQuery(strSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public SAPbouiCOM.DataTable ListPrevDespachoManual(string startDate, string endDate, string usuario, string chofer,string Agencia, ref SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string strSQL = String.Format("CALL \"SP_VIS_DIS_LISTASIGMANUAL\" ('{0}','{1}','{2}','{3}','{4}')", startDate, endDate, usuario, chofer, Agencia);
                oDT.ExecuteQuery(strSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public  SAPbouiCOM.DataTable ListPrevDespachoEdit(ref SAPbouiCOM.DataTable oDT, string Desde, string Hasta, string Usuario, string chofer)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_LISTPREVASIG_EDIT ('{0}','{1}','{2}','{3}')", Desde, Hasta, Usuario, chofer);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         public static SAPbouiCOM.DataTable BuscarDespachos(SAPbouiCOM.DataTable oDT, string usuario, string licencia, string fecha, string estado, string TipoDespacho)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_OBTENER_DESPACHOS ('{0}','{1}','{2}','{3}','{4}')", usuario, licencia,fecha,estado, TipoDespacho);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static SAPbouiCOM.DataTable BuscarDespachos_Sucursal(SAPbouiCOM.DataTable oDT, string Sucursal, string licencia, string fecha, string estado)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_OBTENER_DESPACHOS_SUCURSAL ('{0}','{1}','{2}','{3}')", Sucursal, licencia, fecha, estado);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool GrabarHistorial(dynamic jsonData, out string respuesta)
        {
            bool procesoOK;
            try
            {

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("HISTDESPA",  jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    respuesta = "OK";
                    procesoOK = true;
                }
                else
                {
                    respuesta = response.Content.ToString();
                    procesoOK = true;
                }


                return procesoOK;
            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();
                return false;
            }

        }
        public static bool GrabarHistorialCabecera(dynamic jsonData, out string respuesta)
        {
            bool procesoOK;
            try
            {

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("VIS_HIST_DESP_C", jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    respuesta = "OK";
                    procesoOK = true;
                }
                else
                {
                    respuesta = response.Content.ToString();
                    procesoOK = true;
                }


                return procesoOK;
            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();
                return false;
            }

        }
        public  string ObtenerSucursal(SAPbouiCOM.DataTable oDT, string Usuario)
        {
            string sucursal = string.Empty;
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_OBTENERSUCUSU ('{0}')", Usuario);
                oDT.ExecuteQuery(sSTRSQL);

                if (oDT.Rows.Count > 0)
                {
                    sucursal = oDT.GetString("DATO", 0).ToString();
                }

                return sucursal;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public string ObtenerSucursal( string usuario)
        {
            string sucursal = string.Empty;
            string strSQL = string.Empty;

            SAPbobsCOM.Recordset recordSet = null;
            string code = string.Empty;



            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {
                
                strSQL = string.Format("CALL   SP_VIS_DIS_OBTENERSUCUSU ('{0}')", usuario);

                recordSet.DoQuery(strSQL);


                sucursal = recordSet.Fields.Item("Dato").Value.ToString();
                
                return sucursal;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string ObtenerDepartamento(string usuario)
        {
            string Departamento = string.Empty;
            string strSQL = string.Empty;

            SAPbobsCOM.Recordset recordSet = null;
            string code = string.Empty;



            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {

                strSQL = string.Format("SELECT * FROM OUSR WHERE \"USER_CODE\" = '{0}'", usuario);

                recordSet.DoQuery(strSQL);


                Departamento = recordSet.Fields.Item("Department").Value.ToString();

                return Departamento;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public  string ObtenerCorrelativoDespacho(SAPbouiCOM.DataTable oDT, string Fecha)
        {
            string correlativo = string.Empty;
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_CORR_DESPACHO ('{0}')", Fecha);
                oDT.ExecuteQuery(sSTRSQL);
                correlativo = oDT.GetString("DATO", 0).ToString();
                return correlativo;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public static int EstadoEntregaVAL(SAPbouiCOM.DataTable oDT, string DocNum)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_STATEDELIVERY ('{0}')",DocNum);
                //oRecordSet.DoQuery(sSTRSQL);
                oDT.ExecuteQuery(sSTRSQL);
                int filas = 0;
                filas = Convert.ToInt16(oDT.GetValue(0, 0));
                return filas;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
        public static void UpdateEstadoEntregaDRT1(string docEntry, dynamic jsonData)
        {
          //  bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;
                restResponse = methods.PATCH("VIS_DIS_ODRT", Convert.ToInt32(docEntry), jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                  //  response = "OK";
                    //ret = true;
                }
                else
                {
                   // response = restResponse.Content.ToString();
                   // ret = true;
                }
               // return ret;
            }
            catch (Exception ex)
            {
                // response = ex.ToString();
               // ret = false;
            }

        }
        
        public bool UpdateEstadoSLD(int? docEntry, dynamic jsonData, ref string response)
        {
            bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;
                
                restResponse = methods.PATCH("InventoryTransferRequests", docEntry, jsonData);


                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;

                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
            }

        }
        public bool UpdateEstadoSLD2(int? docEntry, dynamic jsonData, ref string response,
           string Tipo, string Serie, string actual, SAPbobsCOM.Recordset rc, SAPbobsCOM.Recordset rc2)
        {
            bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;

                restResponse = methods.PATCH("StockTransfers", docEntry, jsonData);


                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;
                    setNextCorrelativoSL(Tipo, Serie, actual, rc, rc2);

                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
            }

        }

        public static void setNextCorrelativoSL(string Tipo, string Serie, string actual, SAPbobsCOM.Recordset rc, SAPbobsCOM.Recordset rc2)
        {
            PatchSerie p = new PatchSerie();
            try
            {
                int largo;
                int siguienteInt;
                int lineID;
                string siguienteStr;
                siguienteInt = Convert.ToInt32(actual) + 1;
                string query = "select U_SYP_SIZECOR from \"@SYP_TPODOC\" where \"Code\" = '" + Tipo + "'";
                rc.DoQuery(query);
                largo = Convert.ToInt32(rc.Fields.Item(0).Value);
                string query2 = string.Format("SELECT \"LineId\" FROM \"@SYP_NUMDOC\" WHERE \"Code\"='09' AND \"U_SYP_NDSD\"='{0}'", Serie);
                rc2.DoQuery(query2);
                lineID = Convert.ToInt32(rc2.Fields.Item(0).Value);
                siguienteStr = "000000000000" + siguienteInt.ToString();
                siguienteStr = siguienteStr.Substring(siguienteStr.Length - largo);
                p.Code = "09";
                p.LineId = lineID;
                p.U_SYP_NDCD = siguienteStr;

                string StrJson = JsonConvert.SerializeObject(p);
                string update = string.Format("UPDATE \"@SYP_NUMDOC\" SET \"U_SYP_NDCD\" = '{0}' WHERE \"LineId\" = {1} AND \"Code\" = '09'", siguienteStr, lineID);
                /*GuiaMasivaBLL gmbll = new GuiaMasivaBLL();
                string rpta = gmbll.updateCorrelativo(StrJson);*/
                rc2.DoQuery(update);
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message);
            }
        }
        public  bool UpdateEstadoEntrega(int? docEntry, dynamic jsonData, ref  string response)
        {
            bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;

#if AD_PE
                    restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#elif AD_BO
                    restResponse = methods.PATCH("Invoices", docEntry, jsonData);
#elif AD_EC
                    restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#elif AD_ES
                    restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#elif AD_PY
                restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
                #endif

                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;
                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
            }

        }
        
        public void GetDatosChofer(ref string choferCode, ref string choferName, ref string choferLicencia, ref string vehiculoPlaca, ref string vehiculoMarca, ref string ayudanteCode, ref string ayudanteName, ref double pesoUtil )
        {
            SAPbobsCOM.Recordset recordSet = null;
            string code = string.Empty;
         


            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {

                string strSQL = "''";
              
                strSQL = string.Format("CALL   \"P_VIS_DIS_CHOFER_DATOS\" ('{0}')",choferCode );

                recordSet.DoQuery(strSQL);


                choferCode = recordSet.Fields.Item("Chofer_ID").Value.ToString();
                choferName = recordSet.Fields.Item("Chofer").Value.ToString();
                choferLicencia = recordSet.Fields.Item("Licencia").Value.ToString();
                vehiculoPlaca = recordSet.Fields.Item("Placa").Value.ToString();
                vehiculoMarca = recordSet.Fields.Item("MarcaVehiculo").Value.ToString();
                ayudanteCode = recordSet.Fields.Item("Ayudante_ID").Value.ToString();
                ayudanteName = recordSet.Fields.Item("Aydante").Value.ToString();
                pesoUtil =  Math.Round(Convert.ToDouble(recordSet.Fields.Item("CargaUtil").Value), 2);
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

        }

        public RutaTransportista ObtenerCabeceraDocuemtnoRutaTransportista(SAPbouiCOM.Grid dt, string U_DriverCode, string U_DriverName, string U_VehiculeCode, 
                                                string U_VehicleCapacity, string U_CountDocuments, string U_DocumentsCapacity, string U_AssistantCode, string U_AssistantName)
        {
            RutaTransportista DocumentoRutaTransportista= new RutaTransportista();
            DocumentoRutaTransportista.U_DriverCode = U_DriverCode;
            DocumentoRutaTransportista.U_DriverName = U_DriverName;
            DocumentoRutaTransportista.U_VehiculeCode = U_VehiculeCode;
            DocumentoRutaTransportista.U_VehicleCapacity = U_VehicleCapacity;
            DocumentoRutaTransportista.U_CountDocuments = U_CountDocuments;
            DocumentoRutaTransportista.U_DocumentsCapacity = U_DocumentsCapacity;
            DocumentoRutaTransportista.U_AssistantCode = U_AssistantCode;
            DocumentoRutaTransportista.U_AssistantName = U_AssistantName;
            DocumentoRutaTransportista.VIS_DIS_DRT1Collection = ObtenerDetalle(dt);
            return DocumentoRutaTransportista;
        }
        public List<RutaTransportista1> ObtenerDetalle(SAPbouiCOM.Grid dt)
        {

            List<RutaTransportista1> VIS_TRN_REP_DDocumentDetalls = new List<RutaTransportista1>();

            for (int oRows = 0; oRows < dt.Rows.Count; oRows++)
            {
                RutaTransportista1 DocumentoRutaTransportistaDetalls = new RutaTransportista1();
                    DocumentoRutaTransportistaDetalls.U_CardCode = dt.DataTable.GetString("U_CardCode", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_CardName = dt.DataTable.GetString("U_CardName", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_DeliveryDate = dt.DataTable.GetString("U_DeliveryDate", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_FullAddress = dt.DataTable.GetString("U_FullAddress", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_Comments = dt.DataTable.GetString("U_Comments", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_EstimatedTime = dt.DataTable.GetString("U_EstimatedTime", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_CheckInTime = dt.DataTable.GetString("U_CheckInTime", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_CheckOutTime = dt.DataTable.GetString("U_CheckOutTime", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_PhotoDocument = dt.DataTable.GetString("U_PhotoDocument", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_PhotoStore = dt.DataTable.GetString("U_PhotoStore", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_PersonContact = dt.DataTable.GetString("U_PersonContact", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_PaymentCondition = dt.DataTable.GetString("U_PaymentCondition", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_ReturnReason = dt.DataTable.GetString("U_ReturnReason", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_UserCode = dt.DataTable.GetString("U_UserCode", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_UserName = dt.DataTable.GetString("U_UserName", oRows).ToString();
                    DocumentoRutaTransportistaDetalls.U_Delivered = dt.DataTable.GetString("U_Delivered", oRows).ToString();

                VIS_TRN_REP_DDocumentDetalls.Add(DocumentoRutaTransportistaDetalls);

            }
            return VIS_TRN_REP_DDocumentDetalls;

        }

        public void GenerarRutaTransportista(Grid Grid0, EditText U_DriverCode, EditText U_DriverName, EditText U_VehiculeCode,EditText U_VehicleCapacity, 
                                                EditText U_CountDocuments, EditText U_DocumentsCapacity, EditText U_AssistantCode, EditText U_AssistantName)
        {
            Sb1Messages.ShowWarning("Agregando Registro de ruta de transportista");

            RutaTransportista ObtenerCabecera = ObtenerCabeceraDocuemtnoRutaTransportista(Grid0, U_DriverCode.Value, U_DriverName.Value, U_VehiculeCode.Value, U_VehicleCapacity.Value,
                                                                                                         U_CountDocuments.Value, U_DocumentsCapacity.Value, U_AssistantCode.Value, U_AssistantName.Value);
            string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera);

            IRestResponse responsde;
            Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
            dynamic entrada = JsonObtenerCabezera;
            responsde = Methods.POST("VIS_DIS_ODRT", entrada.ToString());

            dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());
            if (responsde.StatusCode.ToString() == "Created")
            {
                Sb1Messages.ShowSuccess("Se genero la ruta de transportista: " + m["DocNum"].ToString());

            }
            else
            {
                Sb1Messages.ShowError(m["error"]["message"]["value"].ToString());
            }

        }


        public void GetDataTableResumen(ref SAPbouiCOM.DataTable oDatatable,int rows)
        {
            if (oDatatable.Columns.Count == 0)
            {
                oDatatable.Columns.Add("DocDate", BoFieldsType.ft_Date, 50);
                oDatatable.Columns.Add("DriverCode", BoFieldsType.ft_AlphaNumeric, 50);
                oDatatable.Columns.Add("DriverName", BoFieldsType.ft_AlphaNumeric, 254);
                oDatatable.Columns.Add("VehiculeCode", BoFieldsType.ft_AlphaNumeric, 50);
                oDatatable.Columns.Add("VehiculeCapacity", BoFieldsType.ft_Float, 50);
                oDatatable.Columns.Add("DocumentCount", BoFieldsType.ft_Integer, 50);
                oDatatable.Columns.Add("DocumentWeight", BoFieldsType.ft_Float, 50);

                oDatatable.Rows.Add(rows);

            }
        }
        public Programacion ObtenerRutaTransportista(SAPbouiCOM.Grid dt, string docDate, string driverCode, string driverName, string assistantCode, 
            string assistantName, string vehiculeCode, string vehiculeName, double? vehiculeCapacity, double? documentsWeight,
        string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            Programacion DocumentoProgramacion = new Programacion();

            DocumentoProgramacion.U_DocDate =  docDate;
            DocumentoProgramacion.U_DriverCode = driverCode;
            DocumentoProgramacion.U_DriverName = driverName;
            DocumentoProgramacion.U_AssistantCode = assistantCode;
            DocumentoProgramacion.U_AssistantName = assistantName;
            DocumentoProgramacion.U_VehiculeCode = vehiculeCode;
            DocumentoProgramacion.U_VehiculeName = vehiculeName;
            DocumentoProgramacion.U_VehicleCapacity = vehiculeCapacity.ToString();
            DocumentoProgramacion.U_DocumentsWeight = documentsWeight.ToString();
            DocumentoProgramacion.U_SuccessQuantity = successQuantity;
            DocumentoProgramacion.U_FailedQuantity = failedQuantity;
            DocumentoProgramacion.U_DocumentsQuantity = documentsQuantity;
            DocumentoProgramacion.U_Type_Route = TipoRuta;
            DocumentoProgramacion.VIS_DIS_DRT1Collection = ObtenerDetalleProgramacion(dt);
            return DocumentoProgramacion;
        }
        public List<Programacion1> ObtenerDetalleProgramacion(SAPbouiCOM.Grid dt)
        {

            List<Programacion1> VIS_ProgramacionDetalls = new List<Programacion1>();

            for (int oRows = 0; oRows < dt.Rows.Count; oRows++)
            {
                if (dt.DataTable.GetString("Marca", oRows).ToString() == "Y")
                {
                    Programacion1 programacion1 = new Programacion1();

                    programacion1.U_NumAtCard = dt.DataTable.GetString("NumAtCard", oRows).ToString();
                    programacion1.U_Delivered = "P";// dt.DataTable.GetString("CardCode", oRows).ToString();
                    programacion1.U_CardCode = dt.DataTable.GetString("CardCode", oRows).ToString();
                    programacion1.U_CardName = dt.DataTable.GetString("CardName", oRows).ToString();
                    programacion1.U_DocEntry = dt.DataTable.GetString("DocEntry", oRows).ToString();
                    programacion1.U_DocNum = dt.DataTable.GetString("Entrega", oRows).ToString();
                    programacion1.U_FullAddress = dt.DataTable.GetString("Direccion", oRows).ToString();

                    programacion1.U_DocEntryRef = dt.DataTable.GetString("DocEntry_Fac", oRows).ToString();
                    programacion1.U_DocNumRef = dt.DataTable.GetString("NroFactura", oRows).ToString();

                    programacion1.U_SlpCode = dt.DataTable.GetString("Vendedor_ID", oRows).ToString();
                    programacion1.U_SlpName = dt.DataTable.GetString("Vendedor", oRows).ToString();

                    programacion1.U_PymntGroup = dt.DataTable.GetString("TerminoPago", oRows).ToString();


                    programacion1.U_DocBalance = dt.DataTable.GetString("Saldo", oRows).ToString();

                    // DocumentoProgramacionDetalls.U_TaxDate = dt.DataTable.GetString("DocDueDate", oRows).ToString();

                    VIS_ProgramacionDetalls.Add(programacion1);
                }
            }
            return VIS_ProgramacionDetalls;

        }

        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C(ref SAPbouiCOM.DataTable oDT, string fecha)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_C ('{0}')", fecha);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C_TEST(ref SAPbouiCOM.DataTable oDT, string fecha,
            string TRACKER, string Sucursal,string TipoRuta)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_C_TEST ('{0}','{1}','{2}','{3}')", fecha, TRACKER, Sucursal, TipoRuta);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_D(ref SAPbouiCOM.DataTable oDT,string fecha, int HORA_INI , int HORA_FIN, string CodChofer,string CodVehiculo)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_D ('{0}','{1}','{2}','{3}','{4}')", fecha,HORA_INI, HORA_FIN, CodChofer, CodVehiculo);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_VENTAS(ref SAPbouiCOM.DataTable oDT, string fecha, int HORA_INI, int HORA_FIN, string CodVendedor)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_VENDEDOR ('{0}','{1}','{2}','{3}','{4}')", fecha, HORA_INI, HORA_FIN, CodVendedor);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C_VENTAS(ref SAPbouiCOM.DataTable oDT, string fecha, int HORA_INI, int HORA_FIN, string Departamento)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_VENDEDOR ('{0}','{1}')", fecha,Departamento);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_D_VENTAS(ref SAPbouiCOM.DataTable oDT, string fecha, int HORA_INI, int HORA_FIN, string CodVendedor, string Departamento)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_GET_TRACKER_D_VENDEDOR ('{0}','{1}','{2}','{3}','{4}')", fecha, HORA_INI, HORA_FIN, CodVendedor, Departamento);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public void FormatoGrilla(ref SAPbouiCOM.DataTable oDT)
        {
            
        }

        public string GuardarProgramacion(SAPbouiCOM.Grid dt,string docDate, string driverCode, string driverName, string assistantCode, 
            string assistantName, string vehiculeCode, string vehiculeName, double? vehiculeCapacity, double? documentsWeight, 
            string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            string ret = string.Empty;

            try
            {
              
                Programacion ObtenerCabecera2 = new Programacion();

                ObtenerCabecera2= ObtenerRutaTransportista( dt, docDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, 
                    vehiculeName,vehiculeCapacity, documentsWeight, successQuantity, failedQuantity, documentsQuantity, TipoRuta);

                string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera2);

                IRestResponse responsde;
                Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic entrada = JsonObtenerCabezera;
                responsde = Methods.POST("VIS_DIS_ODRT", entrada.ToString());
                dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());

                if (responsde.StatusCode.ToString() == "Created")
                {
                    ret = responsde.StatusCode.ToString();
                }
                else
                {
                    ret = responsde.Content.ToString();
                }
                //RestClient client = new RestClient("VIS_DIS_ODRT");
                //RestRequest request = new RestRequest(Method.POST);
                //string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera2);
                //string dataReq = JsonObtenerCabezera;
                //IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

                //if (result.StatusDescription == "OK")
                //{
                //  //  RespuestMensaje.Value = "OK";
                //}
                //else
                //{
                //    Sb1Messages.ShowError(result.Content);
                //   // RespuestMensaje.Value = "ERROR";
                //}
            }
            catch (Exception e)
            {

                Sb1Messages.ShowError(e.ToString());
            }

            return ret;

        }


        public Programacion ObtenerRutaTransportistaSLD(SAPbouiCOM.Grid dt, string docDate, string driverCode, string driverName, string assistantCode,
                string assistantName, string vehiculeCode, string vehiculeName, double? vehiculeCapacity, double? documentsWeight,
                string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            Programacion DocumentoProgramacion = new Programacion();

            DocumentoProgramacion.U_DocDate = docDate;
            DocumentoProgramacion.U_DriverCode = driverCode;
            DocumentoProgramacion.U_DriverName = driverName;
            DocumentoProgramacion.U_AssistantCode = assistantCode;
            DocumentoProgramacion.U_AssistantName = assistantName;
            DocumentoProgramacion.U_VehiculeCode = vehiculeCode;
            DocumentoProgramacion.U_VehiculeName = vehiculeName;
            DocumentoProgramacion.U_VehicleCapacity = vehiculeCapacity.ToString();
            DocumentoProgramacion.U_DocumentsWeight = documentsWeight.ToString();
            DocumentoProgramacion.U_SuccessQuantity = successQuantity;
            DocumentoProgramacion.U_FailedQuantity = failedQuantity;
            DocumentoProgramacion.U_DocumentsQuantity = documentsQuantity;
            DocumentoProgramacion.U_Type_Route = TipoRuta;
            DocumentoProgramacion.VIS_DIS_DRT1Collection = ObtenerDetalleProgramacionSLD(dt);
            return DocumentoProgramacion;
        }
        public List<Programacion1> ObtenerDetalleProgramacionSLD(SAPbouiCOM.Grid dt)
        {

            List<Programacion1> VIS_ProgramacionDetalls = new List<Programacion1>();

            for (int oRows = 0; oRows < dt.Rows.Count; oRows++)
            {
                if (dt.DataTable.GetString("Marca", oRows).ToString() == "Y")
                {
                    Programacion1 programacion1 = new Programacion1();

                    programacion1.U_NumAtCard = dt.DataTable.GetString("Serie Transferencia", oRows).ToString();
                    programacion1.U_Delivered = "P";// dt.DataTable.GetString("CardCode", oRows).ToString();
                    programacion1.U_CardCode = dt.DataTable.GetString("CardCode", oRows).ToString();
                    programacion1.U_CardName = dt.DataTable.GetString("CardName", oRows).ToString();
                    programacion1.U_DocEntry = dt.DataTable.GetString("DocEntry", oRows).ToString();
                    programacion1.U_DocNum = dt.DataTable.GetString("DocNum", oRows).ToString();
                    programacion1.U_FullAddress = dt.DataTable.GetString("Direccion", oRows).ToString();

                    programacion1.U_DocEntryRef = "";// dt.DataTable.GetString("DocEntry_Fac", oRows).ToString();
                    programacion1.U_DocNumRef = "";// dt.DataTable.GetString("NroFactura", oRows).ToString();

                    programacion1.U_SlpCode = "";// dt.DataTable.GetString("Vendedor_ID", oRows).ToString();
                    programacion1.U_SlpName = dt.DataTable.GetString("Almacenero", oRows).ToString();

                    programacion1.U_PymntGroup = "";// dt.DataTable.GetString("TerminoPago", oRows).ToString();


                    programacion1.U_DocBalance = "";// dt.DataTable.GetString("Saldo", oRows).ToString();

                    // DocumentoProgramacionDetalls.U_TaxDate = dt.DataTable.GetString("DocDueDate", oRows).ToString();

                    VIS_ProgramacionDetalls.Add(programacion1);
                }
            }
            return VIS_ProgramacionDetalls;

        }
        public string GuardarProgramacionSLD(SAPbouiCOM.Grid dt, string docDate, string driverCode, string driverName, string assistantCode,
           string assistantName, string vehiculeCode, string vehiculeName, double? vehiculeCapacity, double? documentsWeight,
           string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            string ret = string.Empty;

            try
            {

                Programacion ObtenerCabecera2 = new Programacion();

                ObtenerCabecera2 = ObtenerRutaTransportistaSLD(dt, docDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode,
                    vehiculeName, vehiculeCapacity, documentsWeight, successQuantity, failedQuantity, documentsQuantity, TipoRuta);

                string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera2);

                IRestResponse responsde;
                Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic entrada = JsonObtenerCabezera;
                responsde = Methods.POST("VIS_DIS_ODRT", entrada.ToString());
                dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());

                if (responsde.StatusCode.ToString() == "Created")
                {
                    ret = responsde.StatusCode.ToString();
                }
                else
                {
                    ret = responsde.Content.ToString();
                }
               
            }
            catch (Exception e)
            {

                Sb1Messages.ShowError(e.ToString());
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
        ~EntregaDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

#endregion

    }// fin de la clase

}// fin del namespace
