#define AD_PE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SAPbouiCOM;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Constans;
using Forxap.Framework.UI;
using System.Threading;
using SAPbobsCOM;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmProgrammingSLDAsignar", "Programacion/frmProgrammingSLDAsignar.b1f")]
    class frmProgrammingSLDAsignar : UserFormBase
    {
        frmProgrammingSLD OwnerForm;
        SAPbouiCOM.Form oForm;
        Grid Grilla;

        string CodigoAgencia = "";
        string RucAgencia = "";
        string NombreAgencia = "";
        string DireccionAgencia = "";

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public frmProgrammingSLDAsignar(frmProgrammingSLD ownerForm, string usuario, string sucursal, Grid Grid0)
        {
            OwnerForm = ownerForm;
            Grilla = Grid0;
            Folder0.Select();

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursal;
            cfl1.SetConditions(cons1);


            // Ayudantes se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl2 = oForm.ChooseFromLists.Item("CFL_1");
            SAPbouiCOM.Conditions cons2 = cfl2.GetConditions();
            SAPbouiCOM.Condition con2;
            con2 = cons2.Add();
            con2.Alias = "U_VIS_BranchCode";
            con2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con2.CondVal = sucursal;
            cfl2.SetConditions(cons2);


            // vehículo se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl3 = oForm.ChooseFromLists.Item("CFL_2");
            SAPbouiCOM.Conditions cons3 = cfl3.GetConditions();
            SAPbouiCOM.Condition con3;
            con3 = cons3.Add();
            con3.Alias = "U_VIS_BranchCode";
            con3.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con3.CondVal = sucursal;
            cfl3.SetConditions(cons3);

            // vehículo se filtran por Proveedor 
            SAPbouiCOM.ChooseFromList cfl4 = oForm.ChooseFromLists.Item("CFL_OCRD_AGENCIA");
            SAPbouiCOM.Conditions cons4 = cfl4.GetConditions();
            SAPbouiCOM.Condition con4;
            con4 = cons4.Add();
            con4.Alias = "CardType";
            con4.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con4.CondVal = "S";
            cfl4.SetConditions(cons4);

#if AD_PE
            Utils.LoadQueryDynamic(ref ComboBox0, addonMessageInfo.QueryObtenerSerieTransferenciaStock);
            ComboBox0.Select(1, BoSearchKey.psk_Index);

            Utils.LoadQueryDynamic(ref ComboBox1, addonMessageInfo.QueryObtenerModalidadTransporte);
            ComboBox1.Select(1, BoSearchKey.psk_Index);

            Utils.LoadQueryDynamic(ref ComboBox2, addonMessageInfo.QueryObtenerTipoSalida);
            ComboBox2.Select(1, BoSearchKey.psk_Index);
#endif
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.EditText1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText1_ChooseFromListAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_13").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_14").Specific));
            this.Button1.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button1_ChooseFromListAfter);
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_17").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_18").Specific));
            this.Folder1.ClickBefore += new SAPbouiCOM._IFolderEvents_ClickBeforeEventHandler(this.Folder1_ClickBefore);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText7.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText7_ChooseFromListAfter);
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_22").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_24").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_25").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_27").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_29").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_32").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_33").Specific));
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


        private void Button1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }
        string LicenciaChofer = "";
        string Placa = "";
        string MarcaVehiculo = "";

        private void EditText0_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            string brandName = string.Empty;

            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("Code", 0, chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString());
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("Name", 0, chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString());
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_CHLI", 0, chooseFromListEvent.SelectedObjects.GetValue("U_SYP_CHLI", 0).ToString());
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_FEGND", 0, chooseFromListEvent.SelectedObjects.GetValue("U_SYP_FEGND", 0).ToString());
                        LicenciaChofer = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_CHLI", 0).ToString();
                    }
                }

            }
            catch (Exception)
            {
                //Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

        private void EditText1_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
                        EditText4.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }

        }

        private void EditText2_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
                        EditText5.Value = Convert.ToString(Convert.ToDouble(chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString(), System.Globalization.CultureInfo.InvariantCulture));

                        Placa = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPL", 0).ToString();
                        MarcaVehiculo = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEMA", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            bool response = false;

            string driverCode = EditText0.Value;
            string driverName = EditText3.Value;
            string driverLicence = LicenciaChofer;

            string ayudanteCode = EditText1.Value;
            string ayudanteName = EditText4.Value;

            string vehiculoCode = EditText2.Value;
            string vehiculoPlaca = Placa;
            string vehiculoMarca = MarcaVehiculo;

            string fechaDespacho = EditText6.Value;
            string SeriesSunat = ComboBox0.GetSelectedDescription();
            string CorrelativoSunat = EditText9.Value;
            string ModalidadTansporte = ComboBox1.GetValue();

            string TipoSalida = ComboBox2.GetSelectedValue();
            string GuiaSalidaInicio = EditText10.Value;
            string GuiaSalidaEntrega = EditText11.Value;

           // if (!string.IsNullOrEmpty(driverCode.ToString().Trim()) && !string.IsNullOrEmpty(fechaDespacho.ToString().Trim()))
           // {
                // pide confirmacion para proceder con la programación
                response = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage319(Sb1Globals.Idioma)));

                if (response)
                {
                    frmProgrammingSLD owner = this.OwnerForm;

                    // caso 1, solo seleccionan la fecha de la programación
                    Thread myNewThread2 = new Thread(() => owner.UpdateRutaDespacho(Grilla, fechaDespacho, driverCode, driverName, ayudanteCode,
                        ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca, fechaDespacho, driverCode, driverName, driverLicence, 
                        ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca,SeriesSunat,CorrelativoSunat, ModalidadTansporte,
                         CodigoAgencia, RucAgencia,NombreAgencia,DireccionAgencia, TipoSalida, GuiaSalidaInicio, GuiaSalidaEntrega
                        ));
                    myNewThread2.Start();
                    
                    // cierro el formulario
                    oForm.Close();
                }
                //    else
                //    {
                //
           // }
        }
        private Folder Folder0;
        private Folder Folder1;
        private StaticText StaticText7;
        private EditText EditText7;
        private EditText EditText8;
        private LinkedButton LinkedButton0;

        private void EditText7_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText7.Value = chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString();
                        EditText8.Value = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();


                         CodigoAgencia = chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString();
                         RucAgencia = chooseFromListEvent.SelectedObjects.GetValue("LicTradNum", 0).ToString();
                         NombreAgencia = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();
                         DireccionAgencia = chooseFromListEvent.SelectedObjects.GetValue("Address", 0).ToString();
                        
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private StaticText StaticText8;
        private ComboBox ComboBox0;
        private EditText EditText9;
        private StaticText StaticText9;
        private ComboBox ComboBox1;

        private void ComboBox0_ComboSelectAfter(object sboObject, SBOItemEventArg pVal)
        {
          EditText9.Value= Correlativo("09", ComboBox0.GetSelectedDescription());

        }

        public string Correlativo(string tipo, string serie)
        {
            try
            {
                SAPbobsCOM.Recordset rcCorrelativo = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string correlativo;
                string sqlQuery = string.Format("SELECT T0.\"U_SYP_NDCD\" from \"@SYP_NUMDOC\" AS T0 where T0.\"Code\" = '{0}' and T0.U_SYP_NDSD='{1}'", tipo, serie);
                rcCorrelativo.DoQuery(sqlQuery);

                correlativo = rcCorrelativo.Fields.Item("U_SYP_NDCD").Value.ToString();

                return correlativo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void Folder1_ClickBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (ComboBox1.GetSelectedDescription()== "Transporte público")
            {
                Sb1Messages.ShowWarning("El tipo de transporte no debe ser público para agregar chofer");
                BubbleEvent = false;
            }
            else
            {
                BubbleEvent = true;
            }

        }

        private StaticText StaticText10;
        private ComboBox ComboBox2;

        private void Form_LoadAfter(SBOItemEventArg pVal)
        {
           

        }

        private StaticText StaticText11;
        private StaticText StaticText12;
        private EditText EditText10;
        private EditText EditText11;
    }
}
