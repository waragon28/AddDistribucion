//#define AD_PY
//#define AD_PE
#define AD_EC

using SAPbouiCOM.Framework;
using System.Drawing;
using Forxap.Framework.Extensions;
using WebBrowser = SHDocVw.WebBrowser;
using System;
//using Vistony.Framework.UI;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.BLL;
using Forxap.Framework.UI;
using System.Collections.Generic;
using Newtonsoft.Json;
using Vistony.Distribucion.BO;
using System.Threading;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("DispatchTrucking", "UltimaMilla/frmDispatchTrucking.b1f")]
    class frmDispatchTrucking : UserFormBase
    {
        //SAPbouiCOM.Item oItemX;
        //SHDocVw.WebBrowser oWebX;
        //SAPbouiCOM.ActiveX oActiveX;
        SAPbouiCOM.Form oForm;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.ComboBox ComboBox0;

        EntregaBLL entregaBLL = new EntregaBLL();
        string Usuario = Sb1Globals.UserName;
        string SucursalUser = Sb1Globals.Sucursal;
        string TIPO_TRACK = "";
        string DepUSU = "";
        public frmDispatchTrucking()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText1.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText1_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText2.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText2_ClickAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText3.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText3_ClickAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_10").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_11").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_17").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText10.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText10_ClickAfter);
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.StaticText13.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText13_ClickAfter);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_23").Specific));
            this.Button4.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button4_ClickBefore);
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button4_ClickAfter);
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.StaticText15.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText15_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText4.ClickAfter += new SAPbouiCOM._IStaticTextEvents_ClickAfterEventHandler(this.StaticText4_ClickAfter);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_19").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }
        public void Sucursales(bool Value)
        {
            ComboBox0.Item.Visible = Value;
            StaticText12.Item.Visible = Value;
        }
        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            Sucursales(false);
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_3");
            entregaBLL.GetInfoUsuario(Usuario, oDT);
              string a = oDT.GetString("position", 0);
#if AD_PY
             if (oDT.GetString("U_Admin_Sucursal", 0) == "Y") /* CONTROLLER ADM. */
            {
                Sucursales(true);
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Item.Enabled = true;
            }
            else
            {
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Select(oDT.GetString("U_SYP_NDED", 0), SAPbouiCOM.BoSearchKey.psk_ByValue);
                Sucursales(true);
                ComboBox0.Item.Enabled = false;
            }
#elif AD_EC
             if (oDT.GetString("U_Admin_Sucursal", 0) == "Y") /* CONTROLLER ADM. */
            {
                Sucursales(true);
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Item.Enabled = true;
            }
            else
            {
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Select(oDT.GetString("U_SYP_NDED", 0), SAPbouiCOM.BoSearchKey.psk_ByValue);
                Sucursales(true);
                ComboBox0.Item.Enabled = false;
            }

#else
            if (oDT.GetString("position", 0) == "61") /* CONTROLLER ADM. */
            {
                Sucursales(true);
                ComboBox0.Item.Enabled = true;
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                DepUSU = oDT.GetString("position", 0);
            }
            else if (oDT.GetString("dept", 0) == "11") /* Distribución */
            {
                ComboBox0.Item.Enabled = true;
                Sucursales(true);
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionDistribucion);
                DepUSU = oDT.GetString("dept", 0);
                ComboBox0.Select(oDT.GetString("U_SYP_NDED", 0), SAPbouiCOM.BoSearchKey.psk_ByValue);
            }
            else if (oDT.GetString("dept", 0) == "12")  /*Usuario*/
            {
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Select(oDT.GetString("U_SYP_NDED", 0), SAPbouiCOM.BoSearchKey.psk_ByValue);
                DepUSU = oDT.GetString("dept", 0);
                Sucursales(true);
            }
            else
            {
                Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryPuntoEmisionAdminSucursales);
                ComboBox0.Select(oDT.GetString("U_SYP_NDED", 0), SAPbouiCOM.BoSearchKey.psk_ByValue);
                string aAAAA = oDT.GetString("U_SYP_NDED", 0);
                DepUSU = oDT.GetString("dept", 0);
                Sucursales(true);
            }
