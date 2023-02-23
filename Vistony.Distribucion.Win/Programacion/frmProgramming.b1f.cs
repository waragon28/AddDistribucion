//#define AD_BO
#define AD_PE
//#define AD_ES
//#define AD_PY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.UI;
using Forxap.Framework.Extensions;

using Newtonsoft.Json;
using RestSharp;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Data;
using System.ComponentModel;
using Vistony.Distribucion.Win;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.Win.Asistentes;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.DAL;
using Vistony.Distribucion.BO;
using SAPbouiCOM;

namespace Vistony.Distribucion.Win.Formularios
{


    [FormAttribute("frmProgramming", "Programacion/frmProgramming.b1f")]
    class frmPrograming : BaseWizard
    {
        public string usuario;
        public int filaseleccionada;
        public string sucursalUsuarioLogin;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText7;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.Button Button3;
        private EditText EditText5;
        private StaticText StaticText1;
        private SAPbouiCOM.Button Button6;
        private StaticText StaticText10;
        private EditText EditText9;
        private EditText EditText17;
        private StaticText StaticText17;
        private EditText EditText18;

        public EntregaBLL entregaBLL = new EntregaBLL();
        public frmPrograming()
        {
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
            usuario = Sb1Globals.UserName;

            EditText0.Value = DateTime.Now.ToString("yyyyMMdd");
            EditText1.Value = DateTime.Now.ToString("yyyyMMdd");
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryDays);
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

#if AD_ES
            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursalUsuarioLogin;
            cfl1.SetConditions(cons1);

# elif AD_BO
            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursalUsuarioLogin;
            cfl1.SetConditions(cons1);
#elif AD_PY
            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursalUsuarioLogin;
            cfl1.SetConditions(cons1);
#elif AD_PE
            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursalUsuarioLogin = entregaBLL.ObtenerSucursal(oDT, usuario);
            }
            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                // Conductores se filtran por sucursal 
                SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
                SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
                SAPbouiCOM.Condition con1;
                con1 = cons1.Add();
                con1.Alias = "U_VIS_BranchCode";
                con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                con1.CondVal = Sb1Globals.IDSucursal;
                cfl1.SetConditions(cons1);
            }
            else
            {// Conductores se filtran por sucursal 
                SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
                SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
                SAPbouiCOM.Condition con1;
                con1 = cons1.Add();
                con1.Alias = "U_VIS_BranchCode";
                con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                con1.CondVal = sucursalUsuarioLogin;
                cfl1.SetConditions(cons1);

            }
#endif
            // setea en cero los documentos seleccionados y el peso
            EditText8.SetInt(0);
            EditText16.SetDouble(0);

            // setea las etiquetas
            StaticText8.Caption = LabelsForms.Label00001;
            StaticText9.Caption = LabelsForms.Label00002;
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText2.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText2_LostFocusAfter);
            this.EditText2.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText2_KeyDownAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_29").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.PressedAfter += new SAPbouiCOM._IGridEvents_PressedAfterEventHandler(this.Grid0_PressedAfter);
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_31").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_40").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_50").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_3").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText6.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText6_LostFocusAfter);
            this.EditText6.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText6_ChooseFromListAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_20").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_21").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_23").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("Item_24").Specific));
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_0").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("Item_19").Specific));
            this.Button6.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button6_ChooseFromListAfter);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("Item_27").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("Item_32").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_15").Specific));
            this.ComboBox1.ClickBefore += new SAPbouiCOM._IComboBoxEvents_ClickBeforeEventHandler(this.ComboBox1_ClickBefore);
            this.ComboBox1.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox1_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);
        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();

            usuario = Sb1Globals.UserName;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            sucursalUsuarioLogin = Utils.GetSucursal(oDT, usuario);

            StaticText0.SetUnderline();
            Grid0.AutoResizeColumns();
