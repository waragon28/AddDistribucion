﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmConsolidationSLD", "Programacion/frmConsolidationSLD.b1f")]
    class frmConsolidationSLD : UserFormBase
    {
        public frmConsolidationSLD()
        {
        }
        public SAPbouiCOM.Form oForm;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();

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
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_5").Specific));
            this.CheckBox1 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_6").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText2.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText2_KeyDownAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_9").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_10").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_11").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText5.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText5_ChooseFromListAfter);
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.EditText6.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText6_ChooseFromListAfter);
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_22").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_23").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_24").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_25").Specific));
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
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.CheckBox CheckBox1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void EditText5_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText5.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                //Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

        private void EditText6_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText6.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

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
            string Consolidado = "N";
            string Agencia = "N";
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            try
            {
                desdeAlmacen = EditText5.Value.Trim();
                hastaAlmacen = EditText6.Value.Trim();

                desde = EditText0.Value.Trim();
                hasta = EditText1.Value.Trim();

                if (CheckBox0.Checked)
                {
                    Consolidado = "Y";
                }

                if (CheckBox1.Checked)
                {
                    Agencia = "Y";
                }

                 Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));

                oDT.Clear();

                using (EntregaBLL entregaBLL = new EntregaBLL())
                {

                    entregaBLL.GetConsolidadoSLD(ref oDT, desde, hasta, desdeAlmacen, hastaAlmacen, addonMessageInfo.QueryObtenerSLDConsol, Consolidado, Agencia);

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
            EditText3.SetDouble(0);
            EditText4.SetDouble(0);

            Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;

#if AD_PE

#else
            Grid0.Columns.Item("DocNum").LinkedObjectType(Grid0, "DocNum", "67");
            Grid0.Columns.Item("DocEntry").LinkedObjectType(Grid0, "DocEntry", "67");
#endif

            // Grid0.Columns.Item("Docntry").Visible = false;
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();
            
            // ampliio el ancho de la columna
            Grid0.RowHeaders.Width += 15;
            
        }

        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;

        private void Grid0_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "DocNum")
            {
                Grid0_LinkPressedBefore(sboObject, pVal,true);

                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("DocNum")));
                col.LinkedObjectType = "67";// muestra la flecha amariilla asociada al objeto pedidos  
            }
        }

        private void Grid0_EventBre(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "DocNum")
            {
                Grid0_LinkPressedBefore(sboObject,pVal, true);

                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("DocNum")));
                col.LinkedObjectType = "67";// muestra la flecha amariilla asociada al objeto pedidos  
            }
        }

        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, bool BubbleEvent)
        {
            BubbleEvent = true;
            string docEntry = string.Empty;
            string code = string.Empty;
            SAPbouiCOM.EditTextColumn col = null;

            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;
            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "DocNum")
            {
                docEntry = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText7.Value = docEntry;

                EditText7.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton2.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_StockTransfers;
                LinkedButton2.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("DocNum")));
                col.LinkedObjectType = string.Empty;// 
            }


        }

        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.LinkedButton LinkedButton2;

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
                    rowSelected = EditText3.GetInt();

                    // obtengo el peso total de los documentos seleccionados
#if AD_PY
                    totalWeight = Convert.ToDouble(EditText4.Value, Sb1Globals.cultura);
#else
                    totalWeight = Convert.ToDouble(EditText4.Value, Sb1Globals.cultura);
#endif

                    // debo marcar o desmarcar todo
                    Utils.CheckRows(oForm, Grid0, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText3.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
                    EditText4.SetDouble(Convert.ToDouble(EditText4.Value, Sb1Globals.cultura));
#if AD_PY
                    EditText4.SetDouble(Convert.ToDouble(EditText4.Value, Sb1Globals.cultura));
#else
                    EditText4.SetDouble(Convert.ToDouble(totalWeight, Sb1Globals.cultura));
#endif

                }
                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    EditText7.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText3.GetInt();
                    // obtengo el peso total de ala carga

#if AD_PY
                    totalWeight = Convert.ToDouble(EditText4.Value, Sb1Globals.cultura);
#else
                    totalWeight = Convert.ToDouble(EditText4.Value, Sb1Globals.cultura);
#endif

                    rowIndex = pVal.Row;


                    isCheck = Grid0.DataTable.GetString("Marca", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                    //Convert.ToDouble(totalWeight,System.Globalization.CultureInfo.InvariantCulture)
#if AD_PY
                    weightSelected = Convert.ToDouble(Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex)), Sb1Globals.cultura);
#else
                    weightSelected = Convert.ToDouble(Grid0.DataTable.GetDouble("Peso", Grid0.GetDataTableRowIndex(rowIndex)), Sb1Globals.cultura);
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
                    EditText3.SetInt(rowSelected);

                    // asigno el peso para los documentos seleccionados
#if AD_PY
                    EditText4.SetDouble(Convert.ToDouble(Math.Round(totalWeight, 2), Sb1Globals.cultura));
#else
                    EditText4.SetDouble(Convert.ToDouble(Math.Round(totalWeight, 2), Sb1Globals.cultura));
#endif

                    //, System.Globalization.CultureInfo.InvariantCulture)
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string ID = oForm.UniqueID.ToString();
            frmConsolidationSLDAsignar form = new frmConsolidationSLDAsignar(this);
            form.Show();
        }

        public void UpdateEstadoConsolidadoSLD(string tipoConsolidado, string fechaConsolidado)
        {
            int? docEntry = 0;
            string docNum = string.Empty;
            string response = string.Empty;
            bool isUpdate = false;

            try
            {
                oForm.Freeze(true);

                for (int row = 0; row < Grid0.Rows.Count; row++)
                {
                    if (Grid0.DataTable.GetString("Marca", row) == "Y")
                    {
                        docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                        docNum = Grid0.DataTable.GetString("DocNum", row);


                        ///creo el objeto que será serializado
                        SolicitudTraslado obj = new SolicitudTraslado();
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

                            Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage209(Sb1Globals.Idioma), docNum));
                        }
                        else
                        {
                            Sb1Messages.ShowError(string.Format(addonMessageInfo.MessageIdiomaMessage318(Sb1Globals.Idioma), docNum, response));
                        }
                    }
                }

                // sete en cero los documentos seleccionados y el peso
                EditText3.SetInt(0);
                EditText4.SetDouble(0);

                Button0.Item.Click();
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
                ret = entregaBLL.UpdateEstadoSLD(docEntry, jsonData, ref response);
            }

            return ret;
        }

        private void Grid0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, bool BubbleEvent)
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
                    consolidado = Grid0.DataTable.GetValue("Consolidado", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                }

                // si ya se encuentra consolidado no debe permitir seleccionar
                if (consolidado.Length > 0)
                {
                    BubbleEvent = false;
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage208(Sb1Globals.Idioma));
                }
            }
        }

        private void EditText2_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            FindText(pVal);
        }
        int filaseleccionada;
        private void FindText(SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textoFind = string.Empty;
            string docNum = string.Empty;

            try
            {
                textoFind = EditText2.Value.Trim();
                

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
    }
}