#endif

            EditText1.SetNow();
            EditText0.SetValue("0000");
            EditText2.SetValue("2359");
            EditText1.SetFocus();
            StaticText8.SetBold();
            StaticText9.SetBold();
            // porcentaje


            SetPercentage(0);// porcentaje de avance
            SetProgress(0, 0); //avance
            Successful(0); // entregas exitosas
            UnSuccessful(0);// entregas no  exitosas
            ResizeControls();

            InitializeGrid();

            // oWeb.Navigate("http://emergys.co.in/")
            StaticText6.Caption = "PORCENTAJE";
            StaticText6.Item.FontSize = 20;
          //  StaticText6.Item.RightJustified = true;
            //StaticText6.Item.RightJustified = true;
            StaticText6.SetBold();
            StaticText6.SetColor(Color.White);
            StaticText6.Item.BackColor= ColorTranslator.ToOle(Color.LightGreen);
            StaticText6.Item.Height = 40;
            StaticText6.Item.Width = 150;

           

            StaticText10.Caption = "EN RUTA";
            StaticText10.Item.FontSize = 20;
            StaticText10.SetBold();
            StaticText10.SetColor(Color.White);
            StaticText10.Item.BackColor = ColorTranslator.ToOle(Color.Maroon);
            StaticText10.Item.Height = 40;
            StaticText10.Item.Width = 100;


            StaticText13.Caption = "ENTREGADO";
            StaticText13.Item.FontSize = 20;
            StaticText13.SetBold();
            StaticText13.SetColor(Color.White);
            StaticText13.Item.BackColor = ColorTranslator.ToOle(Color.Green);
            StaticText13.Item.Height = 40;
            StaticText13.Item.Width = 130;

            StaticText2.Caption = "AVANCE";
            StaticText2.Item.FontSize = 20;

            StaticText2.SetBold();
            StaticText2.SetColor(Color.White);
            StaticText2.Item.BackColor = ColorTranslator.ToOle(Color.Blue);
            StaticText2.Item.Height = 40;
            StaticText2.Item.Width = 100;

            StaticText3.Caption = "FALLIDO";
            StaticText3.Item.FontSize = 20;

            StaticText3.SetBold();
            StaticText3.SetColor(Color.White);
            StaticText3.Item.Height = 40;
            StaticText3.Item.Width = 110;
            StaticText3.Item.BackColor = ColorTranslator.ToOle(Color.Red);

            StaticText15.SetHeight(40);
            StaticText15.SetSize(40);
            StaticText15.SetColor(Color.Red);


           // StaticText4.SetColor(Color.Red);
            StaticText4.Caption = "0";
            StaticText4.SetBold();
            StaticText4.SetHeight(40);
            StaticText4.SetSize(40);
            StaticText4.SetColor(Color.Maroon);
        }




        private void SetProgress(int progress,int count )
        {
            StaticText2.SetBold();// etiqueta
            StaticText5.SetColor(Color.Blue);
            StaticText5.SetBold();
            StaticText5.SetHeight(40);
            StaticText5.SetSize(40);
            StaticText5.Caption = string.Format("{0} / {1} ", progress, count);
            
        }

        private void UnSuccessful(int value)
        {
            StaticText15.SetBold();//etiqueta
            StaticText3.SetColor(Color.Red);
            StaticText3.SetHeight(40);
            StaticText3.SetSize(04);
            StaticText3.Caption = value.ToString();
        }
        private void Successful(int value)
        {
            StaticText10.SetBold();// etiqueta
            StaticText11.SetBold();// etiqueta
            StaticText11.SetColor(Color.Green);
            StaticText11.SetHeight(40);
            StaticText11.SetSize(40);
            StaticText11.Caption = value.ToString();
        }

        private void SetPercentage(int value)
        {
            StaticText6.SetBold();// etiqueta
            StaticText7.SetBold();// etiqueta
            StaticText7.SetColor(Color.LightGreen);
            StaticText7.SetHeight(40);
            StaticText7.SetSize(40);
            StaticText7.Caption = string.Format("{0} %", value.ToString());

        }
        
        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            ResizeControls();
        }

        private void ResizeControls()
        {
            StaticText8.Item.Top = Grid0.Item.Top - 20;
            StaticText8.Item.Left = Grid0.Item.Left;
            Grid0.Item.Width = oForm.Width - 30;
            Grid1.Item.Width = oForm.Width - 30;

            StaticText9.Item.Top = Grid0.Item.Top + Grid0.Item.Height + 20;
            Grid1.Item.Top  = StaticText9.Item.Top + 20;

            StaticText9.Item.Left = Grid1.Item.Left;

            StaticText2.Item.Left = ((oForm.Width - 30) / 2); //avance
            StaticText5.Item.Left = ((oForm.Width - 30) / 2);

            StaticText6.Item.Left = ((oForm.Width - 30) / 3); // porcentaje etiqueta
            StaticText7.Item.Left =  ((oForm.Width - 30) / 3);// porcenyaje monto

          //  StaticText4.Item.Left = StaticText11.Item.Left;
           
        }

        private void InitializeGrid()
        {
           
            Grid1.DataTable.Columns.Add("Estado", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Ocurrencia", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid0.DataTable.Columns.Add("Vehículo", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Chofer", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Fecha inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Hora inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid0.DataTable.Columns.Add("Feccha termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Hora termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Total exitosos", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Total no exitosos", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            


            // Detalle de las entregas
            Grid1.DataTable.Columns.Add("Código Cliente", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nombre Cliente", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nro. guía entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Nro. factura", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Direccion", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Comentario", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Fecha Emisión", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Termino de Pago", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Hora inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Hora termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            
            Grid1.DataTable.Columns.Add("Foto Guia", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Foto Local", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Persona de Contacto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);


            Grid1.DataTable.Columns.Add("Latitud", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Longitud", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Código de Vendedor", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nombre de Vendedor", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Saldo", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            


            Grid0.AutoResizeColumns();
            Grid1.AutoResizeColumns();
        }
        public void ObtenerCalculoRegistros2(SAPbouiCOM.DataTable dt, SAPbouiCOM.DataTable dt_2,string tracker,string Sucursal)
        {

            oForm.Freeze(true);

            int Entregados = 0;
            int Fallidos = 0;
            int Ruta = 0;
            int Total_Entregas = 0;

            using (BLL.EntregaBLL entregaBll = new BLL.EntregaBLL())
            {
                entregaBll.SP_VIS_DIS_GET_TRACKER_C_TEST(ref dt, EditText1.Value, tracker, Sucursal);
                //Formato_Cabecera();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (EditText0.Value == null || EditText0.Value == "")
                    {
                        EditText0.Value = "00:00";
                    }
                    if (EditText2.Value == null || EditText2.Value == "")
                    {
                        EditText2.Value = "24:59";
                    }

                    int HORA_INI = Convert.ToInt32(EditText0.Value);
                    int HORA_FIN = Convert.ToInt32(EditText2.Value);
                    string Cod_Chofer = dt.GetValue("CodChofer", i).ToString();
                    string Fecha = EditText1.Value;
                    string CodVehiculo = dt.GetValue("CodVehiculo", i).ToString();

                    entregaBll.SP_VIS_DIS_GET_TRACKER_D(ref dt_2, Fecha, HORA_INI, HORA_FIN, Cod_Chofer, CodVehiculo);

                    for (int oRows = 0; oRows < dt_2.Rows.Count; oRows++)
                    {
                        if (dt_2.GetValue("Estado", oRows).ToString() == "Entregado")
                        {
                            Entregados += 1;
                        }
                        else if (dt_2.GetValue("Estado", oRows).ToString() == "Programado")
                        {
                            Ruta += 1;
                        }
                        else
                        {
                            Fallidos += 1;
                        }
                    }

                    Total_Entregas += dt_2.Rows.Count;
                }
                dt_2.Clear();
                StaticText5.Caption = (Entregados + Fallidos) + " / " + Convert.ToString(Total_Entregas);
                decimal Calculo_porcentaje = (100 * (Entregados + Fallidos));
                decimal porcentaje = decimal.Round(Calculo_porcentaje / Total_Entregas, 2);

                StaticText11.Caption = Convert.ToString(Entregados);
                StaticText4.Caption = Convert.ToString(Ruta);
                StaticText15.Caption = Convert.ToString(Fallidos);
                StaticText7.Caption = (porcentaje.ToString()) + " %";

                StaticText2.Item.Width = StaticText5.Item.Width - 60;
                if (porcentaje < 30.99m)
                {
                    StaticText7.SetColor(Color.Red);
                }
                else if (porcentaje >= 30 && porcentaje <= 60)
                {
                    StaticText7.SetColor(Color.Maroon);
                }
                else
                {
                    StaticText7.SetColor(Color.Green);
                }
            }
            Grid0.AssignLineNro();
            oForm.Freeze(false);
        }
        private void Button4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Sb1Messages.ShowWarning(addonMessageInfo.MessageIdiomaMessageInicioTracker(Sb1Globals.Idioma));
            SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_0");
            SAPbouiCOM.DataTable dt_2 = oForm.GetDataTable("DT_2");
            //ObtenerCalculoRegistros(dt, dt_2);

            string ValorCombo = ComboBox0.GetSelectedDescription();
            if (DepUSU == "61") /* CONTROLLER ADMIN.*/
            {
                if (ValorCombo=="TODOS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL_TODAS", ValorCombo);
                }
                else
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
                }
            }
            else if (DepUSU=="11") /*DISTRIBUCION*/
            {
                if (ValorCombo == "TODOS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "TODAS", ValorCombo);
                }
                else if (ValorCombo == "SUCURSAL_TODAS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL_TODAS", ValorCombo);
                }
                else
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
                }
            }
            else if (DepUSU == "12") /* USUARIOS SUCURSALES*/
            {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
            }
            else
            {
                ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
            }
            Sb1Messages.ShowSuccess(addonMessageInfo.MessageIdiomaMessageFinTracker(Sb1Globals.Idioma));
            Formato_Cabecera();
        }
        public void Formato_Cabecera()
        {
            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "CodChofer", "CONDUC");// Chofer
            Grid0.Columns.Item("CodChofer").TitleObject.Caption = "Código Chofer";
           // Grid0.Columns.Item("CodChofer").Visible = false;
            Grid0.Columns.Item("Chofer").TitleObject.Caption = "Chofer";
            Grid0.Columns.Item("Vehiculo").TitleObject.Caption = "vehículo";
            Grid0.Columns.Item("CodVehiculo").TitleObject.Caption="Código de Vehículo"; // Vehiculo
            //Grid0.Columns.Item("CodVehiculo").Visible = false;
            Grid0.Columns.Item("CodVehiculo").LinkedObjectType(Grid0, "CodVehiculo", "VEHICU"); // Vehiculo/
            Grid0.Columns.Item("CodAyudante").LinkedObjectType(Grid0, "CodAyudante", "OAYD"); // ayudante
            //Grid0.Columns.Item("CodAyudante").Visible = false;
            Grid0.Columns.Item("CodAyudante").TitleObject.Caption = "Código de Ayudante";
            Grid0.Columns.Item("PesoTotal").TitleObject.Caption = "Peso Total";
            Grid0.Columns.Item("CantEntregado").TitleObject.Caption = "Cantidad Entrega";
            Grid0.Columns.Item("CantPendiente").TitleObject.Caption = "Cantidad Pendientes";
            Grid0.Columns.Item("CantidadDoc").TitleObject.Caption = "Cantidad Documentos";
            Grid0.Columns.Item("FechaProgramacion").TitleObject.Caption = "Fecha de Programación";
            Grid0.Columns.Item("CargaUtil").TitleObject.Caption = "Carga Util";

            Grid0.AutoResizeColumns();
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
            // Grid0.Columns.Item("CodAyudante").Visible = false;
        }
        private void EditText1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }
         List<Ubigaciones> Ubigaciones = new List<Ubigaciones>();
        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.Row>=0)
            {
                oForm.Freeze(true);
                SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_1");
                ObtenerDetalle(dt, pVal);
                string result = JsonConvert.SerializeObject(dt);
                for (int oRows = 0; oRows < Grid1.Rows.Count; oRows++)
                {
                    Ubigaciones UbigacionesObj = new Ubigaciones();

                   UbigacionesObj.Cliente= Grid1.DataTable.GetValue(6, oRows).ToString(); //Cliente
                   UbigacionesObj.Lat= Grid1.DataTable.GetValue(20, oRows).ToString(); //Latitud
                   UbigacionesObj.Long= Grid1.DataTable.GetValue(21, oRows).ToString(); //Longitud
                    string FormatoHora="";
                    if (Grid1.DataTable.GetValue(16, oRows).ToString()!="0")
                    {
                        string Hora = Grid1.DataTable.GetValue(16, oRows).ToString();
                        int HoraEntero = Hora.Length;
                        if (HoraEntero==4)
                        {
                            FormatoHora = Hora.Substring(0, 2)+":"+ Hora.Substring(2,2);
                        }
                        if (HoraEntero == 3)
                        {
                            FormatoHora = Hora.Substring(0,1) + ":" + Hora.Substring(1, 2);
                        }
                    }
                   UbigacionesObj.HoraFin = FormatoHora; //Hora de Fin


                    Ubigaciones.Add(UbigacionesObj);

                    if (Grid1.DataTable.GetValue("Estado", oRows).ToString()=="Entregado")
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
               

                Grid1.AssignLineNro();
                oForm.Freeze(false);
            }
           
        }
        public void ObtenerDetalle(SAPbouiCOM.DataTable dt, SAPbouiCOM.SBOItemEventArg pVal)
        {

            string Cod_Chofer = Grid0.DataTable.GetValue("CodChofer", pVal.Row).ToString();
            string Fecha = EditText1.Value;
            string CodVehiculo = Grid0.DataTable.GetValue("CodVehiculo", pVal.Row).ToString();

            if (EditText0.Value == null || EditText0.Value == "")
            {
                EditText0.Value = "00:00";
            }
            if (EditText2.Value == null || EditText2.Value == "")
            {
                EditText2.Value = "24:00";
            }
            int HORA_INI = Convert.ToInt32(EditText0.Value);
            int HORA_FIN = Convert.ToInt32(EditText2.Value);
          

            using (BLL.EntregaBLL entregaBll = new BLL.EntregaBLL())
            {
                entregaBll.SP_VIS_DIS_GET_TRACKER_D(ref dt, Fecha, HORA_INI, HORA_FIN, Cod_Chofer, CodVehiculo);
                Formato_Detalle();
            }
        }
        public void ObtenerCalculoRegistros(SAPbouiCOM.DataTable dt, SAPbouiCOM.DataTable dt_2)
        {

            oForm.Freeze(true);

            int Entregados = 0;
            int Fallidos = 0;
            int Ruta = 0;
            int Total_Entregas = 0;

            using (BLL.EntregaBLL entregaBll = new BLL.EntregaBLL())
            {
                entregaBll.SP_VIS_DIS_GET_TRACKER_C(ref dt, EditText1.Value);
                Formato_Cabecera();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (EditText0.Value == null || EditText0.Value == "")
                    {
                        EditText0.Value = "00:00";
                    }
                    if (EditText2.Value == null || EditText2.Value == "")
                    {
                        EditText2.Value = "24:59";
                    }

                    int HORA_INI = Convert.ToInt32(EditText0.Value);
                    int HORA_FIN = Convert.ToInt32(EditText2.Value);
                    string Cod_Chofer = dt.GetValue("CodChofer", i).ToString();
                    string Fecha = EditText1.Value;
                    string CodVehiculo = dt.GetValue("CodVehiculo", i).ToString();

                    entregaBll.SP_VIS_DIS_GET_TRACKER_D(ref dt_2, Fecha, HORA_INI, HORA_FIN, Cod_Chofer, CodVehiculo);

                    for (int oRows = 0; oRows < dt_2.Rows.Count; oRows++)
                    {
                       if (dt_2.GetValue("Estado", oRows).ToString() == "Entregado")
                        {
                            Entregados += 1;
                        }
                        else if (dt_2.GetValue("Estado", oRows).ToString() == "Programado")
                        {
                            Ruta += 1;
                        }
                        else
                        {
                            Fallidos += 1;
                        }
                    }

                    Total_Entregas += dt_2.Rows.Count;
                }
                dt_2.Clear();
                StaticText5.Caption = (Entregados + Fallidos) + " / " + Convert.ToString(Total_Entregas);
                decimal Calculo_porcentaje = (100 * (Entregados + Fallidos));
                decimal porcentaje = decimal.Round(Calculo_porcentaje / Total_Entregas, 2);

                StaticText11.Caption = Convert.ToString(Entregados);
                StaticText4.Caption = Convert.ToString(Ruta);
                StaticText15.Caption = Convert.ToString(Fallidos);
                StaticText7.Caption = (porcentaje.ToString()) + " %";

                StaticText2.Item.Width = StaticText5.Item.Width - 60;
                if (porcentaje < 30.99m)
                {
                    StaticText7.SetColor(Color.Red);
                }
                else if (porcentaje >= 30 && porcentaje <= 60)
                {
                    StaticText7.SetColor(Color.Maroon);
                }
                else
                {
                    StaticText7.SetColor(Color.Green);
                }
            }
            Grid0.AssignLineNro();
            oForm.Freeze(false);
        }
        private void Button4_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();
        }
        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
           // oForm.Freeze(true);

            SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_0");
            SAPbouiCOM.DataTable dt_2 = oForm.GetDataTable("DT_2");

           // Sb1Messages.ShowQuestion(AddonMessageInfo.Message325);

            ObtenerCalculoRegistros(dt, dt_2);

           // Sb1Messages.ShowSuccess(AddonMessageInfo.Message326);

           // oForm.Freeze(false);

        }
        private void StaticText2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }
        private void StaticText13_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
        private void StaticText10_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
        private void StaticText4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
        private void StaticText3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }
        private void StaticText15_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }
        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Thread mythr = new Thread((obj) =>
            {   
             MapaUltimamILLA mapaUltimamILLA = new MapaUltimamILLA(Ubigaciones);
            mapaUltimamILLA.Show();
            mapaUltimamILLA.Activate();
            mapaUltimamILLA.Focus();
            System.Windows.Forms.Application.Run();
            });
            mythr.Start();

        }
        
        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Sb1Messages.ShowWarning(addonMessageInfo.MessageIdiomaMessageInicioTracker(Sb1Globals.Idioma));
            SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_0");
            SAPbouiCOM.DataTable dt_2 = oForm.GetDataTable("DT_2");
            //ObtenerCalculoRegistros(dt, dt_2);

            string ValorCombo = ComboBox0.GetSelectedDescription();
            if (DepUSU == "61") /* CONTROLLER ADMIN.*/
            {
                if (ValorCombo == "TODOS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL_TODAS", ValorCombo);
                }
                else
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
                }
            }
            else if (DepUSU == "11") /*DISTRIBUCION*/
            {
                if (ValorCombo == "TODOS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "TODAS", ValorCombo);
                }
                else if (ValorCombo == "SUCURSAL_TODAS")
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL_TODAS", ValorCombo);
                }
                else
                {
                    ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
                }
            }
            else if (DepUSU == "12") /* USUARIOS SUCURSALES*/
            {
                ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
            }
            else
            {
                ObtenerCalculoRegistros2(dt, dt_2, "SUCURSAL", ValorCombo);
            }
            Sb1Messages.ShowWarning(addonMessageInfo.MessageIdiomaMessageFinTracker(Sb1Globals.Idioma));


        }
    }
}