#if AD_PE
            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                StaticText5.Item.Visible = true;
                ComboBox1.Item.Visible = true;
                ComboBox1.Item.DisplayDesc = true;
                Utils.LoadQuerySucursales(ref ComboBox1, string.Format(addonMessageInfo.QueryComboBoxSucursales, Sb1Globals.UserSignature));

                ComboBox1.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
            }
            else
            {
                StaticText5.Item.Visible = false;
                ComboBox1.Item.Visible = false;
            }
#endif


        }
        

        private void EditText10_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText10.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPL", 0).ToString();
                        EditText11.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }
        
        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Search();
        }

        private void Search()
        {
            oForm.Freeze(true);
            
            string startDate = EditText0.Value.Trim();
            string endDate = EditText1.Value.Trim();
            string chofer = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_SYP_FEGND");
            string agencia = oForm.GetUserDataSource("UD_8").Value.Trim();

            try
            {

                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));
                oDT.Clear();

                using (EntregaBLL entregaBLL = new EntregaBLL())
                {
                    #if AD_PE
                        if (Sb1Globals.AdminPuntoEmision == "1")
                         {
                        entregaBLL.ListPrevDespacho_Sucursal(startDate, endDate, ComboBox1.GetSelectedDescription(), chofer, agencia, ref oDT);
                    }
                         else
                         {
                           entregaBLL.ListPrevDespacho(startDate, endDate, usuario, chofer, agencia, ref oDT);
                         }
                    #else
                            entregaBLL.ListPrevDespacho(startDate, endDate, usuario, chofer, agencia, ref oDT);
                    #endif

                }


                FormatoGrilla();
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
        void FormatoGrilla()
        {

            double totalWeight = 0;
            //        rowCount = Grid0.AssignLineNro();



            //   StaticText16.Caption = LabelsForms.Label00001;
            EditText8.SetValue(Utils.AssignLineNro(ref oForm, ref Grid0, ref totalWeight).ToString());
            EditText16.SetDouble(Math.Round(totalWeight, 2));
            //    StaticText17.Caption = LabelsForms.Label00002;

            //     Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item("DocEntry").Visible = false;
            Grid0.Columns.Item("DocEntry").Visible = false;
            Grid0.Columns.Item("DocEntry_Fac").Visible = false;
            Grid0.Columns.Item("CodChofer").Visible = false;
            Grid0.Columns.Item("CodVehiculo").Visible = false;
            Grid0.Columns.Item("CodAyudante").Visible = false;
            Grid0.Columns.Item("Vendedor_ID").Visible = false;

#if AD_PE
                Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Entrega";
#elif AD_PY
                Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Factura";
#elif AD_BO
            Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Factura";
#elif AD_ES
               Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Entrega";
#endif

            //Grid0.Columns.Item("Tipo").Visible = false;
            Grid0.Columns.Item(2).LinkedObjectType(Grid0, "Entrega", "15");
            Grid0.Columns.Item("CardCode").LinkedObjectType(Grid0, "CardCode", "2");
            //Grid0.Columns.Item("INDIC").Visible = false;
            Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Entrega";
            //Grid0.Columns.Item("DocNum").TitleObject.Caption = "Entrega";

            Grid0.Columns.Item("CardCode").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("CardName").TitleObject.Caption = "Nombre SN";
            Grid0.Columns.Item("Peso").TitleObject.Caption = "Peso Bruto";
            Grid0.Columns.Item("Peso").RightJustified = true;
            Grid0.Columns.Item("Saldo").RightJustified = true;
            Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";
            Grid0.Columns.Item("CodChofer").TitleObject.Caption = "Código Chofer";

            Grid0.Columns.Item("LicenciaChofer").TitleObject.Caption = "N° Licencia";
            Grid0.Columns.Item("MarcaVehiculo").TitleObject.Caption = "Marca";

            Grid0.Columns.Item("CodVehiculo").TitleObject.Caption = "Código Vehículo";
            Grid0.Columns.Item("Vehiculo").TitleObject.Caption = "Vehículo";

            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "Chofer", "CONDUC");
            Grid0.Columns.Item("Vehiculo").LinkedObjectType(Grid0, "CodVehiculo", "VEHICU");

            Grid0.Columns.Item("NroFactura").TitleObject.Caption = "Vehículo";


            Grid0.Columns.Item("Entrega").TitleObject.Caption = "N° Entrega";
            Grid0.Columns.Item("NumAtCard").TitleObject.Caption = "N° Guía Entrega";
            Grid0.Columns.Item("NroFactura").TitleObject.Caption = "N° Referencia";

            Grid0.Columns.Item("Entrega").LinkedObjectType(Grid0, "Entrega", "15"); // Pedidos
            Grid0.Columns.Item("NroFactura").LinkedObjectType(Grid0, "NroFactura", "13");// facturas

            Grid0.Columns.Item("CardCode").LinkedObjectType(Grid0, "CardCode", "2"); // socio de negocios
            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "Chofer", "CONDUC"); // Choferes
            Grid0.Columns.Item("Vehiculo").LinkedObjectType(Grid0, "Vehiculo", "VEHICU"); // Vehiculo
            Grid0.Columns.Item("Ayudante").LinkedObjectType(Grid0, "Ayudante", "OAYD"); // ayudante
            Grid0.Columns.Item("Vendedor").LinkedObjectType(Grid0, "Vendedor", "53"); // vendedor



            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();

            Grid0.RowHeaders.Width += 15;

        }
        private void FindText(SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textFind = string.Empty;
            string columnFind = string.Empty;

            try
            {
                textFind = EditText2.Value.Trim();

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
            catch
            {
            }
        }
        // busca un documento dentro de la grilla
        private void EditText2_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            FindText(pVal);
        }
        private void Grid0_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


            if (pVal.ColUID == "Entrega")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Entrega")));
                col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos  
            }

            else if (pVal.ColUID == "Chofer")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Chofer")));
                col.LinkedObjectType = "CONDUC";// muestra la flecha amariilla asociada al objeto pedidos
            }
            else if (pVal.ColUID == "Vehiculo")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vehiculo")));
                col.LinkedObjectType = "VEHICU";// muestra la flecha amariilla asociada al objeto pedidos
            }

            else if (pVal.ColUID == "Ayudante")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Ayudante")));
                col.LinkedObjectType = "OAYD";// muestra la flecha amariilla asociada al objeto pedidos
            }

            else if (pVal.ColUID == "NroFactura")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NroFactura")));
                col.LinkedObjectType = "13";// muestra la flecha amariilla asociada al objeto facturas  
            }

            else if (pVal.ColUID == "Vendedor")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vendedor")));
                col.LinkedObjectType = "53";// muestra la flecha amariilla asociada al objeto facturas  
            }

        }
        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            string docEntry = string.Empty;
            string code = string.Empty;
            SAPbouiCOM.EditTextColumn col = null;

            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;
            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "Entrega")
            {
                docEntry = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText4.Value = docEntry;

                EditText4.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_DeliveryNotes;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Entrega")));
                col.LinkedObjectType = string.Empty;// 
            }



            else if (pVal.ColUID == "NroFactura")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                docEntry = Grid0.DataTable.GetValue("DocEntry_Fac", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText4.Value = docEntry;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NroFactura")));
                col.LinkedObjectType = string.Empty;// 
            }

            else if (pVal.ColUID == "Chofer")
            {
                code = Grid0.DataTable.GetValue("CodChofer", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText4.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "CONDUC";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Chofer")));
                col.LinkedObjectType = string.Empty;// 

            }

            else if (pVal.ColUID == "Vehiculo")
            {
                code = Grid0.DataTable.GetValue("CodVehiculo", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText4.Value = code;

                //  EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "VEHICU";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vehiculo")));
                col.LinkedObjectType = string.Empty;// 

            }

            else if (pVal.ColUID == "Ayudante")
            {
                code = Grid0.DataTable.GetValue("CodAyudante", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText4.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "OAYD";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Ayudante")));
                col.LinkedObjectType = string.Empty;// 

            }


            else if (pVal.ColUID == "Vendedor")
            {
                code = Grid0.DataTable.GetValue("Vendedor_ID", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText4.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "53";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vendedor")));
                col.LinkedObjectType = "";// 

            }

        }
        private bool ValidarCampos(string Chofer, string fechaDespacho, string Placa, string Peso, string Ayudante)
        {
            if (Chofer == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage303(Sb1Globals.Idioma));
                if (Chofer == "")
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage303(Sb1Globals.Idioma));
                    //EditText9.SetFocus();
                    return false;
                }
                //EditText9.SetFocus();
                return false;
            }
            if (Placa == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage304(Sb1Globals.Idioma));
                //EditText10.SetFocus();
                return false;
            }
            if (Ayudante == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage305(Sb1Globals.Idioma));
                //EditText12.SetFocus();
                return false;
            }
            if (fechaDespacho == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage306(Sb1Globals.Idioma));
                // EditText13.SetFocus();
                return false;
            }


            return true;
        }
        public void UpdateDespacho(string dispatchDate, string driverCode = "", string driverName = "", string driverLicence = "", string assistantCode = "", string assistantName = "", string vehiculeCode = "", string vehiculeName = "", string vehiculeBrandName = "")
        {

            string pesoDespacho = this.EditText16.Value.Trim();

            //  string Licencia = string.Empty;// EditText5.Value;
            bool isUpdated = false;
            string response = string.Empty;

            try
            {

                int ContarMarcados = 0;

                if (ContarMarcados == 0)
                {
                    string docNum = string.Empty;
                    int? docEntry = 0;
                    //  string choferCode = string.Empty;
                    //  string choferName = string.Empty;
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

                            // driverCode = Grid0.DataTable.GetString("CodChofer", row);
                            //  driverName = Grid0.DataTable.GetString("Chofer", row);
                            //  choferLicencia = Grid0.DataTable.GetString("LicenciaChofer", row);

                            //   vehiculoMarca = Grid0.DataTable.GetString("MarcaVehiculo", row);
                            //   ayudanteName = Grid0.DataTable.GetString("Ayudante", row);

                            //    vehiculoPlaca = Grid0.DataTable.GetString("Vehiculo", row);

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
                                isUpdated = entregaBLL.UpdateEstadoEntrega(docEntry, objDespachoJson, ref response);
                            }


                            if (isUpdated)
                            {
                                //HistoricoDespachos objHistorico = new HistoricoDespachos();
                                //objHistorico = AsignaDatosObject(docEntry, NumDespacho.ToString(), "P", docNum, dispatchDate, driverCode, driverName, vehiculoPlaca, ayudanteName, "", usuario);
                                //dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                                //string rpta = "";
                                //EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                                //Sb1Messages.ShowMessage(string.Format( AddonMessageInfo.Message211,docNum,driverName));
                                //NumDespacho++;
                            }
                            else
                            {
                                Sb1Messages.ShowError(response);
                            }


                        }
                    }

                    EditText8.SetInt(0);
                    EditText16.SetInt(0);
                    //// EditText15.Value = docNum;
                    // ///////////////GRABAR CABECERA DE HISTORIAL////////////////

                    // HistoricoDespachosCabecera objHistoricoC = new HistoricoDespachosCabecera();
                    // objHistoricoC = AsignaDatosObjectCabecera(docNum, driverCode, driverName, vehiculoPlaca, dispatchDate);
                    // dynamic jsonHist1 = JsonConvert.SerializeObject(objHistoricoC);
                    // string rpta1 = "";
                    // EntregaDAL.GrabarHistorial(jsonHist1, out rpta1);


                    ///////////////////////////////
                    Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));

                    // DEBO GENERAR o BUSCAR EL DOCUMENTO DE SALIDA DEL CHOFER VEHICULO "HOJA DE DESPACHO DEL CHOFER"
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
                oForm.Freeze(false);
            }
        }


        //  public void UpdateRutaDespacho(string dispatchDate, string driverCode = "", string driverName = "")

        public void AddRutaDespacho(string dispatchDate, string driverCode, string driverName, string assistantCode, string assistantName, string vehiculeCode, string vehiculeName, string vehiculeBrand)
        {
            string ret = string.Empty;

            //   string dispatchDate = string.Empty;
            //  string driverCode = string.Empty;
            //  string driverName = string.Empty;
            //  string assistantCode = string.Empty;
            //  string assistantName = string.Empty;

            //   string vehiculeCode = string.Empty;
            //  string vehiculeName = string.Empty;
            //  string vehiculeBrand = string.Empty;

            double? vehiculeCapacity = 0;
            string documentsWeight = "0";
            string successQuantity = string.Empty;
            string failedQuantity = string.Empty;
            string documentsQuantity = string.Empty;



            // leo datos para la cabecera

            //  dispatchDate = DateTime.Now.ToString("yyyyMMdd");// fecha del documento HOja de despacho
            //  driverCode = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Code"); // codigo del chofer
            //  driverName = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Name"); // nombre del chofer

            //  assistantCode = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Code"); // codigo de ayudante
            //  assistantName = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Name"); // nombre de ayudante


            documentsQuantity = EditText8.GetString(); //cantidad de documentos
            documentsWeight = EditText16.GetString(); // peso de los documentos
                                                      //   vehiculeName = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo"); // Placa del vehiculo

            vehiculeCode = Utils.GetVehiculeCode(vehiculeName, ref vehiculeCapacity, ref vehiculeBrand); // // codigo del vehiculo

            ret = entregaBLL.GuardarHojaDespacho(Grid0, dispatchDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName, vehiculeCapacity,
               documentsWeight, successQuantity, failedQuantity, documentsQuantity);

            if (ret == "Created")
            {
                Sb1Messages.ShowSuccess(string.Format(addonMessageInfo.MessageIdiomaMessage324(Sb1Globals.Idioma), driverName));
            }
            else
            {
                Sb1Messages.ShowError(ret);
            }

        }


        private HistoricoDespachos AsignaDatosObject(string docentry, string NumDespacho, string Estado,
                                    string OrdenDespacho, string fechaDespacho, string Chofer, string NombreChofer,
                                    string Placa, string Ayudante, string Ocurrencias, string Usuario)
        {
            HistoricoDespachos obj = new HistoricoDespachos();
            obj.Code = docentry;
            obj.U_NumLine = NumDespacho;
            obj.U_Status = Estado;
            obj.U_OrderNum = OrdenDespacho;
            obj.U_DateProgram = fechaDespacho;
            obj.U_DriverCode = Chofer;
            obj.U_DriverName = NombreChofer;
            obj.U_VehicleCode = Placa;
            obj.U_Assistent = Ayudante;
            obj.U_Comments = Ocurrencias;
            obj.U_User = Usuario;

            return obj;

        }

        private HistoricoDespachosCabecera AsignaDatosObjectCabecera(string OrdenDespacho, string Chofer, string NombreChofer,
                            string fechaDespacho, string Placa)
        {
            HistoricoDespachosCabecera obj = new HistoricoDespachosCabecera();
            obj.Code = OrdenDespacho;
            obj.U_VIS_Date = fechaDespacho;
            obj.U_VIS_CodDriver = Chofer;
            obj.U_VIS_NameDriver = NombreChofer;
            obj.U_VehicleCode = Placa;
            return obj;

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





        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (Convert.ToInt32(EditText1.Value) < Convert.ToInt32(EditText0.Value))
            {
                BubbleEvent = false;
                Sb1Messages.ShowError(string.Format(addonMessageInfo.MessageIdiomaMessage120(Sb1Globals.Idioma), EditText1.Value));

            }
            // si
            else if (CheckBox0.Checked == false)
            {
                if (EditText6.Value.Trim().Length == 0)
                {
                    BubbleEvent = false;
                    Sb1Messages.ShowError(string.Format(addonMessageInfo.MessageIdiomaMessage303(Sb1Globals.Idioma), EditText1.Value));
                }

            }
        }



        private void Grid0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //try
            //{
            //    if (pVal.ColUID == "''")
            //    {
            //        EditText0.SetFocus();
            //        Decimal Sumar = 0;
            //        Sumar = Convert.ToDecimal(EditText8.Value);
            //        int rowSelected = pVal.Row;
            //        int rowIndex = rowSelected;
            //        string Codigo = Grid0.DataTable.GetValue("''", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
            //        if (Codigo == "Y")
            //        {
            //            Sumar += Convert.ToDecimal(Grid0.DataTable.GetValue("Peso", Grid0.GetDataTableRowIndex(rowIndex)).ToString());
            //        }
            //        else
            //        {
            //            if (Sumar > 0)
            //            {
            //                Sumar -= Convert.ToDecimal(Grid0.DataTable.GetValue("Peso", Grid0.GetDataTableRowIndex(rowIndex)).ToString());
            //            }
            //        }
            //        EditText8.Value = Sumar.ToString();
            //    }
            //}
            //catch (Exception e)
            //{

            //}

        }



        private void EditText6_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }











        private void EditText6_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // si borran el codigo del chofer limpio las casillas con los demas datos
            if (EditText6.Value == string.Empty)
            {


                oForm.GetDBDataSource("@SYP_CONDUC").SetString("Code", 0, string.Empty);
                oForm.GetDBDataSource("@SYP_CONDUC").SetString("Name", 0, string.Empty);
                oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_CHLI", 0, string.Empty);
                oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_FEGND", 0, string.Empty);
                oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_VIS_Vehiculo", 0, string.Empty);

                oForm.GetDBDataSource("@SYP_VEHICU").SetString("U_SYP_VEPM", 0, string.Empty);
                oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Code", 0, string.Empty);
                oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Name", 0, string.Empty);
            }

        }

        private void EditText2_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            filaseleccionada = -1;
        }









        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {

            // valida que existan registros seleccionados
            if (EditText8.GetInt() > 0)
                BubbleEvent = true;
            else
            {
                BubbleEvent = false;

                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
            }
        }


        private void OnShowProgramacionAsignar(bool isVisible)
        {
            string choferCode = string.Empty;
            string choferName = string.Empty;
            string choferLicencia = string.Empty;

            string vehiculoCode = string.Empty;
            string vehiculoMarca = string.Empty;
            string vehiculoPlaca = string.Empty;

            string ayudanteCode = string.Empty;
            string ayudanteName = string.Empty;

            //codigo del conductor
            choferCode = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Code", 0);

            // nombre del chofer
            choferName = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Name", 0);

            // licencia de chofer
            choferLicencia = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_SYP_CHLI", 0);


            // codigo del ayudante
            ayudanteCode = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Code", 0);
            // nombre del ayudante
            ayudanteName = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Name", 0);



            //codigo del vehiculo
            vehiculoCode = oForm.GetDBDataSource("@SYP_VEHICU").GetString("Code", 0);

            //marca del vehiculo
            vehiculoMarca = oForm.GetDBDataSource("@SYP_VEHICU").GetString("U_SYP_VEMA", 0);

            // placa del vehiculo
            vehiculoPlaca = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo", 0);

            // nombre de ayudante
            ayudanteName = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Name", 0);

            try
            {

                frmProgramacionAsignar form = new frmProgramacionAsignar(this, usuario, sucursalUsuarioLogin, isVisible, choferCode, choferName, choferLicencia, vehiculoCode, vehiculoMarca, vehiculoPlaca, ayudanteCode, ayudanteName);
                form.Show();

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message.ToString());

            }

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // si van a programar despachos de agencia y no seleccionaron un chofer
            if ((oForm.GetUserDataSource("UD_8").Value.ToString().Trim() == "Y") && (EditText6.Value.Trim().Length == 0))
                OnShowProgramacionAsignar(true);
            else
                OnShowProgramacionAsignar(false);

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
                    rowSelected = EditText8.GetInt();

                    // obtengo el peso total de los documentos seleccionados
