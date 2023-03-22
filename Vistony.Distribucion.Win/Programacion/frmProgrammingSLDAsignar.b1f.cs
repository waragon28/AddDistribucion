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

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmProgrammingSLDAsignar", "Programacion/frmProgrammingSLDAsignar.b1f")]
    class frmProgrammingSLDAsignar : UserFormBase
    {
        frmProgrammingSLD OwnerForm;
        SAPbouiCOM.Form oForm;
        Grid Grilla;


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

            /*

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
            SAPbouiCOM.ChooseFromList cfl2 = oForm.ChooseFromLists.Item("CFL_4");
            SAPbouiCOM.Conditions cons2 = cfl2.GetConditions();
            SAPbouiCOM.Condition con2;
            con2 = cons2.Add();
            con2.Alias = "U_VIS_BranchCode";
            con2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con2.CondVal = sucursal;
            cfl2.SetConditions(cons2);


            // vehículo se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl3 = oForm.ChooseFromLists.Item("CFL_3");
            SAPbouiCOM.Conditions cons3 = cfl3.GetConditions();
            SAPbouiCOM.Condition con3;
            con3 = cons3.Add();
            con3.Alias = "U_VIS_BranchCode";
            con3.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con3.CondVal = sucursal;
            cfl3.SetConditions(cons3);

            */
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


            if (!string.IsNullOrEmpty(driverCode.ToString().Trim()) && !string.IsNullOrEmpty(fechaDespacho.ToString().Trim()))
            {
                // pide confirmacion para proceder con la programación
                response = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage319(Sb1Globals.Idioma)));

                if (response)
                {
                    frmProgrammingSLD owner = this.OwnerForm;

                    // caso 1, solo seleccionan la fecha de la programación
                    Thread myNewThread2 = new Thread(() => owner.UpdateRutaDespacho(Grilla, fechaDespacho, driverCode, driverName, ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca,
                        fechaDespacho, driverCode, driverName, driverLicence, ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca
                        ));
                    myNewThread2.Start();


                    //   Thread myNewThread = new Thread(() => owner.UpdateDespacho(fechaDespacho, driverCode, driverName, driverLicence, ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca));
                    //   myNewThread.Start();


                    // caso 2 seleccionan el conductor al cual van a programar su ruta de despacho
                    // cierro el formulario
                    oForm.Close();
                }
                //    else
                //    {
                //
            }
        }
    }
}
