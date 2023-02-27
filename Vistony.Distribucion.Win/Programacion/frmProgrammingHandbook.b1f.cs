//#define AD_BO
//#define AD_PE
//#define AD_ES
#define AD_PY


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;
using SAPbouiCOM;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("frmProgramHand", "Programacion/frmProgrammingHandbook.b1f")]
    class frmProgrammingHandbook : UserFormBase
    {
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public frmProgrammingHandbook()
        {
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");

            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }

        }

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
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_11").Specific));
            this.Button0.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button0_ChooseFromListAfter);
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.EditText8.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText8_LostFocusAfter);
            this.EditText8.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText8_KeyDownAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_18").Specific));
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_19").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_20").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_21").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_22").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_23").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_24").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_27").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_28").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_30").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            idioma_BLL.FormatoGridProgramationHandbook(Grid0, Sb1Globals.Idioma);
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            idioma_BLL.GetPackIdiomafrmProgramationHandbook(oForm,Sb1Globals.Idioma,StaticText0,StaticText1,
            StaticText2,StaticText7,CheckBox0,Button1,Button2,Button3,StaticText8,StaticText9);
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;

            #if AD_PE
                        if (Sb1Globals.AdminPuntoEmision == "1")
                        {
                            StaticText10.Item.Visible = true;
                            ComboBox0.Item.Visible = true;
                            ComboBox0.Item.DisplayDesc = true;
                            Utils.LoadQuerySucursales(ref ComboBox0, string.Format(addonMessageInfo.QueryComboBoxSucursales, Sb1Globals.UserSignature));

                            ComboBox0.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
                        }
                        else
                        {
                            StaticText10.Item.Visible = false;
                            ComboBox0.Item.Visible = false;
                        }
            #endif

        }

        Idioma_BLL idioma_BLL = new Idioma_BLL();
        public string sucursalUsuarioLogin;
        public int filaseleccionada;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Form oForm;
        string usuario = Sb1Globals.UserName;
        public EntregaBLL entregaBLL = new EntregaBLL();

        private void Search()
        {
            string startDate = EditText0.Value.Trim();
            string endDate = EditText1.Value.Trim();
            string chofer = EditText2.Value;
            string agencia = "N";
            if (CheckBox0.Checked)
            {
                agencia = "Y";
            }

            try
            {
                oForm.Freeze(true);

                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_2");
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));
                oDT.Clear();
                double Peso = 0;
                /*Llamo a la clase EntregaBLL para ejecutar el SP para obtener la infomación*/
                using (EntregaBLL entregaBLL = new EntregaBLL())
                {
                  
#if AD_PE
                    if (Sb1Globals.AdminPuntoEmision == "1")
                    {
                        entregaBLL.ListPrevDespacho_Sucursal(startDate, endDate, ComboBox0.GetSelectedDescription(), chofer, agencia, ref oDT);
                    }
                    else
                    {
                        entregaBLL.ListPrevDespacho(startDate, endDate, usuario, chofer, agencia, ref oDT);
                    }
#else
                            entregaBLL.ListPrevDespacho(startDate, endDate, usuario, chofer, agencia, ref oDT);
#endif




                    for (int oRows = 0; oRows < oDT.Rows.Count; oRows++)
                    {
                        Peso += Convert.ToDouble(Grid0.DataTable.GetString("Peso", oRows));
                    }
                    /*Asigno el total de entregas*/
                    EditText9.SetInt(0);
                    /*Asigno el total de peso*/
                    EditText10.SetDouble(0);
                }
                FormatoGrilla();
                idioma_BLL.FormatoGridIdiomaProgramManual(Grid0, Sb1Globals.Idioma);
                Grid0.Sortable();
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
            }
        }
        public void FormatoGrilla()
        {
            /*Deshabilitar Edicion de columnas*/
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;


            /*Agrego el CheckBox a la Grilla*/
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            
            Grid0.Columns.Item("DocEntry").Visible = false; /*Oculto la Columna DocEntry de la Entrega*/
            Grid0.Columns.Item("Entrega").LinkedObjectType(Grid0, "Entrega", "15"); /*Asigno LinkedObject a la columna de Entrega*/
            
            Grid0.Columns.Item("CodChofer").LinkedObjectType(Grid0, "CodChofer", "CONDUC");
            Grid0.Columns.Item("CodChofer").Visible = false;/*Ocular columa de Código de chofer*/
            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "Chofer", "CONDUC"); /*Asigno el LinkedObject al chofer*/

            Grid0.Columns.Item("CodVehiculo").LinkedObjectType(Grid0, "CodVehiculo", "VEHICU"); /*Asigno el LinkedObject al Código del Vehículo*/
            Grid0.Columns.Item("CodVehiculo").Visible = false; /*Cambio de Titulo de Código de Vehículo*/
            
            Grid0.Columns.Item("Vehiculo").LinkedObjectType(Grid0, "Vehiculo", "VEHICU"); /*Asigno el LinkedObject al Vehículo*/

            Grid0.Columns.Item("CodAyudante").LinkedObjectType(Grid0, "CodAyudante", "OAYD"); /*Asigno el LinkedObject al Código del Ayudante*/
            Grid0.Columns.Item("CodAyudante").Visible = false; /*Cambio de Titulo de Código de Ayudante*/
        
           Grid0.Columns.Item("Ayudante").LinkedObjectType(Grid0, "Ayudante", "OAYD"); /*Asigno el LinkedObject al Vehículo*/

            Grid0.Columns.Item("DocEntry_Fac").Visible = false; /*Cambio de Titulo del DocEntry de la Factura*/
            Grid0.Columns.Item("NroFactura").LinkedObjectType(Grid0, "DocEntry_Fac", "13"); /*Asigno el LinkedObject de la factura*/
            
            Grid0.Columns.Item("Vendedor_ID").Visible = false; /*Ocultar el ID del vendedor*/
            Grid0.Columns.Item("Vendedor").LinkedObjectType(Grid0, "Vendedor_ID", "53"); /*Asigno el LinkedObject de la factura*/
            

            Grid0.AutoResizeColumns();
        }
        private void Button0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            double vehiculeCapacity = 0;
            string vehiculeName = string.Empty;
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("Code", 0, chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString());
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("Name", 0, chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString());

                        // licencia de chofer
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_CHLI", 0, chooseFromListEvent.SelectedObjects.GetValue("U_SYP_CHLI", 0).ToString());
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_FEGND", 0, chooseFromListEvent.SelectedObjects.GetValue("U_SYP_FEGND", 0).ToString());

                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_VIS_Vehiculo", 0, chooseFromListEvent.SelectedObjects.GetValue("U_VIS_Vehiculo", 0).ToString());

                        // obtiene el código de vehículo
                        oForm.GetDBDataSource("@SYP_VEHICU").SetString("Code", 0, Utils.GetVehiculeCode(oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo", 0), ref vehiculeCapacity, ref vehiculeName)); // // codigo del vehiculo

                        // capacidad del vehiculo
                        oForm.GetDBDataSource("@SYP_VEHICU").SetDouble("U_SYP_VEPM", 0, vehiculeCapacity);

                        //marca del vehiculo
                        oForm.GetDBDataSource("@SYP_VEHICU").SetString("U_SYP_VEMA", 0, vehiculeName);

                        // ayudante   
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_VIS_AydCode", 0, chooseFromListEvent.SelectedObjects.GetValue("U_VIS_AydCode", 0).ToString());

                        // codigo de ayudante
                        oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Code", 0, chooseFromListEvent.SelectedObjects.GetValue("U_VIS_AydCode", 0).ToString());
                        // nombre de ayudante
                        oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Name", 0, Utils.GetAyudandeName(chooseFromListEvent.SelectedObjects.GetValue("U_VIS_AydCode", 0).ToString().Trim()));

                    }
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }


        }
        private void EditText8_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            FindText(pVal);
        }
        private void FindText(SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textFind = string.Empty;
            string columnFind = string.Empty;

            try
            {
                textFind = EditText8.Value.Trim();

                if (textFind.Length < 8)
                {
                    filaseleccionada = -1;
                    return;
                }
                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                    {


                        if (Grid0.Columns.Item(1).TitleObject.Sortable)
                        {
                            columnFind = "Entrega";
                        }


                        string docnum = Grid0.DataTable.GetString("Entrega", row);
                        if (docnum == textFind)
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
            catch (Exception e)
            {
            }
        }
        private void EditText8_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }
        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            /*Buscar las Entregas en estado Volver a programar o Sin programar*/
            Search();
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
                // si hicieron clic en la columna para marcar o desmarcar
                if (pVal.ColUID == "Marca" && pVal.Row == -1)
                {

                    // obtengo los registros seleccionados
                    rowSelected = EditText9.GetInt();

                    // obtengo el peso total de los documentos seleccionados
                     totalWeight = Convert.ToDouble(EditText10.Value);




                    // debo marcar o desmarcar todo
                    Utils.CheckRows(oForm, Grid0, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText9.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados

                      EditText10.SetDouble(totalWeight);



                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    //EditText7.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText9.GetInt();
                    // obtengo el peso total de ala carga
                      totalWeight = Convert.ToDouble(EditText10.Value);

                    

                    rowIndex = pVal.Row;

                    isCheck = Grid0.DataTable.GetString("Marca", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                       weightSelected = Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex));






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
                    EditText9.SetInt(rowSelected);


                    // asigno el peso para los documentos seleccionados

                    EditText10.SetDouble(Math.Round(totalWeight, 2));



                }
            }

            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void Grid0_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Entrega")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Entrega")));
                col.LinkedObjectType = "15";// muestra la flecha amarilla asociada al objeto pedidos  
            }
        }
        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            string docEntry = string.Empty;
            SAPbouiCOM.EditTextColumn col = null;

            string CodChofer = string.Empty;
            string CodVehiculo = string.Empty;
            string CodAyudante = string.Empty;
            string DocEntry_Fac = string.Empty;
            string Vendedor_ID = string.Empty;


            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;
            // verifico en que columna hicieron click  en el linkedbutton

            if (pVal.ColUID == "Entrega")
            {
                docEntry = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText11.Value = docEntry;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_DeliveryNotes;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Entrega")));
                col.LinkedObjectType = string.Empty;// 
            }

            else if (pVal.ColUID == "Chofer")
            {
                CodChofer = Grid0.DataTable.GetValue("CodChofer", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText11.Value = CodChofer;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObjectType = "CONDUC";
                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Chofer")));
                col.LinkedObjectType = string.Empty;
            }

            else if (pVal.ColUID == "Vehiculo")
            {
                CodVehiculo = Grid0.DataTable.GetValue("CodVehiculo", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText11.Value = CodVehiculo;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObjectType = "VEHICU";
                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vehiculo")));
                col.LinkedObjectType = string.Empty;
            }

            else if (pVal.ColUID == "Ayudante")
            {
                CodAyudante = Grid0.DataTable.GetValue("CodAyudante", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText11.Value = CodAyudante;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObjectType = "OAYD";
                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Ayudante")));
                col.LinkedObjectType = string.Empty;
            }
            else if (pVal.ColUID == "NroFactura")
            {
                DocEntry_Fac = Grid0.DataTable.GetValue("DocEntry_Fac", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText11.Value = DocEntry_Fac;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NroFactura")));
                col.LinkedObjectType = string.Empty;
            }
            else if (pVal.ColUID == "Vendedor")
            {
                Vendedor_ID = Grid0.DataTable.GetValue("Vendedor_ID", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText11.Value = Vendedor_ID;

                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_SalesEmployee;
                EditText11.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vendedor")));
                col.LinkedObjectType = string.Empty;
            }

        }
        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }
        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // si van a programar despachos de agencia y no seleccionaron un chofer
            if ((oForm.GetUserDataSource("UD_2").Value.ToString().Trim() == "Y"))
                OnShowProgramacionAsignar(true);
            else
                OnShowProgramacionAsignar(false);
        }
        private void OnShowProgramacionAsignar(bool isVisible)
        {
            try
            {

                frmProgrammingHandbookAsignar form = new frmProgrammingHandbookAsignar(this, usuario, sucursalUsuarioLogin,Grid0);
                form.Show();

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message.ToString());

            }

        }
        string ErrorUpdateDespacho = "";
        public void UpdateRutaDespacho(Grid Grilla, string dispatchDate, string driverCode, string driverName, string assistantCode, string assistantName, 
            string vehiculeCode, string vehiculeName, string vehiculeBrand,
            string fechaDespacho2, string driverCode2, string driverName2, string driverLicence2, string ayudanteCode2, string ayudanteName2, string vehiculoCode2, string vehiculoPlaca2, string vehiculoMarca2
            )
        {
            string ret = string.Empty;

            ErrorUpdateDespacho = "";
            double vehiculeCapacity = 0;
            double documentsWeight = 0;
            string successQuantity = string.Empty;
            string failedQuantity = string.Empty;
            string documentsQuantity = string.Empty;
            

            documentsQuantity = EditText9.GetString(); //cantidad de documentos
            documentsWeight = EditText10.GetDouble(); // peso de los documentos

            vehiculeCode = Utils.GetVehiculeCode(vehiculeName, ref vehiculeCapacity, ref vehiculeBrand); // // codigo del vehiculo
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            vehiculeCode = Utils.GetVehiculeCode(vehiculeName, ref vehiculeCapacity, ref vehiculeBrand); // // codigo del vehiculo
            string  FormatovehiculeCapacity = vehiculeCapacity.ToString("N", Sb1Globals.cultura);
            string  FormatodocumentsWeight = documentsWeight.ToString("N", Sb1Globals.cultura);
            ret = entregaBLL.GuardarHojaDespacho(Grid0,dispatchDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName,
                FormatovehiculeCapacity, FormatodocumentsWeight, successQuantity, failedQuantity, documentsQuantity);


            if (ret == "Created")
            {
                Sb1Messages.ShowSuccess(string.Format(addonMessageInfo.MessageIdiomaMessage324(Sb1Globals.Idioma), driverName));
                UpdateDespacho(fechaDespacho2, driverCode2, driverName2, driverLicence2, ayudanteCode2, ayudanteName2, vehiculoCode2, vehiculoPlaca2, vehiculoMarca2);
            }
            else
            {
                Sb1Messages.ShowError(ret);
            }
            ErrorUpdateDespacho = ret;
        }
        public void UpdateDespacho(string dispatchDate, string driverCode, string driverName, string driverLicence, string assistantCode, string assistantName, string vehiculeCode, string vehiculeName, string vehiculeBrandName)
        {

            string pesoDespacho = this.EditText10.Value.Trim();

            //  string Licencia = string.Empty;// EditText5.Value;
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

                        oForm.Freeze(true);
                        //PROGRAMAR DESPACHO
                        SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                        for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                        {
                            // verifico si el documento se encuentra seleccionado
                            if (Grid0.DataTable.GetString("Marca", row) == "Y")
                            {
                                docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                                docNum = Grid0.DataTable.GetString("Entrega", row);

                                oDT.Clear();

                                // realmente necesito obtener este numero ???
                                using (EntregaBLL entregaBLL = new EntregaBLL())
                                {
                                    ordenDespacho = entregaBLL.ObtenerCorrelativoDespacho(oDT, dispatchDate);
                                }
                                //////////////////////// obtengo los datos para actualizar la guia ////////////////////////////
                                EntregaDespacho objDespacho = new EntregaDespacho();
                                objDespacho = GetObjDespacho(driverLicence, ordenDespacho, dispatchDate, driverName, assistantName, vehiculeName, vehiculeBrandName, "P", "PE", "-1", "1", dispatchDate, dispatchDate);
                                dynamic objDespachoJson = JsonConvert.SerializeObject(objDespacho);

                                Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage210(Sb1Globals.Idioma), docNum));
                                using (EntregaBLL entregaBLL = new EntregaBLL())
                                {
                                   entregaBLL.UpdateEstadoEntrega(docEntry, objDespachoJson, ref response);
                                }
                            }
                        }

                        EditText9.SetInt(0);
                        EditText10.SetInt(0);

                        ///////////////////////////////
                        Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));

                        Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));
                        // FIN PROGRAMAR
                        Button1.Item.Click();
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
                oForm.Freeze(false);
            }
        }

        private EntregaDespacho GetObjDespacho(string driverLicence, string ordenDespacho, string fechaDespacho,
               string nombreChofer, string ayudanteName, string placaVehiculo, string marcaVehiculo, string status,
               string U_SYP_FEEST, string U_SYP_FEESUNAT, string U_SYP_FEMEX, string U_SYP_FEGFI, string U_SYP_FEGFE)
        {
#if AD_PE
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_FEEST = U_SYP_FEEST;
            objDespacho.U_SYP_FEESUNAT = U_SYP_FEESUNAT;
            objDespacho.U_SYP_FEMEX = U_SYP_FEMEX;
            objDespacho.U_SYP_FEGFI = U_SYP_FEGFI;
            objDespacho.U_SYP_FEGFE = U_SYP_FEGFE;

            objDespacho.U_SYP_DT_ESTDES = status;
#elif AD_BO
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_DT_ESTDES = status;
#elif AD_ES
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_DT_ESTDES = status;
#elif AD_PY
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_DT_ESTDES = status;

#endif
            return objDespacho;

        }

        private void Form_LoadAfter(SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void Button3_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // valida que existan registros seleccionados
            if (EditText9.GetInt() > 0)
            {
                BubbleEvent = true;

#if AD_PE
                if (Sb1Globals.AdminPuntoEmision == "1")
                {
                    sucursalUsuarioLogin = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox0.GetSelectedDescription()));
                }
                else
                {

                }
#endif


            }
            else
            {
                BubbleEvent = false;

                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaAddonName(Sb1Globals.Idioma));
            }

        }

        private StaticText StaticText10;
        private ComboBox ComboBox0;
    }
}
