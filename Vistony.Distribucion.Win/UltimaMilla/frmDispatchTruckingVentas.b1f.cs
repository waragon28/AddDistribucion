using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;
using System.Drawing;
using Forxap.Framework.UI;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("dis_DispaTruckVent", "UltimaMilla/frmDispatchTruckingVentas.b1f")]
    class frmDispatchTruckingVentas : UserFormBase
    {
        EntregaBLL entregaBLL = new EntregaBLL();
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText0;
        SAPbouiCOM.Form oForm;
        public int filaseleccionada = -1;

        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public frmDispatchTruckingVentas()
        {
            EditText1.SetValue("0000");
            EditText2.SetValue("2359");
            EditText0.Value = DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_12").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_21").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_23").Specific));
            this.Grid0.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.Grid0_DoubleClickAfter);
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
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
            Grid0.AutoResizeColumns();
            Grid1.AutoResizeColumns();
            //Utils.LoadQueryDynamic(ref ComboBox0,string.Format("CALL SP_VIS_DIS_GET_TRACKER_USER_LIST('{0}')", Sb1Globals.UserName));
            Utils.LoadQueryDynamic(ref ComboBox1, "SELECT \"Code\",\"Name\" FROM OUDP ");
            ComboBox1.Select(Sb1Globals.Departamento,SAPbouiCOM.BoSearchKey.psk_ByValue);
            FormatoEtiquetas();
        }


        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
        }
        
        private void EditText3_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Freeze(true);
            SAPbouiCOM.DataTable dt_2 = oForm.GetDataTable("DT_2");
            SAPbouiCOM.DataTable dt_D = oForm.GetDataTable("DT_3");
            entregaBLL.SP_VIS_DIS_GET_TRACKER_C_VENTAS(ref dt_2, EditText0.Value, Convert.ToInt32(EditText1.Value),
                Convert.ToInt32(EditText2.Value), ComboBox1.Value);
            Formato_Cabecera();
            Grid0.ReadOnlyColumns();
            Grid0.Sortable();

            int Entregados = 0;
            int Fallidos = 0;
            int Ruta = 0;
            int Total_Entregas = 0;
            /*DETALLE*/
            for (int i = 0; i < dt_2.Rows.Count; i++)
            {
                if (EditText1.Value == null || EditText1.Value == "")
                {
                    EditText1.Value = "00:00";
                }
                if (EditText2.Value == null || EditText2.Value == "")
                {
                    EditText2.Value = "24:59";
                }

                int HORA_INI = Convert.ToInt32(EditText1.Value);
                int HORA_FIN = Convert.ToInt32(EditText2.Value);
                string Cod_Vendedor = dt_2.GetValue("Codigo Vendedor", i).ToString();
                string Fecha = EditText0.Value;

                entregaBLL.SP_VIS_DIS_GET_TRACKER_D_VENTAS(ref dt_D, Fecha, HORA_INI, HORA_FIN, Cod_Vendedor, ComboBox1.Value);

                
                for (int oRows = 0; oRows < dt_D.Rows.Count; oRows++)
                {
                    if (dt_D.GetValue("Estado", oRows).ToString() == "Entregado")
                    {
                        Entregados += 1;
                    }
                    else if (dt_D.GetValue("Estado", oRows).ToString() == "Programado")
                    {
                        Ruta += 1;
                    }
                    else
                    {
                        Fallidos += 1;
                    }
                }
               
                Total_Entregas += dt_D.Rows.Count;
            }
            dt_D.Clear();
            StaticText10.Caption = (Entregados + Fallidos) + " / " + Convert.ToString(Total_Entregas);

            decimal Calculo_porcentaje = (100 * (Entregados + Fallidos));
            decimal porcentaje = decimal.Round(Calculo_porcentaje / Total_Entregas, 2);

            StaticText11.Caption = Convert.ToString(Entregados);
            StaticText12.Caption = Convert.ToString(Ruta);
            StaticText13.Caption = Convert.ToString(Fallidos);
            StaticText9.Caption = (porcentaje.ToString()) + " %";

            if (porcentaje < 30.99m)
            {
                StaticText9.SetColor(Color.Red);
            }
            else if (porcentaje >= 30 && porcentaje <= 60)
            {
                StaticText9.SetColor(Color.Maroon);
            }
            else
            {
                StaticText9.SetColor(Color.Green);
            }
            Grid0.Sortable();
            Grid1.Sortable();
            oForm.Freeze(false);
        }
        public void FormatoEtiquetas()
        {
            StaticText3.Caption = "PORCENTAJE";
            StaticText3.Item.FontSize = 20;
            StaticText3.SetBold();
            StaticText3.SetColor(Color.White);
            StaticText3.Item.BackColor = ColorTranslator.ToOle(Color.LightGreen);
            StaticText3.Item.Height = 40;
            StaticText3.Item.Width = 150;

            StaticText5.Caption = "AVANCE";
            StaticText5.Item.FontSize = 20;
            StaticText5.SetBold();
            StaticText5.SetColor(Color.White);
            StaticText5.Item.BackColor = ColorTranslator.ToOle(Color.Blue);
            StaticText5.Item.Height = 40;
            StaticText5.Item.Width = 100;

            StaticText6.Caption = "ENTREGADO";
            StaticText6.Item.FontSize = 20;
            StaticText6.SetBold();
            StaticText6.SetColor(Color.White);
            StaticText6.Item.BackColor = ColorTranslator.ToOle(Color.Green);
            StaticText6.Item.Height = 40;
            StaticText6.Item.Width = 130;

            StaticText7.Caption = "EN RUTA";
            StaticText7.Item.FontSize = 20;
            StaticText7.SetBold();
            StaticText7.SetColor(Color.White);
            StaticText7.Item.BackColor = ColorTranslator.ToOle(Color.Maroon);
            StaticText7.Item.Height = 40;
            StaticText7.Item.Width = 100;

            StaticText8.Caption = "FALLIDO";
            StaticText8.Item.FontSize = 20;
            StaticText8.SetBold();
            StaticText8.SetColor(Color.White);
            StaticText8.Item.Height = 40;
            StaticText8.Item.Width = 110;
            StaticText8.Item.BackColor = ColorTranslator.ToOle(Color.Red);

            SetPercentage(0);
            SetProgress(0, 0);
            Successful(0);
            Ruta(0);
            Fallidos(0);
        }
        private void SetPercentage(int value)
        {
            StaticText9.SetBold();// etiqueta
            StaticText9.SetBold();// etiqueta
            StaticText9.SetColor(Color.LightGreen);
            StaticText9.SetHeight(40);
            StaticText9.SetSize(35);
            StaticText9.Caption = string.Format("{0} %", value.ToString());

        }
        private void SetProgress(int progress, int count)
        {
            StaticText10.SetBold();// etiqueta
            StaticText10.SetColor(Color.Blue);
            StaticText10.SetBold();
            StaticText10.SetHeight(40);
            StaticText10.SetSize(35);
            StaticText10.Item.Width = 200;
            StaticText10.Caption = string.Format("{0} / {1} ", progress, count);
        }
        private void Successful(int value)
        {
            StaticText11.SetBold();// etiqueta
            StaticText11.SetBold();// etiqueta
            StaticText11.SetColor(Color.Green);
            StaticText11.SetHeight(40);
            StaticText11.SetSize(40);
            StaticText11.Caption = value.ToString();
        }
        private void Ruta(int value)
        {
            StaticText12.Caption = "0";
            StaticText12.SetBold();
            StaticText12.SetHeight(40);
            StaticText12.SetSize(40);
            StaticText12.SetColor(Color.Maroon);
        }
        private void Fallidos(int value)
        {
            StaticText13.Caption = "0";
            StaticText13.SetBold();
            StaticText13.SetHeight(40);
            StaticText13.SetSize(40);
            StaticText13.SetColor(Color.Red);
        }
        public void Formato_Detalle()
        {

            Grid1.Columns.Item("Estado").TitleObject.Caption = "Estado";
            Grid1.Columns.Item("Ocurrencia").TitleObject.Caption = "Ocurrencia";

            Grid1.Columns.Item("DocEntry").Visible = false;
            Grid1.Columns.Item("LineId").Visible = false;
            Grid1.Columns.Item("OrdenVisita").Visible = false;
            Grid1.Columns.Item("DocEntry_Ent").Visible = true;
            Grid1.Columns.Item("DoEntry_Fac").Visible = true;
            Grid1.Columns.Item("CodCliente").LinkedObjectType(Grid1, "CodCliente", "2");
            Grid1.Columns.Item("DocEntry_Ent").LinkedObjectType(Grid1, "DocEntry_Ent", "15");

            Grid1.Columns.Item("DocEntry_Ent").TitleObject.Caption = "Cod. guía entrega";

            Grid1.Columns.Item("CodCliente").TitleObject.Caption = "Código Cliente";
            Grid1.Columns.Item("Cliente").TitleObject.Caption = "Nombre Cliente";
            Grid1.Columns.Item("Documento_Ent").TitleObject.Caption = "Nro. guía entrega";

            Grid1.Columns.Item("DocumentoLegal_Fac").TitleObject.Caption = "Nro. factura";
            Grid1.Columns.Item("DoEntry_Fac").TitleObject.Caption = "Cod. factura";

            Grid1.Columns.Item("DoEntry_Fac").LinkedObjectType(Grid1, "DoEntry_Fac", "13");

            Grid1.Columns.Item("Direccion").TitleObject.Caption = "Dirección";
            Grid1.Columns.Item("Fecha_Emision").TitleObject.Caption = "Fecha Emisión";
            Grid1.Columns.Item("TerminoPago").TitleObject.Caption = "Termino de Pago";
            Grid1.Columns.Item("HoraInicio").TitleObject.Caption = "Hora de Inicio";
            Grid1.Columns.Item("HoraFin").TitleObject.Caption = "Hora Final";
            Grid1.Columns.Item("FotoGuia").TitleObject.Caption = "Foto de la Guía";
            Grid1.Columns.Item("FotoLocal").TitleObject.Caption = "Foto del Local";
            Grid1.Columns.Item("PersonaContacto").TitleObject.Caption = "Persona de Contacto";
            Grid1.Columns.Item("CodVendedor").TitleObject.Caption = "Código de Vendedor";
            Grid1.Columns.Item("CodVendedor").LinkedObjectType(Grid1, "CodVendedor", "53");
            Grid1.AutoResizeColumns();
            Grid1.ReadOnlyColumns();
            // Grid0.Columns.Item("CodAyudante").Visible = false;
        }
        public void Formato_Cabecera()
        {
            Grid1.AutoResizeColumns();
            Grid1.ReadOnlyColumns();
            // Grid0.Columns.Item("CodAyudante").Visible = false;
        }
        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }
        public void ObtenerDetalle(SAPbouiCOM.DataTable dt, SAPbouiCOM.SBOItemEventArg pVal)
        {

            string Cod_Vendedor = Grid0.DataTable.GetValue("Codigo Vendedor", pVal.Row).ToString();
            string Fecha = EditText0.Value;

            if (EditText0.Value == null || EditText0.Value == "")
            {
                EditText0.Value = "00:00";
            }
            if (EditText2.Value == null || EditText2.Value == "")
            {
                EditText2.Value = "24:00";
            }

            int HORA_INI = Convert.ToInt32(EditText1.Value);
            int HORA_FIN = Convert.ToInt32(EditText2.Value);


            using (BLL.EntregaBLL entregaBll = new BLL.EntregaBLL())
            {
                entregaBll.SP_VIS_DIS_GET_TRACKER_D_VENTAS(ref dt, Fecha, HORA_INI, HORA_FIN, Cod_Vendedor,ComboBox1.GetValue());
               Formato_Detalle();
            }
        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.Row >= 0)
            {
                Sb1Messages.ShowSuccess("Iniciando Carga"); 
                oForm.Freeze(true);
                SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_0");
                ObtenerDetalle(dt, pVal);
                for (int oRows = 0; oRows < Grid1.Rows.Count; oRows++)
                {

                    if (Grid1.DataTable.GetValue("Estado", oRows).ToString() == "Entregado")
                    {
                        // Grid1.CommonSetting.SetRowBackColor(oRows + 1, ColorTranslator.ToOle(Color.Green));
                        Grid1.CommonSetting.SetRowFontColor(oRows + 1, ColorTranslator.ToOle(Color.Green));
                    }
                    else if (Grid1.DataTable.GetValue("Estado", oRows).ToString() == "Programado")
                    {
                        // Grid1.CommonSetting.SetRowBackColor(oRows + 1, ColorTranslator.ToOle(Color.GreenYellow));
                        Grid1.CommonSetting.SetRowFontColor(oRows + 1, ColorTranslator.ToOle(Color.Maroon));
                    }
                    else
                    {
                        //  Grid1.CommonSetting.SetRowBackColor(oRows + 1, ColorTranslator.ToOle(Color.Red));
                        Grid1.CommonSetting.SetRowFontColor(oRows + 1, ColorTranslator.ToOle(Color.Red));
                    }
                   
                }

                Grid0.Rows.SelectedRows.Add(pVal.Row);
                Grid1.AssignLineNro();
                Grid1.ReadOnlyColumns();
                Grid0.Sortable();
                Grid1.Sortable();
                oForm.Freeze(false);
                Sb1Messages.ShowSuccess("Carga finalizada");
            }

        }

        private void EditText3_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;
        }

        private void EditText3_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
        }
        private void Grid0_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }
    }
}
