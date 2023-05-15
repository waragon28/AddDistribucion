using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.Constans;
using SAPbouiCOM;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using System.Threading;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmProgrammingTransferAsignarEC", "Programacion/frmProgrammingTransferAsignarEC.b1f")]
    class frmProgrammingTransferAsignarEC : UserFormBase
    {
        frmProgrammingSLD OwnerForm;
        SAPbouiCOM.Form oForm;
        Grid Grilla;

        string CodigoAgencia = "";
        string RucAgencia = "";
        string NombreAgencia = "";
        string DireccionDestino = "";

        string LicenciaChofer = "";
        string Placa = "";
        string MarcaVehiculo = "";

        string TipoIdentificacionTransportista = "";
        string RucTransportista = "";
        string RazonSocialTransportista = "";
        string DireccionPartida= "Km 13.5 Vía Duran Tambo";
        string NombreTransportista = "";
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();

        public frmProgrammingTransferAsignarEC(frmProgrammingSLD ownerForm, string usuario, string sucursal, Grid Grid0)
        {
            OwnerForm = ownerForm;
            Utils.LoadQueryDynamic(ref ComboBox0, addonMessageInfo.QueryObtenerSerieTransferenciaStock);
            ComboBox0.Select(1, BoSearchKey.psk_Index);
            Utils.LoadQueryDynamic(ref ComboBox1, addonMessageInfo.QueryObtenerTipoEmisionTransferenciaStock);
            ComboBox1.Select(1, BoSearchKey.psk_Index);
            Utils.LoadQueryDynamic(ref ComboBox2, addonMessageInfo.QueryObtenerTipoDespachoTransferenciaStock);
            ComboBox2.Select(1, BoSearchKey.psk_Index);
            Utils.LoadQueryDynamic(ref ComboBox3, addonMessageInfo.QueryObtenerMotivoTrasladoTransferenciaStock);
            ComboBox3.Select(1, BoSearchKey.psk_Index);
            Folder0.Select();

            // vehículo se filtran por Proveedor 
            SAPbouiCOM.ChooseFromList cfl4 = oForm.ChooseFromLists.Item("CFL_OCRD_AGENCIA");
            SAPbouiCOM.Conditions cons4 = cfl4.GetConditions();
            SAPbouiCOM.Condition con4;
            con4 = cons4.Add();
            con4.Alias = "CardType";
            con4.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con4.CondVal = "S";
            cfl4.SetConditions(cons4);

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_1").Specific));
            this.Folder0.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.Folder0_ClickAfter);
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_2").Specific));
            this.Folder1.ClickBefore += new SAPbouiCOM._IFolderEvents_ClickBeforeEventHandler(this.Folder1_ClickBefore);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_4").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_6").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_8").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_10").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.EditText1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText1_ChooseFromListAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_16").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_21").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_22").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_23").Specific));
            this.EditText5.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText5_ChooseFromListAfter);
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_24").Specific));
            this.EditText6.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText6_ChooseFromListAfter);
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_25").Specific));
            this.EditText7.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText7_ChooseFromListAfter);
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_27").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_28").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_29").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_35").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_37").Specific));
            this.EditText12.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText12_ChooseFromListAfter);
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_36").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_38").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Folder Folder0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
        }

        private SAPbouiCOM.Folder Folder1;
        private StaticText StaticText0;
        private ComboBox ComboBox0;
        private StaticText StaticText1;
        private ComboBox ComboBox1;
        private StaticText StaticText2;
        private ComboBox ComboBox2;
        private StaticText StaticText3;
        private ComboBox ComboBox3;

        private void Folder0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private StaticText StaticText4;
        private EditText EditText0;
        private StaticText StaticText5;
        private EditText EditText1;
        private EditText EditText2;
        private LinkedButton LinkedButton0;

        private void EditText1_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString();
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();


                        TipoIdentificacionTransportista = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_BPTD", 0).ToString();
                        RucTransportista = chooseFromListEvent.SelectedObjects.GetValue("LicTradNum", 0).ToString();
                        RazonSocialTransportista = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();
                        DireccionDestino = chooseFromListEvent.SelectedObjects.GetValue("MailAddres", 0).ToString()+" - "+ chooseFromListEvent.SelectedObjects.GetValue("City", 0).ToString()+
                            chooseFromListEvent.SelectedObjects.GetValue("County", 0).ToString();
                        NombreTransportista=chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private StaticText StaticText6;
        private StaticText StaticText7;
        private EditText EditText3;
        private EditText EditText4;
        private Button Button0;
        private Button Button1;
        private EditText EditText5;
        private EditText EditText6;
        private EditText EditText7;
        private EditText EditText8;
        private EditText EditText9;
        private EditText EditText10;
        private EditText EditText11;
        private StaticText StaticText8;
        private StaticText StaticText9;
        private StaticText StaticText10;
        private StaticText StaticText11;
        private StaticText StaticText12;

        private void Folder1_ClickBefore(object sboObject, SBOItemEventArg pVal,out bool BubbleEvent)
        {
            if (ComboBox0.GetSelectedValue() == "GI")
            {
                Sb1Messages.ShowWarning("El Tipo de Tipo de documento no puede ser "+ ComboBox0.GetSelectedDescription());
                BubbleEvent = false;
            }
            else
            {
                BubbleEvent = true;
            }
        }

        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            bool response = false;

            response = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage319(Sb1Globals.Idioma)));

            if (response)
            {
                frmProgrammingSLD owner = this.OwnerForm;


                string driverCode = EditText5.Value;
                string driverName = EditText8.Value;
                string driverLicence = LicenciaChofer;

                string ayudanteCode = EditText6.Value;
                string ayudanteName = EditText9.Value;

                string vehiculoCode = EditText7.Value;
                string Capacidad = EditText10.Value;
                string vehiculoPlaca = Placa;
                string vehiculoMarca = MarcaVehiculo;



                string a = ComboBox0.GetValue();
                string a1 = ComboBox0.GetSelectedDescription();
                string TipoEmision = ComboBox1.GetValue();
                string MotivoTraslado = ComboBox3.GetValue();
                string TipoDespacho = ComboBox2.GetValue();
               // EditText12.Value = "DRN001";


                // caso 1, solo seleccionan la fecha de la programación
                Thread myNewThread2 = new Thread(() => 
                owner.UpdateDespachoSLDEcuador(Grilla,ComboBox0.GetValue(),ComboBox0.GetSelectedDescription(),
                TipoEmision,
                MotivoTraslado, TipoDespacho, 
                EditText0.Value,
                EditText1.Value,TipoIdentificacionTransportista,
                RucTransportista,RazonSocialTransportista, "DRN001", DireccionPartida,NombreTransportista,DireccionDestino,
                EditText3.Value, EditText4.Value, EditText13.Value,
                driverCode,driverName,driverLicence,ayudanteCode,ayudanteName,
                vehiculoCode,Capacidad,vehiculoPlaca, vehiculoMarca
                    ));
                myNewThread2.Start();

                // cierro el formulario
                oForm.Close();
            }

        }

        private StaticText StaticText13;
        private EditText EditText12;

        private void EditText12_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText12.Value = chooseFromListEvent.SelectedObjects.GetValue("WhsCode", 0).ToString();
                       // DireccionPartida = chooseFromListEvent.SelectedObjects.GetValue("Street", 0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                 Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private StaticText StaticText14;
        private EditText EditText13;

        private void EditText5_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
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
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private void EditText6_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {

            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText6.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
                        EditText9.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }

        }

        private void EditText7_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText7.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
                        EditText10.Value = Convert.ToString(Convert.ToDouble(chooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString(), System.Globalization.CultureInfo.InvariantCulture));

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
    }
}
