using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Newtonsoft.Json;
using RestSharp;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Data;
using System.ComponentModel;
using Vistony.Distribucion.Win;
using Vistony.Distribucion.DAL;
using Vistony.Distribucion.BO;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;


namespace Vistony.Distribucion.Win.Asistentes

{
    [FormAttribute("wzdProgramacion", "Asistentes/wzdProgramacion.b1f")]
    class wzdProgramacion : BaseWizard
    {
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        string usuario = "";
        int filaseleccionada = -1;
     //   private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        //private SAPbouiCOM.Button Button1;
        //private SAPbouiCOM.Button Button2;
        //private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.OptionBtn OptionBtn2;
      //  private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.Button Button6;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.Grid Grid2;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnPrior = ((SAPbouiCOM.Button)(this.GetItem("6").Specific));
            this.btnPrior.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnPrior_PressedAfter);
            this.btnNext = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.btnNext.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnNext_PressedBefore);
            this.btnNext.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnNext_PressedAfter);
            this.lblTitle = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.lblPageNumber = ((SAPbouiCOM.StaticText)(this.GetItem("142").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_8").Specific));
            this.OptionBtn0.PressedAfter += new SAPbouiCOM._IOptionBtnEvents_PressedAfterEventHandler(this.OptionBtn0_PressedAfter);
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_9").Specific));
            this.OptionBtn1.PressedAfter += new SAPbouiCOM._IOptionBtnEvents_PressedAfterEventHandler(this.OptionBtn1_PressedAfter);
            this.OptionBtn2 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_10").Specific));
            this.OptionBtn2.PressedAfter += new SAPbouiCOM._IOptionBtnEvents_PressedAfterEventHandler(this.OptionBtn2_PressedAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button4.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button4_ClickBefore);
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button4_ClickAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText2.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText2_LostFocusAfter);
            this.EditText2.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText2_KeyDownAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_21").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.ClickBefore += new SAPbouiCOM._IGridEvents_ClickBeforeEventHandler(this.Grid0_ClickBefore);
            this.Grid0.PressedAfter += new SAPbouiCOM._IGridEvents_PressedAfterEventHandler(this.Grid0_PressedAfter);
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_36").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_37").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            this.EditText11.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText11_ChooseFromListAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_23").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("Item_38").Specific));
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_39").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("Item_40").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_41").Specific));
            this.Grid2 = ((SAPbouiCOM.Grid)(this.GetItem("Item_42").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("Item_43").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_24").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_25").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_27").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.OnCustomInitialize();

        }

        public wzdProgramacion()
        {
            // asigno las fechas por defecto
            EditText0.Value = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");
            EditText1.Value = DateTime.Now.ToString("yyyyMMdd");

            EditText3.Value = DateTime.Now.AddDays(1).ToString("yyyyMMdd");

            //leo las etiquetas
            StaticText16.Caption = LabelsForms.Label00001;
            StaticText17.Caption = LabelsForms.Label00002;

            // seteo en cero los contadores de  documentos y de peso
            EditText14.SetInt(0);
            EditText15.SetDouble(0);


            StaticText14.SetBold();

        }
        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter(); // centro la pantalla
            string sucursal = string.Empty;
            InitializeGrid();

            btnPrior.Item.Enabled = false;
            PaneLevel = 1;
            PaneMax = 3;
            lblTitle.SetBold();
            lblTitle.SetSize(12);
            oForm.SetUserDataSource("UD_0", "Y");
            oForm.SetUserDataSource("UD_1", "N");
            oForm.SetUserDataSource("UD_2", "N");



            /////////////////////////////////////////////////

            usuario = Sb1Globals.UserName;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            sucursal = Utils.GetSucursal(oDT, usuario);

            // vehiculos
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = "U_VIS_BranchCode";
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = sucursal;
            cfl.SetConditions(cons);

            //Conductores
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_1");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursal;
            cfl1.SetConditions(cons1);

            //Conductores
            //SAPbouiCOM.ChooseFromList cfl2 = oForm.ChooseFromLists.Item("CFL_2");
            //SAPbouiCOM.Conditions cons2 = cfl2.GetConditions();
            //SAPbouiCOM.Condition con2;
            //con2 = cons2.Add();
            //con2.Alias = "U_Branch";
            //con2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            //con2.CondVal = sucursal;
            //cfl2.SetConditions(cons2);

            /////////////////////////////////////////////////

            StaticText15.Item.Visible = false;

        }

        private void PriorPane()
        {
            if (PaneLevel >= 2)
            {
                if (PaneLevel == 5)

                    oForm.PaneLevel -= 2;
                else
                    oForm.PaneLevel -= 1;
            }

            if (PaneLevel == 1)
            {
                btnPrior.Item.Enabled = false;
            }
            else
            {
                btnPrior.Item.Enabled = true;
                btnNext.Caption = addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma);
            }

            SetPageNumber();
        }

        private void SetPageNumber()
        {

            if (PaneLevel==5)
                lblPageNumber.Caption = string.Format(addonMessageInfo.MessageIdiomaMessage212(Sb1Globals.Idioma), (PaneLevel - 2), (PaneMax));
            else
                lblPageNumber.Caption = string.Format(addonMessageInfo.MessageIdiomaMessage212(Sb1Globals.Idioma), (PaneLevel - 1), (PaneMax));


            Sb1Messages.ShowMessage("");
        }

        private void btnPrior_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            PriorPane();
        }

        private void btnNext_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = Validate();

        }

        

        private void btnNext_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (btnNext.Caption == addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma))
                NextPane();
            else
            {
              btnCancel.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
            }
        }

        private void NextPane()
        {
            SAPbouiCOM.UserDataSource uEliminar = oForm.DataSources.UserDataSources.Item("UD_2");


        

            if (PaneLevel == 3)
            {
                //REALIZAR PROGRAMACION AUTOMATICA
                //if (uEliminar.ValueEx != "Y")
                //{
                //    Thread mythr = new Thread(ProcesarProgramacion);
                //    mythr.Name = "Asigna1";
                //    mythr.Start();
                //    mythr.IsBackground = true;

                //}
                //else
                //{
                //    Thread mythr = new Thread(ProcesarAsignacion2);
                //    mythr.Name = "Asigna2";
                //    mythr.Start();
                //    mythr.IsBackground = true;
                //    //ProcesarAsignacion2();
                //}

                
               
            }

            


            if ((PaneLevel - 1) < PaneMax)
            {
                if (PaneLevel == 3)
                    oForm.PaneLevel += 2;
                else
                    oForm.PaneLevel += 1;




                if (PaneLevel == 3)// si estan en la pestaña de programación de despachos
                {
                    btnNext.Caption = addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma);
                    Folder0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);// selecciono el tab principal
                    LoadResumen(1); // cargar la estructura del resumen el resumen de la programación

                    
                }

                else if (oForm.PaneLevel == 5)
                {
                    btnNext.Caption = addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma);
                }
            }
            SetPageNumber();


            if (PaneLevel  == 5)
            {
                btnNext.Caption = addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma);
               // btnNext.Item.Enabled = false;
            }
            else
            {
                btnPrior.Item.Enabled = true;
                btnNext.Caption = addonMessageInfo.MessageIdiomaMessage123(Sb1Globals.Idioma);
                btnNext.Item.Enabled = true;
            }



        }


        private int CalcularPeso(ref int totalPeso)
        {
            int ret = 0;



            return ret;
        }


        private void ProcesarProgramacion()
        {


            int contador = 0;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
            string ordenDespacho = string.Empty;
            int NumDespacho = 1;
            string Chofer = string.Empty; 
            string NombreChofer = string.Empty; 
            string fechaDespacho = string.Empty; 
            string placaVehiculo = string.Empty;
            string marcaVehiculo = string.Empty;
            string Peso = string.Empty;
            string ayudante = string.Empty; 
                        string response = string.Empty;
            bool isUpdated = false;

            int? docEntry = 0;
            string docNum = string.Empty;
            string choferCode = string.Empty;
            string choferLicencia = string.Empty;

            string choferName = string.Empty;

            string numeroGuia = string.Empty;

            try
            {
                oForm.Freeze(true);
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("Marca", row) == "Y")
                    {
                        
                        docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                        docNum = Grid0.DataTable.GetString("Entrega", row);
                        choferCode = Grid0.DataTable.GetString("CodChofer", row);
                        choferLicencia = Grid0.DataTable.GetString("LicenciaChofer", row);
                        choferName = Grid0.DataTable.GetString("Chofer", row);
                        ayudante = Grid0.DataTable.GetString("Ayudante", row);
                        numeroGuia = Grid0.DataTable.GetString("NumAtCard", row);
                        placaVehiculo = Grid0.DataTable.GetString("Vehiculo", row);
                        marcaVehiculo = Grid0.DataTable.GetString("MarcaVehiculo", row);

                        fechaDespacho = EditText3.Value;
                        oDT.Clear();

                        // obtiene el numero correlativo
                        using (EntregaBLL entregaBLL = new EntregaBLL())
                        {
                            ordenDespacho = entregaBLL.ObtenerCorrelativoDespacho(oDT, fechaDespacho);
                        }

                        //       OrdenDespacho = EntregaDAL.ObtenerCorrelativoDespacho(oDT, fechaDespacho);
                        ////////////////////////OBJETO PARA PASAR A JSON////////////////////////////
                        EntregaDespacho objDespacho = new EntregaDespacho();
                        objDespacho = AsignaDatosObjectGen(choferLicencia, ordenDespacho, fechaDespacho, choferName, ayudante, placaVehiculo, marcaVehiculo, "P");
                        dynamic jsonData = JsonConvert.SerializeObject(objDespacho);
                        ////////////////////////////////////////////////////
                        response = string.Empty;

                        using (EntregaBLL entregaBLL = new EntregaBLL())
                        {
                            isUpdated = entregaBLL.UpdateEstadoEntrega(docEntry, jsonData, ref response);
                        }


                        if (isUpdated)
                        {
                            HistoricoDespachos objHistorico = new HistoricoDespachos();
                            objHistorico = AsignaDatosObject(docEntry.ToString(), NumDespacho.ToString(), "P", ordenDespacho, fechaDespacho, Chofer, NombreChofer, placaVehiculo, ayudante, "", usuario);
                            dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                            string rpta = "";
                            EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                            Sb1Messages.ShowMessage("Guía de entrega número: " + numeroGuia + ",asignado al  Chofer: " + choferName);
                            NumDespacho++;
                        }
                        else
                        {
                            Sb1Messages.ShowError(response);
                        }
                    }
                }


                Sb1Messages.ShowMessageBoxWarning("Programación culminada"); 
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

        private void ProcesarAsignacion2()
        {
            try
            {
                int contador = 0;
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
                string OrdenDespacho = string.Empty;
                int NumDespacho = 1;
                string Chofer = string.Empty;
                string NombreChofer = string.Empty;
                string fechaDespacho = string.Empty;
                string Placa = string.Empty;
                string Ayudante = string.Empty;
                string Licencia = string.Empty;
                bool asigno = false;
                string respuesta = string.Empty;
                string marcaVehiculo = string.Empty;

                oForm.Freeze(true);
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("''", row) == "Y")
                    {
                        int? docentry = Grid0.DataTable.GetInt("DocEntry", row);
                        oDT.Clear();
                        //OrdenDespacho = EntregaDAL.ObtenerCorrelativoDespacho(oDT, fechaDespacho);
                        ////////////////////////OBJETO PARA PASAR A JSON////////////////////////////
                        EntregaDespacho objDespacho = new EntregaDespacho();
                        objDespacho = AsignaDatosObjectGen(Licencia, OrdenDespacho, fechaDespacho, NombreChofer, Ayudante, Placa,marcaVehiculo, "S");
                        dynamic jsonData = JsonConvert.SerializeObject(objDespacho);
                        ////////////////////////////////////////////////////
                        //string respuesta = "";


                        using (EntregaBLL entregaBLL = new EntregaBLL())
                        {
                            asigno = entregaBLL.UpdateEstadoEntrega(docentry, jsonData, ref respuesta);
                        }



                        if (asigno)
                        {
                            /*HistoricoDespachos objHistorico = new HistoricoDespachos();
                            objHistorico = AsignaDatosObject(docentry.ToString(), NumDespacho.ToString(), "P", OrdenDespacho, fechaDespacho, Chofer, NombreChofer, Placa, Ayudante, "", usuario);
                            dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                            string rpta = "";
                            EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                            Sb1Messages.ShowMessage("Quitando Asignación " + docentry);*/
                            NumDespacho++;
                        }
                        else
                        {
                            Sb1Messages.ShowError(respuesta);
                        }
                    }
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

        private bool Validate()
        {
            SAPbouiCOM.UserDataSource uEliminar = oForm.DataSources.UserDataSources.Item("UD_2");
            bool ret = true;

            if (oForm.PaneLevel == 2)
            {

                if (OptionBtn0.ValOn != "Y" && OptionBtn1.ValOn != "Y" && OptionBtn2.ValOn != "Y")
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage314(Sb1Globals.Idioma));
                    ret = false;
                }

            }

            if (oForm.PaneLevel == 3 && uEliminar.ValueEx != "Y")
            {

                if (Grid0.Rows.Count == 0)
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage315(Sb1Globals.Idioma));
                    ret = false;
                }
                if (StaticText16.Caption == "" || StaticText16.Caption == "0")
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    ret = false;
                }
            }
            if (oForm.PaneLevel == 4)
            {

                //if ("" == "" && uEliminar.ValueEx != "Y")
                //{
                //    Sb1Messages.ShowError(AddonMessageInfo.Message303);
                //    ret = false;
                //}
                //else if ("" == "" && uEliminar.ValueEx != "Y")
                //{
                //    Sb1Messages.ShowError(AddonMessageInfo.Message304);
                //    ret = false;
                //}
                //else if ("" == "" && uEliminar.ValueEx != "Y")
                //{
                //    Sb1Messages.ShowError(AddonMessageInfo.Message305);
                //    ret = false;
                //}

                //else if ("" == "" && uEliminar.ValueEx != "Y")
                //{
                //    Sb1Messages.ShowError(AddonMessageInfo.Message306);
                //    ret = false;
                //}
                //if (uEliminar.ValueEx != "Y")
                //{
                //    int ContadorMarcadas = GetRowCountSelected();
                //    if (ContadorMarcadas == 0)
                //    {
                //        Sb1Messages.ShowError(AddonMessageInfo.Message301);
                //        ret = false;
                //    }
                //}

                if (ret == true)
                {
                    bool consulta = Sb1Messages.ShowQuestion(addonMessageInfo.MessageIdiomaMessage307(Sb1Globals.Idioma));
                    ret = consulta;
                }
            }

            return ret;
        }

        private int GetRowCountSelected()
        {
            return Grid0.GetRowCountSelected();
        }



        private EntregaDespacho AsignaDatosObjectGen(string licencia, string ordenDespacho, string fechaDespacho,
                    string nombreChofer, string ayudante, string placaVehiculo,string marcaVehiculo, string status)
        {
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = licencia;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudante;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;

            objDespacho.U_SYP_DT_ESTDES = status;

            return objDespacho;

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



        private void OptionBtn0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (OptionBtn0.Selected == true)
            {
                oForm.DataSources.UserDataSources.Item("UD_1").Value = "N";
                oForm.DataSources.UserDataSources.Item("UD_2").Value = "N";
            }
        }
        private void OptionBtn1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (OptionBtn1.Selected == true)
            {
                oForm.DataSources.UserDataSources.Item("UD_0").Value = "N";
                oForm.DataSources.UserDataSources.Item("UD_2").Value = "N";
            }

        }

        private void OptionBtn2_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (OptionBtn2.Selected == true)
            {
                oForm.DataSources.UserDataSources.Item("UD_1").Value = "N";
                oForm.DataSources.UserDataSources.Item("UD_0").Value = "N";
            }

        }


        private void EditText7_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        //EditText7.Value = chooseFromListEvent.SelectedObjects.GetValue("OcrCode", 0).ToString();
                        // EditText8.Value = chooseFromListEvent.SelectedObjects.GetValue("OcrName", 0).ToString();
                        // EditText9.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_CHLI", 0).ToString();
                    }
                }

            }
            catch (Exception )
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

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
                        //EditText6.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPL", 0).ToString();
                        //EditText5.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }


        private void EditText11_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText11.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_FEGND", 0).ToString();
                        EditText12.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }

        }

        private void Button4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Search();

        }

        private void Search()
        {
            string startDate = EditText0.Value.Trim();
            string endDate = EditText1.Value.Trim();
            string chofer = EditText11.Value.Trim();
            string agencia = "";
                
           SAPbouiCOM.UserDataSource uNuevo = oForm.DataSources.UserDataSources.Item("UD_0");
            try
            {



                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_2");
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));
                oDT.Clear();
                oForm.Freeze(true);

                if (uNuevo.ValueEx == "Y")
                {
                    using (EntregaBLL entregaBLL = new EntregaBLL())
                    {
                        entregaBLL.ListPrevDespacho(startDate, endDate, usuario, chofer, agencia, ref oDT);
                    }


                    //*FormatoGrilla();
                }
                else
                {
                    using (EntregaBLL entregaBLL = new EntregaBLL())
                    {
                        entregaBLL.ListPrevDespachoEdit(startDate, endDate, usuario, chofer, ref oDT);
                    }

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



        private void InitializeGrid()
        {
            Grid0.DataTable.Columns.Add("Marcar", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Fecha Entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Número Legal", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid0.DataTable.Columns.Add("Código SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Nombre SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Peso Bruto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Transporte", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Consolidado", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid0.DataTable.Columns.Add("Dirección", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Chofer", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Placa", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);




            Grid0.Columns.Item(1).Editable = false;
            Grid0.Columns.Item(2).Editable = false;
            Grid0.Columns.Item(3).Editable = false;
            Grid0.Columns.Item(4).Editable = false;
            Grid0.Columns.Item(5).Editable = false;
            Grid0.Columns.Item(6).Editable = false;
            Grid0.Columns.Item(7).Editable = false;
            Grid0.Columns.Item(8).Editable = false;
            Grid0.Columns.Item(9).Editable = false;
            Grid0.Columns.Item(10).Editable = false;
            Grid0.Columns.Item(11).Editable = false;

            Grid0.AutoResizeColumns();
        }


        //Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
        //Grid0.Columns.Item("DocEntry").Visible = false;
        ////Grid0.Columns.Item("Tipo").Visible = false;
        //Grid0.Columns.Item.in¿¿¿ .Item(2).LinkedObjectType(Grid0, "Entrega", "15");
        //Grid0.Columns.Item("CardCode").LinkedObjectType(Grid0, "CardCode", "2");
        ////Grid0.Columns.Item("INDIC").Visible = false;
        //Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Entrega";
        ////Grid0.Columns.Item("DocNum").TitleObject.Caption = "Entrega";
        //Grid0.Columns.Item("NumAtCard").TitleObject.Caption = "Núm Legal";
        //Grid0.Columns.Item("CardCode").TitleObject.Caption = "Código SN";
        //Grid0.Columns.Item("CardName").TitleObject.Caption = "Nombre SN";
        //Grid0.Columns.Item("Peso").TitleObject.Caption = "Peso Bruto";
        //Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";
        //Grid0.ReadOnlyColumns();
        //Grid0.Columns.Item(0).Editable = true;
        //Grid0.AutoResizeColumns();

        private void FormatoGrilla2()
        { 

        //Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
        //    Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";

        //    Grid0.Columns.Item("DocEntry").Visible = false;
        //    Grid0.Columns.Item("CodChofer").Visible = false;
        //    Grid0.Columns.Item("CodVehiculo").Visible = false;

        //    Grid0.Columns.Item(2).LinkedObjectType(Grid0, "Entrega", "15");
       // Grid0.Columns.Item("CardCode").LinkedObjectType(Grid0, "CardCode", "2");
        //Grid0.Columns.Item("INDIC").Visible = false;
        Grid2.Columns.Item("DocDate").TitleObject.Caption = "Fecha Entrega";
            //Grid0.Columns.Item("DocNum").TitleObject.Caption = "Entrega";
            //Grid0.Columns.Item("NumAtCard").TitleObject.Caption = "Núm Legal";
            Grid2.Columns.Item("DriverCode").TitleObject.Caption = "Código Chofer";
            Grid2.Columns.Item("DriverName").TitleObject.Caption = "Nombre Chofer";
            Grid2.Columns.Item("VehiculeCode").TitleObject.Caption = "Vehículo";
            Grid2.Columns.Item("VehiculeCapacity").TitleObject.Caption = "Carga Util";
            Grid2.Columns.Item("DocumentWeight").TitleObject.Caption = "Carga Programada";
            Grid2.Columns.Item("DocumentCount").TitleObject.Caption = "Cantidad de documentos";


            Grid2.AssignLineNro();
            Grid2.AutoResizeColumns();

        }
        private void FormatoGrilla()
        {
     //       int rowCount = 0;
            double totalWeight = 0 ;
    //        rowCount = Grid0.AssignLineNro();

            

            StaticText16.Caption = LabelsForms.Label00001;
            EditText14.SetValue(Utils.AssignLineNro(ref oForm, ref Grid0, ref totalWeight).ToString());

            StaticText17.Caption = LabelsForms.Label00002;
           // EditText15.SetDouble(totalWeight);
            EditText15.SetDouble(Math.Round(totalWeight, 2));


            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item(0).TitleObject.Caption = "Marcar";
          
            Grid0.Columns.Item("DocEntry").Visible = false;
            Grid0.Columns.Item("DocEntry_Fac").Visible = false;
            Grid0.Columns.Item("CodChofer").Visible = false;
            Grid0.Columns.Item("CodVehiculo").Visible = false;
            Grid0.Columns.Item("CodAyudante").Visible = false;


            Grid0.Columns.Item(2).LinkedObjectType(Grid0, "Entrega", "15"); // Pedidos
            Grid0.Columns.Item("NroFactura").LinkedObjectType(Grid0, "NroFactura", "13");// facturas

            Grid0.Columns.Item("CardCode").LinkedObjectType(Grid0, "CardCode", "2"); // socio de negocios
            //Grid0.Columns.Item("INDIC").Visible = false;
            Grid0.Columns.Item("DocDueDate").TitleObject.Caption = "Fecha Entrega";
            //Grid0.Columns.Item("DocNum").TitleObject.Caption = "Entrega";
  
            Grid0.Columns.Item("CardCode").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("CardName").TitleObject.Caption = "Nombre SN";
            Grid0.Columns.Item("Peso").TitleObject.Caption = "Peso Bruto";
            Grid0.Columns.Item("Direccion").TitleObject.Caption = "Dirección";
            Grid0.Columns.Item("Vehiculo").TitleObject.Caption = "Vehículo";
            Grid0.Columns.Item("Peso").RightJustified = true;
            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "Chofer", "CONDUC");
            Grid0.Columns.Item("Vehiculo").LinkedObjectType(Grid0, "Vehiculo", "VEHICU");
            Grid0.Columns.Item("Ayudante").LinkedObjectType(Grid0, "Ayudante", "OAYD");

            Grid0.Columns.Item("Entrega").TitleObject.Caption = "N° Entrega";
            Grid0.Columns.Item("NumAtCard").TitleObject.Caption = "N° Guía Entrega";
            Grid0.Columns.Item("NroFactura").TitleObject.Caption = "N° Referencia"; 

            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            Grid0.AutoResizeColumns();

            Grid0.Columns.Item("RowsHeader").Width += 15;

        }

        /// <summary>
        /// Carga el resumen de la programación realizada para los multiples 
        /// </summary>
        private void LoadResumen(int rows)
        {
            SAPbouiCOM.DataTable oDataTable;
            oDataTable = oForm.GetDataTable("DT_5");

            using (EntregaBLL entrega = new EntregaBLL())
            {
               entrega.GetDataTableResumen(ref oDataTable, rows);
            }

            FormatoGrilla2();
        }

        private void EditText2_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string texto = EditText2.Value;
                if (texto.Length < 8)
                {
                    filaseleccionada = -1;
                    return;
                }
                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                    {
                        string docnum = Grid0.DataTable.GetString("Entrega", row);
                        if (docnum == texto)
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
            { }

        }

        private void EditText2_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;

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

        }
        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.EditTextColumn col = null;
            string docEntry = string.Empty;
            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;


            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "Entrega")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
              
                docEntry = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                
                EditText13.Value = docEntry;

                EditText11.SetFocus();

                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_DeliveryNotes;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Entrega")));
                col.LinkedObjectType = "";// 
            }

            else if (pVal.ColUID == "NroFactura")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                docEntry = Grid0.DataTable.GetValue("DocEntry_Fac", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText13.Value = docEntry;

                EditText11.SetFocus();

                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NroFactura")));
                col.LinkedObjectType = "";// 
            }

            else if (pVal.ColUID == "Chofer")
            {
                docEntry = Grid0.DataTable.GetValue("CodChofer", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText13.Value = docEntry;

                EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "CONDUC";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Chofer")));
                col.LinkedObjectType = "";// 
                
            }

            else if (pVal.ColUID == "Vehiculo")
            {
                docEntry = Grid0.DataTable.GetValue("CodVehiculo", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText13.Value = docEntry;

                EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "VEHICU";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Vehiculo")));
                col.LinkedObjectType = "";// 

            }

            else if (pVal.ColUID == "Ayudante")
            {
                docEntry = Grid0.DataTable.GetValue("CodAyudante", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText13.Value = docEntry;

                EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "OAYD";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Ayudante")));
                col.LinkedObjectType = "";// 

            }

        }


     

   

   


        


        private void Grid0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID == "''")
                {
                    //EditText7.SetFocus();
                    int Sumar = 0;
                    if (StaticText16.Caption == "")
                    {
                        StaticText16.Caption = "0";
                    }
                    Sumar = Convert.ToInt16(StaticText16.Caption);
                    int rowSelected = pVal.Row;
                    int rowIndex = rowSelected;
                    string Codigo = Grid0.DataTable.GetValue("''", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                    if (Codigo == "Y")
                    {
                        Sumar += 1;
                    }
                    else
                    {
                        if (Sumar > 0)
                        {
                            Sumar -= 1;
                        }
                    }
                    StaticText16.Caption = Sumar.ToString();
                }
            }
            catch
            {

            }
        }

   



        private void Button4_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (string.IsNullOrEmpty(EditText0.Value.ToString().Trim()))
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage100(Sb1Globals.Idioma));
                EditText0.SetFocus();
                BubbleEvent = false;
            }

            else if (string.IsNullOrEmpty(EditText1.Value.ToString().Trim()))
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage101(Sb1Globals.Idioma));
                EditText1.SetFocus();
                BubbleEvent = false;
            }


            else if (Convert.ToInt32(EditText1.Value) < Convert.ToInt32(EditText0.Value))
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage302(Sb1Globals.Idioma));
                BubbleEvent = false;
            }

        }

        private void Grid0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           
           // debo verificar

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
                    rowSelected = EditText14.GetInt();

                    // obtengo el peso total de los documentos seleccionados
                    totalWeight = EditText15.GetDouble();


                    // debo marcar o desmarcar todo
                    Utils.CheckRows( oForm,  Grid0, ref totalWeight, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText14.Value = rowSelected.ToString();

                    // asigno el peso para los documentos seleccionados
                    EditText15.SetDouble(Math.Round(totalWeight, 2));
                }

                else if (pVal.ColUID == "Marca" && pVal.Row > -1)
                {
                    EditText14.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText14.GetInt();
                    // obtengo el peso total de ala carga
                    totalWeight = EditText15.GetDouble();

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
                    EditText14.Value = rowSelected.ToString();

                    // asigno el peso para los documentos seleccionados
                    EditText15.SetDouble(Math.Round(totalWeight, 2));
                }
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }

        }

        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.Button Button1;

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            bool response = false;

            
            response = Sb1Messages.ShowQuestion(addonMessageInfo.MessageIdiomaMessage322(Sb1Globals.Idioma));

            if (response)
            { 
                StaticText15.Item.Visible = true;
                ProcesarProgramacion();
            }
        }


        public void UpdateDespacho()
        {
            int? docEntry = 0;
            string docNum = string.Empty;
            
            string choferCode = string.Empty;
            string choferName = string.Empty;
            string choferLicencia = string.Empty;
            string fechaDespacho = string.Empty;
            string ayudanteCode = string.Empty;
            string vehiculoPlaca = string.Empty;
            string marcaVehiculo = string.Empty;
            bool isUpdated = false;
            string response = string.Empty;
            int NumDespacho = 1;
            oForm.Freeze(true);

            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

            for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
            {
                if (Grid0.DataTable.GetString("Marca", row) == "Y")
                {
                    docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                    docNum = Grid0.DataTable.GetString("Entrega", row);
                    choferCode = Grid0.DataTable.GetString("CodChofer", row);
                    choferName = Grid0.DataTable.GetString("Chofer", row);

                     fechaDespacho = string.Empty;



                    oDT.Clear();
                    using (EntregaBLL entregaBLL = new EntregaBLL())
                    {
                        entregaBLL.ObtenerCorrelativoDespacho(oDT, fechaDespacho);
                    }


                    // ordenDespacho = EntregaDAL.ObtenerCorrelativoDespacho(oDT, fechaDespacho);
                    ////////////////////////OBJETO PARA PASAR A JSON////////////////////////////
                    EntregaDespacho objDespacho = new EntregaDespacho();
                    objDespacho = AsignaDatosObjectGen(choferLicencia, docNum, fechaDespacho, choferName, ayudanteCode, vehiculoPlaca, marcaVehiculo, "P");
                    dynamic jsonData = JsonConvert.SerializeObject(objDespacho);
                    ////////////////////////////////////////////////////
                    //respuesta = string.Empty;

                    Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage210(Sb1Globals.Idioma), docNum));
                    using (EntregaBLL entregaBLL = new EntregaBLL())
                    {
                        isUpdated = entregaBLL.UpdateEstadoEntrega(docEntry, jsonData, ref response);
                    }


                    if (isUpdated)
                    {
                       // HistoricoDespachos objHistorico = new HistoricoDespachos();
                      //  objHistorico = AsignaDatosObject(docEntry.ToString(), NumDespacho.ToString(), "P", docNum, fechaDespacho, choferCode, choferName, vehiculoPlaca, ayudanteCode, "", usuario);
                      //  dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                      //  string rpta = "";
                      //  EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                      //  Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage211(Sb1Globals.Idioma), docNum, choferName));
                        NumDespacho++;
                    }
                    else
                    {
                        Sb1Messages.ShowError(response);
                    }


                }
            }



        }
    }// fin de la clase
}// fin del namespace
