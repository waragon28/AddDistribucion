using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SAPbouiCOM;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using System.Threading;
using Vistony.Distribucion.Constans;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmProgrammingTransferAsignar", "Programacion/frmProgrammingTransferAsignar.b1f")]
    class frmProgrammingTransferAsignar : UserFormBase
    {
        frmProgrammingSLD OwnerForm;
        SAPbouiCOM.Form oForm;
        Grid Grilla;

        public frmProgrammingTransferAsignar(frmProgrammingSLD ownerForm, string usuario, string sucursal, Grid Grid0)
        {
            OwnerForm = ownerForm;
            Grilla = Grid0;
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText4.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText4_ChooseFromListAfter);
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private Button Button0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
        }

        private Button Button1;
        private StaticText StaticText0;
        private EditText EditText0;
        private EditText EditText1;
        private StaticText StaticText1;
        private EditText EditText2;
        private EditText EditText3;
        private StaticText StaticText2;
        private EditText EditText4;
        private EditText EditText5;
        private StaticText StaticText3;
        private EditText EditText6;
        private StaticText StaticText4;

        string LicenciaChofer = "";
        string Placa = "";
        string MarcaVehiculo = "";
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            oForm.Close();
        }

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
                        EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);
            }
        }

        private void EditText4_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText4.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
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
            string driverName = EditText1.Value;
            string driverLicence = LicenciaChofer;

            string ayudanteCode = EditText2.Value;
            string ayudanteName = EditText3.Value;

            string vehiculoCode = EditText4.Value;
            string vehiculoPlaca = Placa;
            string vehiculoMarca = MarcaVehiculo;

            string fechaDespacho = EditText6.Value;
          
            // if (!string.IsNullOrEmpty(driverCode.ToString().Trim()) && !string.IsNullOrEmpty(fechaDespacho.ToString().Trim()))
            // {
            // pide confirmacion para proceder con la programación
            response = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage319(Sb1Globals.Idioma)));

            if (response)
            {
                frmProgrammingSLD owner = this.OwnerForm;

                // caso 1, solo seleccionan la fecha de la programación
                Thread myNewThread2 = new Thread(() => owner.UpdateRutaDespacho2(Grilla, fechaDespacho, driverCode, driverName, ayudanteCode,
                    ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca, fechaDespacho, driverCode, driverName, driverLicence,
                    ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca
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
    }
}