#if AD_PY
                    totalWeight = Convert.ToDouble(EditText16.Value, System.Globalization.CultureInfo.InvariantCulture);
#else
                    totalWeight = Convert.ToDouble(EditText16.Value);
#endif

                    // debo marcar o desmarcar todo
                    Utils.CheckRows(oForm, Grid0, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText8.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
                    EditText16.SetDouble(Convert.ToDouble(totalWeight,System.Globalization.CultureInfo.InvariantCulture));
#if AD_PY
                    EditText16.SetDouble(Convert.ToDouble(totalWeight, System.Globalization.CultureInfo.InvariantCulture));
#else
                   EditText16.SetDouble(Convert.ToDouble(totalWeight));
#endif

                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    EditText7.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText8.GetInt();
                    // obtengo el peso total de ala carga

#if AD_PY
                    totalWeight = Convert.ToDouble(EditText16.Value, System.Globalization.CultureInfo.InvariantCulture);
#else
                totalWeight = Convert.ToDouble(EditText16.Value);
#endif

                    rowIndex = pVal.Row;


                    isCheck = Grid0.DataTable.GetString("Marca", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                    //Convert.ToDouble(totalWeight,System.Globalization.CultureInfo.InvariantCulture)
#if AD_PY
                    weightSelected = Convert.ToDouble(Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex)), System.Globalization.CultureInfo.InvariantCulture);
