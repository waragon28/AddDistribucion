//#define AD_BO
#define AD_PE
//#define AD_MA
//#define AD_ES
//#define AD_CL
//#define AD_PY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Win.Asistentes;
using Vistony.Distribucion.Constans;
using Forxap.Framework.UI;
using Vistony.Distribucion.BO;

using Newtonsoft.Json;
using RestSharp;
using Vistony.Distribucion.DAL;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data;
using System.ComponentModel;

using Vistony.Distribucion.Win;
using Vistony.Distribucion.BLL;

namespace Vistony.Distribucion.Win.Formularios

{
    [FormAttribute("frmConsolidation", "Programacion/frmConsolidation.b1f")]

    public class frmConsolidation : BaseWizard
    {
        public int Contador = 0;
        public int filaseleccionada = -1;
        private SAPbouiCOM.StaticText StaticText0;
        Idioma_BLL idioma_BLL = new Idioma_BLL();
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.CheckBox CheckBox1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText0;
       
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.CheckBox CheckBox2;
        private SAPbouiCOM.CheckBox CheckBox3;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;

        public frmConsolidation()
        {
            // setea las fechas del día
            EditText4.Value = DateTime.Now.ToString("yyyyMMdd");
            EditText5.Value = DateTime.Now.ToString("yyyyMMdd");

            // sete en cero los documentos seleccionados y el peso
            EditText8.SetInt(0);
            EditText9.SetDouble(0);
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button5.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button5_ClickAfter);
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.CheckBox2 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_6").Specific));
            this.CheckBox3 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_5").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_11").Specific));
            this.Grid1.ClickBefore += new SAPbouiCOM._IGridEvents_ClickBeforeEventHandler(this.Grid1_ClickBefore);
            this.Grid1.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid1_LinkPressedBefore);
            this.Grid1.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid1_LinkPressedAfter);
            this.Grid1.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid1_ClickAfter);
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_2").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText7.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText7_LostFocusAfter);
            this.EditText7.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText7_KeyDownAfter);
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_18").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText10.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText10_ClickAfter);
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText11.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText11_ClickAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText12.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText12_ClickAfter);
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText13.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText13_ClickAfter);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_19").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
     

        }
        private void OnCustomInitialize()
        {
            idioma_BLL.FormatoGridConsolidado(Grid1, Sb1Globals.Idioma);
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            idioma_BLL.GetPackIdiomafrmConsolidation(Sb1Globals.Idioma,oForm, StaticText10,
            StaticText11, StaticText12,CheckBox2,CheckBox3, StaticText13,Button5, Button4, Button3,
            StaticText8, StaticText9);
            #if AD_PE
                if (Sb1Globals.AdminPuntoEmision=="1")
                {
                StaticText14.Item.Visible = true;
                ComboBox0.Item.Visible = true;
                ComboBox0.Item.DisplayDesc = true;
                Utils.LoadQuerySucursales(ref ComboBox0, string.Format(addonMessageInfo.QueryComboBoxSucursales,Sb1Globals.UserSignature));
              
                ComboBox0.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
            }
                else
                {
                StaticText14.Item.Visible = false;
                    ComboBox0.Item.Visible = false;
                }
#else   
                    StaticText14.Item.Visible = false;
                    ComboBox0.Item.Visible = false;
#endif
        }

        private  void SetFormatGrid()
        {
            EditText8.SetDouble(0);

            Grid1.AssignLineNro();
            Grid1.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid1.Columns.Item("DocEntry").Visible = false;
            Grid1.Columns.Item("Tipo").Visible = false;


#if AD_PE
                    Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "15");
#elif AD_BO
                    Grid1.Columns.Item(2).TitleObject.Caption = "Factura";
                    LinkedButton1.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                    Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "13");
#elif AD_ES
                    Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Factura", "15");
