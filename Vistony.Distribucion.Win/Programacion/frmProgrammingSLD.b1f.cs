//S#define AD_EC
#define AD_PE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;
using SAPbouiCOM;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;
using SAPbobsCOM;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmProgrammingSLD", "Programacion/frmProgrammingSLD.b1f")]
    class frmProgrammingSLD : UserFormBase
    {
        public frmProgrammingSLD()
        {
        }
        string sucursalUsuarioLogin;
        EntregaBLL entregaBLL = new EntregaBLL();
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText3.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText3_ChooseFromListAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_10").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.EditText4.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText4_KeyDownAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_13").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_14").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_15").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_20").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            usuario = Sb1Globals.UserName;
            Grid0.AutoResizeColumns();

            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");

            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }

        }
        
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.Button Button3;
        public string usuario;
        string ErrorUpdateDespacho = "";
        private SAPbouiCOM.CheckBox CheckBox0;
        public int filaseleccionada = -1;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();


        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Search(pVal);
        }

        private void Search(SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Freeze(true);
            string desdeAlmacen = string.Empty;
            string hastaAlmacen = string.Empty;
            string desde = string.Empty;
            string hasta = string.Empty;
            string Agencia = "N";
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            try
            {
                desdeAlmacen = EditText2.Value.Trim();
                hastaAlmacen = EditText3.Value.Trim();
                desde = EditText0.Value.Trim();
                hasta = EditText1.Value.Trim();

                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));

                oDT.Clear();
                if (CheckBox0.Checked)
                {
                    Agencia = "Y";
                }
                using (EntregaBLL entregaBLL = new EntregaBLL())
                {
#if AD_EC
                    entregaBLL.GetConsolidadoSLD(ref oDT, desde, hasta, desdeAlmacen, hastaAlmacen, addonMessageInfo.QueryObtenerSLD,"Y", Agencia);
#else
                    entregaBLL.GetConsolidadoSLD(ref oDT, desde, hasta, desdeAlmacen, hastaAlmacen, addonMessageInfo.QueryObtenerSLD, "Y", Agencia);
#endif
                }
                SetFormatGrid();
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                if (oDT.Rows.Count == 0)
                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaNotRowFound(Sb1Globals.Idioma));
                else
                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
                oForm.Freeze(false);
            }
        }

        private void SetFormatGrid()
        {
            Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;

            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();

            Grid0.Columns.Item("DocEntry").LinkedObjectType(Grid0, "DocEntry", "1250000001");
            Grid0.Columns.Item("Peso").RightJustified = true;
            // ampliio el ancho de la columna
            Grid0.RowHeaders.Width += 15;

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
                OnShowProgramacionAsignar(true);
        }

        private void OnShowProgramacionAsignar(bool isVisible)
        {
            try
            {
               frmProgrammingSLDAsignar form = new frmProgrammingSLDAsignar(this, Sb1Globals.UserName,Sb1Globals.Sucursal, Grid0);
                 form.Show();

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message.ToString());

            }

        }

        private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                //Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

        private void EditText3_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                //Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // si hicieron Check o deschekearon debo actualizar el contador de documentos seleccionados
            int rowSelected = 0;
            int rowIndex = 0;
            string isCheck = "N";
            double totalWeight = 0;
            double weightSelected = 0;
            try
            {
                if (pVal.ColUID == "Marca" && pVal.Row == -1)
                {

                    // obtengo los registros seleccionados
                    rowSelected = EditText5.GetInt();

                    // obtengo el peso total de los documentos seleccionados
                    totalWeight = EditText6.GetDouble();

                    // debo marcar o desmarcar todo
                    Utils.CheckRows(oForm, Grid0, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText5.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
                    EditText6.SetDouble(totalWeight);
                    //EditText9.SetDouble(totalWeight,Sb1Globals.cultura);
                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    // obtengo los registros seleccionados
                    rowSelected = EditText5.GetInt();
                    // obtengo el peso total de ala carga
                    totalWeight = EditText6.GetDouble();

                    rowIndex = pVal.Row;

                    isCheck = Grid0.DataTable.GetString("Marca", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                    weightSelected = (Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex)));


                    // si hicieron check
                    if (isCheck == "Y")
                    {
                        rowSelected += 1;
                        totalWeight += weightSelected;
                    }
                    else
                    {
                        // si descheckearon
                        if (rowSelected > 0) // para evitar negativos
                        {
                            rowSelected -= 1;
                            totalWeight -= weightSelected;
                        }
                    }
                    // asigno el nro de documentos seleccionados
                    EditText5.SetInt(rowSelected);
                    // asigno el peso para los documentos seleccionados
                    EditText6.SetDouble(totalWeight);
                    // EditText9.SetDouble(totalWeight);

                }
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void EditText4_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            FindText(pVal);
        }

        private void FindText(SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textoFind = string.Empty;
            string docNum = string.Empty;

            try
            {
                textoFind = EditText4.Value.Trim();

                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                    {
                        docNum = Grid0.DataTable.GetString("DocNum", row);
                        if (docNum == textoFind)
                        {
                            Grid0.Rows.SelectedRows.Clear();
                            Grid0.Rows.SelectedRows.Add(row);
                            filaseleccionada = row;
                            return;
                        }
                    }
                }
                else
                {
                    if (filaseleccionada != -1)
                    {
                        if (Grid0.DataTable.GetValue(0, filaseleccionada).ToString() != "Y")
                        {
                            Grid0.DataTable.SetValue(0, filaseleccionada, "Y");
                        }
                        else
                        {
                            Grid0.DataTable.SetValue(0, filaseleccionada, "N");
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            frmProgrammingSLDAsignar form = new frmProgrammingSLDAsignar(this, usuario, sucursalUsuarioLogin, Grid0);
            form.Show();
        }

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, bool BubbleEvent)
        {
            if (EditText5.GetInt() >= 1)
            {
                BubbleEvent = true;
            }
        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        public void UpdateRutaDespacho(Grid Grilla, string dispatchDate, string driverCode, string driverName, string assistantCode, string assistantName,
            string vehiculeCode, string vehiculeName, string vehiculeBrand,
            string fechaDespacho2, string driverCode2, string driverName2, string driverLicence2, string ayudanteCode2, string ayudanteName2,
            string vehiculoCode2, string vehiculoPlaca2, string vehiculoMarca2, string SeriesSunat, string CorrelativoSunat,string ModalidadTansporte,
            string CodigoAgencia, string RucAgencia, string NombreAgencia, string DireccionAgencia,string TipoSalida, string GuiaSalidaInicio, string GuiaSalidaEntrega
            )
        {
            string ret = string.Empty;

            ErrorUpdateDespacho = "";
            double vehiculeCapacity = 0;
            double documentsWeight = 0;
            string successQuantity = string.Empty;
            string failedQuantity = string.Empty;
            string documentsQuantity = string.Empty;
            string TipoRuta = string.Empty;

            documentsQuantity = EditText5.GetString(); //cantidad de documentos
            documentsWeight = EditText6.GetDouble(); // peso de los documentos

            vehiculeCode = Utils.GetVehiculeCode(vehiculeName, ref vehiculeCapacity, ref vehiculeBrand); // // codigo del vehiculo
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            vehiculeCode = Utils.GetVehiculeCode(vehiculeName, ref vehiculeCapacity, ref vehiculeBrand); // // codigo del vehiculo
            string FormatovehiculeCapacity = vehiculeCapacity.ToString("N", Sb1Globals.cultura);
            string FormatodocumentsWeight = documentsWeight.ToString("N", Sb1Globals.cultura);
            TipoRuta = "67";
#if AD_PY
            ret = entregaBLL.GuardarHojaDespacho(Grid0, dispatchDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName,
                Convert.ToDouble(Convert.ToString(vehiculeCapacity).Replace(",", ".")), Convert.ToDouble(Convert.ToString(documentsWeight).Replace(",", ".")), successQuantity, failedQuantity, documentsQuantity);
#else

            ret =entregaBLL.GuardarHojaDespachoSLD(Grid0, dispatchDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName,
                vehiculeCapacity, Convert.ToDouble(documentsWeight), successQuantity, failedQuantity, documentsQuantity, TipoRuta);
#endif


            if (ret == "Created")
            {
                string Respuesta = string.Empty;

                UpdateDespachoSLD(fechaDespacho2, driverCode2, driverName2, driverLicence2, ayudanteCode2, ayudanteName2, vehiculoCode2, vehiculoPlaca2, vehiculoMarca2,
                    SeriesSunat, CorrelativoSunat, ModalidadTansporte, CodigoAgencia, RucAgencia, NombreAgencia, DireccionAgencia, TipoSalida, GuiaSalidaInicio, GuiaSalidaEntrega
            );
                Sb1Messages.ShowSuccess(string.Format(addonMessageInfo.MessageIdiomaMessage324(Sb1Globals.Idioma), driverName));
            }
            else
            {
                Sb1Messages.ShowError(ret);
            }
            ErrorUpdateDespacho = ret;
        }

        public void UpdateDespachoSLD(string dispatchDate, string driverCode, string driverName, string driverLicence, 
                                    string assistantCode, string assistantName, string vehiculeCode, string vehiculeName, 
                                    string vehiculeBrandName, string SeriesSunat, string CorrelativoSunat, string ModalidadTansporte,
            string CodigoAgencia, string RucAgencia, string NombreAgencia, string DireccionAgencia, string TipoSalida, string GuiaSalidaInicio, string GuiaSalidaEntrega)
        {
            string response = string.Empty;

            try
            {

                int ContarMarcados = 0;

                if (ContarMarcados == 0)
                {
                    string docNum = string.Empty;
                    int? docEntry = 0;
                    string choferLicencia = string.Empty;
                    string vehiculoMarca = string.Empty;
                    string vehiculoPlaca = string.Empty;
                    string ayudanteName = string.Empty;
                    string ordenDespacho = string.Empty;
                    int? DocEntryTranfer = 0;
                  //  oForm.Freeze(true);
                    //PROGRAMAR DESPACHO
                    SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

                    SAPbobsCOM.Recordset rc = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    SAPbobsCOM.Recordset rc2 = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);


                    for (int row = 0; row < Grid0.Rows.Count ; row++)
                    {
                        // verifico si el documento se encuentra seleccionado
                        if (Grid0.DataTable.GetString("Marca", row) == "Y")
                        {
                            docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                            docNum = Grid0.DataTable.GetString("DocNum", row);
                            DocEntryTranfer = Grid0.DataTable.GetInt("Num Interno Transferencia", row);
                            //////////////////////// obtengo los datos para actualizar la guia ////////////////////////////
                            EntregaDespachoSLD objDespachoSLD = new EntregaDespachoSLD();
                            objDespachoSLD = GetObjDespachoSLD(driverLicence, ordenDespacho, dispatchDate, driverName, assistantName, vehiculeName, vehiculeBrandName, "P",
                                SeriesSunat, CorrelativoSunat, ModalidadTansporte, CodigoAgencia, RucAgencia, NombreAgencia, DireccionAgencia, TipoSalida, GuiaSalidaInicio, GuiaSalidaEntrega
                                );
                            dynamic objDespachoJson = JsonConvert.SerializeObject(objDespachoSLD);

                            Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage210(Sb1Globals.Idioma), docNum));

                            using (EntregaBLL entregaBLL = new EntregaBLL())
                            {
                                entregaBLL.UpdateEstadoSLD2(DocEntryTranfer, objDespachoJson, ref response,"09", SeriesSunat, CorrelativoSunat,rc,rc2);
                            }
                        }
                    }

                    EditText5.SetInt(0);
                    EditText6.SetInt(0);

                    ///////////////////////////////
                    Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));

                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));
                    // FIN PROGRAMAR
                    Button0.Item.Click();
                }
                else
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    return;
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
              //  oForm.Freeze(false);
            }
        }

        private EntregaDespachoSLD GetObjDespachoSLD(string driverLicence, string ordenDespacho, string fechaDespacho,
               string nombreChofer, string ayudanteName, string placaVehiculo, string marcaVehiculo, string status,
               string SeriesSunat, string CorrelativoSunat, string ModalidadTansporte,
            string CodigoAgencia, string RucAgencia, string NombreAgencia, string DireccionAgencia, string TipoSalida, 
            string GuiaSalidaInicio, string GuiaSalidaEntrega)
        {
#if AD_PE
            EntregaDespachoSLD objDespachoSLD = new EntregaDespachoSLD();
            objDespachoSLD.U_SYP_MDFC = driverLicence;
            objDespachoSLD.U_SYP_DT_CORRDES = ordenDespacho;
            objDespachoSLD.U_SYP_DT_FCDES = fechaDespacho;
            objDespachoSLD.U_SYP_MDFN = nombreChofer;
            objDespachoSLD.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespachoSLD.U_SYP_MDVC = placaVehiculo;
            objDespachoSLD.U_SYP_MDVN = marcaVehiculo;
            objDespachoSLD.U_SYP_DT_ESTDES = status;
            objDespachoSLD.U_SYP_MDTD = SeriesSunat;
            objDespachoSLD.U_SYP_MDSD = "09";
            objDespachoSLD.U_SYP_MDCD = CorrelativoSunat;
            objDespachoSLD.U_SYP_FEGMT = ModalidadTansporte;
            objDespachoSLD.U_SYP_MDCT = CodigoAgencia;
            objDespachoSLD.U_SYP_MDRT = RucAgencia;
            objDespachoSLD.U_SYP_MDNT = NombreAgencia;
            objDespachoSLD.U_SYP_MDDT = DireccionAgencia;

            objDespachoSLD.U_VIS_AgencyCode = CodigoAgencia;
            objDespachoSLD.U_VIS_AgencyRUC = RucAgencia;
            objDespachoSLD.U_VIS_AgencyName = NombreAgencia;
            objDespachoSLD.U_VIS_AgencyDir = DireccionAgencia;

            objDespachoSLD.U_SYP_MDTS = TipoSalida;
            objDespachoSLD.U_SYP_FEGFI = GuiaSalidaInicio;
            objDespachoSLD.U_SYP_FEGNB = GuiaSalidaEntrega;
#endif
            return objDespachoSLD;

        }


        private void Button0_ClickBefore(object sboObject, SBOItemEventArg pVal,out bool BubbleEvent)
        {
            if (ValidacionCampos() == true)
            {
                BubbleEvent = true;
            }
            else
            {
                BubbleEvent = false;

                string MessageError = "";

                if (EditText0.Value == "")
                {
                    Sb1Messages.ShowError(AddonMessageInfo.MessageIdiomaMesage337);
                    MessageError += AddonMessageInfo.MessageIdiomaMesage337 + "\n";
                }
                if (EditText1.Value == "")
                {
                    Sb1Messages.ShowError(AddonMessageInfo.MessageIdiomaMesage338);
                    MessageError += AddonMessageInfo.MessageIdiomaMesage338 + "\n";
                }
                if (EditText2.Value == "")
                {
                    Sb1Messages.ShowError(AddonMessageInfo.MessageIdiomaMesage339);
                    MessageError += AddonMessageInfo.MessageIdiomaMesage339 + "\n";
                }
                if (EditText3.Value == "")
                {
                    Sb1Messages.ShowError(AddonMessageInfo.MessageIdiomaMesage340);
                    MessageError += AddonMessageInfo.MessageIdiomaMesage340 + "\n";
                }

                // Sb1Messages.ShowMessageBoxWarning(MessageError);
            }
        }

        public bool ValidacionCampos()
        {
            if (EditText0.Value != "" && EditText1.Value != "" && EditText2.Value != "" && EditText3.Value != "")
            {

                return true;

            }
            else
            {
                return false;
            }

        }

    }
}