#else
                  weightSelected = Convert.ToDouble(Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex)));
#endif

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
                    EditText8.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
#if AD_PY
                    EditText16.SetDouble(Convert.ToDouble(Math.Round(totalWeight, 2), System.Globalization.CultureInfo.InvariantCulture));
#else
                    EditText16.SetDouble(Convert.ToDouble(Math.Round(totalWeight, 2)));
#endif

                    //, System.Globalization.CultureInfo.InvariantCulture)
                }
            }

            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
        }


        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            // throw new System.NotImplementedException();

        }




        public void EnviarData(SAPbouiCOM.Grid dt, string U_DriverCode,
        string U_DriverName, string U_AssistantCode, string U_AssistantName,
        string U_VehiculeCode, string U_VehiculeName, string U_DocumentsWeight,
        string U_SuccessQuantity, string U_FailedQuantity, string U_DocumentsQuantity)

        {
            //using (EntregaBLL entregaBLL = new EntregaBLL())
            //{
            //    entregaBLL.ObtenerCabeceraDocuemtProgramacion(dt, U_DriverCode, U_DriverName, U_AssistantCode,
            //  U_AssistantName, U_VehiculeCode, U_VehiculeName, U_DocumentsWeight, U_SuccessQuantity,
            //  U_FailedQuantity, U_DocumentsQuantity);
            //}
        }


        private void EditText9_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        // oForm.GetDBDataSource("@SYP_CONDUC").SetString("Name", 0, chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString());
                        //EditText17.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }

        }


        private void Button6_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            double? vehiculeCapacity = 0;
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

                        //          Utils.GetVehiculeCode(oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo",0) , ref vehiculeCapacity, ref vehiculeName); // // codigo del vehiculo

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

        private void Button5_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button5_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            // UpdateRutaDespacho();
        }

        private EditText EditText4;
        private StaticText StaticText5;
        private SAPbouiCOM.ComboBox ComboBox1;

        private void ComboBox1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            cfl.SetConditions(null);
            Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = Sb1Globals.IDSucursal;
            cfl1.SetConditions(cons1);
        }

        private void ComboBox1_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {

            BubbleEvent = true;
        }
    }// fin de la clase

}// fin del namespace