#elif AD_CL
                    Grid1.Columns.Item(2).TitleObject.Caption = "Factura";
                    LinkedButton1.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                    Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "15");
#elif AD_PY
                    Grid1.Columns.Item(2).LinkedObjectType(Grid1, "Entrega", "13");
#endif
            Grid1.Columns.Item("CodigoSN").LinkedObjectType(Grid1, "CodigoSN", "2");
            Grid1.Columns.Item("INDIC").Visible = false;



            Grid1.Columns.Item("Fecha").TitleObject.Caption = "Fecha Documento";
            Grid1.Columns.Item(0).TitleObject.Caption = "Marcar";

#if AD_PE
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#elif AD_BO
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Factura";
#elif AD_ES
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#elif AD_CL
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Factura";
#elif AD_PY
            Grid1.Columns.Item("FechaFinal").TitleObject.Caption = "Fecha Entrega";
#endif

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


            // ampliio el ancho de la columna
            Grid1.RowHeaders.Width += 15;
           

        }

        private void Grid1_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Entrega")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid1.Columns.Item("Entrega")));
#if AD_PE
                 col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos  
#elif AD_BO
                col.LinkedObjectType = "13";// muestra la flecha amariilla asociada al objeto pedidos 
#elif AD_ES
                 col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos 
#elif AD_CL
                 col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos 
#elif AD_PY
                col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos 
#endif

            }
        }

        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
        }


        /// <summary>
        /// Muestra la ventana para seleccionar el tipo de consolidado y consolidar las Guías  
        /// </summary>
        private void OnShowDatosConsolidadar()
        {
            try
            {
                string ID = oForm.UniqueID.ToString();
                frmConsolidarAsignar form = new frmConsolidarAsignar(this);
                form.Show();

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message.ToString());
               
            }
            
        }

        public bool  ValidarRegistrosMarcados ()
        {
            bool ret = true;

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoConsolidado"></param>
        /// <param name="fechaConsolidado"></param>
        public void UpdateEstadoConsolidadoEntrega(string tipoConsolidado, string fechaConsolidado)
        {
            int? docEntry = 0;
            string docNum = string.Empty;
            string response = string.Empty;
            bool isUpdate = false;
           
           try
            {
                oForm.Freeze(true);
                
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

                        Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage210(Sb1Globals.Idioma), docNum));

                        isUpdate = SetConsolidado(docEntry, ref response, jsonData);

                        if (isUpdate)
                        {
                            Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage209(Sb1Globals.Idioma), docNum ));
                        }
                        else
                        {
                            Sb1Messages.ShowError(string.Format(addonMessageInfo.MessageIdiomaMessage318(Sb1Globals.Idioma), docNum, response));
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
        private static bool SetConsolidado(int? docEntry, ref string response, dynamic jsonData)
        {
            bool ret;

            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                ret = entregaBLL.UpdateEstadoEntrega(docEntry, jsonData, ref response);
            }

            return ret;
        }
        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // valida que existan registros seleccionados
            if (EditText8.GetInt() > 0)
                BubbleEvent = true;
            else
            {
                BubbleEvent = false;

                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaAddonName(Sb1Globals.Idioma));
            }
        }
        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            int contarpedidossel = 0;
            try
            {
             OnShowDatosConsolidadar();
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {

            }

        }
        private void Button5_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Search( pVal);
        }
        private void Search(SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Freeze(true);
            string consolidado = string.Empty;
            string agencia = string.Empty;
            string desde = string.Empty;
            string hasta = string.Empty;
            string usuario = string.Empty;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            try
            {
                consolidado = "N";
                agencia = "N";
                desde = EditText4.Value.Trim();
                hasta = EditText5.Value.Trim();
                usuario = Sb1Globals.UserName;

                if (CheckBox2.Checked)
                {
                    consolidado = "Y";
                }
                if (CheckBox3.Checked)
                {
                    agencia = "Y";
                }

                Contador = 0;

                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));

                oForm.Freeze(true);
                oDT.Clear();
                using (EntregaBLL entregaBLL = new EntregaBLL())
                {
#if AD_PE
                    if (Sb1Globals.AdminPuntoEmision == "1")
                    {
                        entregaBLL.GetEntrega_Sucursal(ref oDT, desde, hasta, consolidado, agencia, ComboBox0.GetSelectedDescription() );
                    }
                    else
                    {
                        entregaBLL.GetEntrega(ref oDT, desde, hasta, consolidado, agencia, usuario);
                    }
#else
        entregaBLL.GetEntrega(ref oDT, desde, hasta, consolidado, agencia, usuario);
#endif
                }
                SetFormatGrid();
                idioma_BLL.FormatoGridIdioma(Grid1, Sb1Globals.Idioma);
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
                if (oDT.Rows.Count == 0)
                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaNotRowFound(Sb1Globals.Idioma));
                else
                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
                oForm.Freeze(false);
            }
        }
        private void Grid1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
                    rowSelected = EditText8.GetInt();

                    // obtengo el peso total de los documentos seleccionados
                    totalWeight = Convert.ToDouble(EditText9.Value);


                    // debo marcar o desmarcar todo
                    Utils.CheckRowsEx(oForm, Grid1, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText8.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
                    EditText9.SetDouble(totalWeight);
                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    EditText7.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText8.GetInt();
                    // obtengo el peso total de ala carga
                    totalWeight = Convert.ToDouble(EditText9.Value);

                    rowIndex = pVal.Row;

                    isCheck = Grid1.DataTable.GetString("Marca", Grid1.GetDataTableRowIndex(rowIndex)).ToString();
                    weightSelected = Grid1.DataTable.GetDouble("Peso", Grid1.GetDataTableRowIndex(rowIndex));



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
                    EditText8.SetInt( rowSelected);

                    // asigno el peso para los documentos seleccionados
                    EditText9.SetDouble(Math.Round(totalWeight,2));
                }
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }

        }
        private void Grid1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            //SE COMENTO ESTA VALIDACION PORQUE LOS USUARIOS EN GENERAL ENTRAN A LA ENTREGA PARA CAMBIAR EL CONSOLIDADO 

        // /*  
            string codigo = string.Empty;
            string consolidado = string.Empty;
            int rowIndex;
            int rowSelected;

            if (pVal.ColUID == "Marca")
            {
                rowSelected = pVal.Row;
                rowIndex = rowSelected;

                if (rowIndex > -1)
                {
                    consolidado = Grid1.DataTable.GetValue("Consolidado", Grid1.GetDataTableRowIndex(rowIndex)).ToString();
                }

                // si ya se encuentra consolidado no debe permitir seleccionar
                if (consolidado.Length > 0)
                {
                    BubbleEvent = false;
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage208(Sb1Globals.Idioma));
                }
            }
           // */
        }
        private void Grid1_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.EditTextColumn col = null;
            string codigo = string.Empty;
            string consolidado = string.Empty;
            int rowIndex ;
            int rowSelected;

            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "Entrega")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                rowSelected = pVal.Row;
                rowIndex = rowSelected;

                codigo = Grid1.DataTable.GetValue("DocEntry", Grid1.GetDataTableRowIndex(rowIndex)).ToString();
             


                EditText6.Value = codigo;

                EditText6.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);

                LinkedButton1.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid1.Columns.Item("Entrega")));
                col.LinkedObjectType = "";// 


            }

        }
        private void Grid1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }
        private void FindText(SAPbouiCOM.SBOItemEventArg pVal)
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
#elif AD_BO

#elif AD_ES

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
        private void EditText7_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            FindText(pVal);
        }
        private void EditText7_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;

        }

        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText10;

        private void StaticText10_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText11;

        private void StaticText11_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText12;

        private void StaticText12_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText13;

        private void StaticText13_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.ComboBox ComboBox0;
    }
}
