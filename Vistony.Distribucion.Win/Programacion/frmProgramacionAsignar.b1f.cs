using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Vistony.Distribucion.BLL;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;
using System.Threading;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("frmProgramacionAsignar", "Programacion/frmProgramacionAsignar.b1f")]
    class frmProgramacionAsignar : UserFormBase
    {
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private frmPrograming OwnerForm;
        public SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private string sucursal = string.Empty;
        private string usuario = string.Empty;

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText7;



        private void SetViisbleControl(bool value)
        {
            StaticText1.Item.Visible = value;
            StaticText2.Item.Visible = value;
            StaticText3.Item.Visible = value;
            StaticText4.Item.Visible = value;
            
            
            EditText0.Item.Visible = value;
            EditText1.Item.Visible = value;
            EditText2.Item.Visible = value;
            EditText3.Item.Visible = value;
            EditText4.Item.Visible = value;
            EditText5.Item.Visible = value;

        }
        public frmProgramacionAsignar(frmPrograming ownerForm, string usuario, string sucursal, bool value,string choferCode, string choferName,string choferLicencia, string vehiculoCode, string vehiculoMarca, string vehiculoPlaca,string ayudanteCode, string ayudanteName)
        {
            OwnerForm = ownerForm;

            SetViisbleControl(value);
            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = sucursal;
            cfl1.SetConditions(cons1);

            EditText6.Value = DateTime.Now.AddDays(1).ToString("yyyyMMdd");
            StaticText0.SetBold();
            StaticText0.Item.Height = 20;

            StaticText7.SetUnderline();

            // codigo del chofer
            oForm.GetDBDataSource("@SYP_CONDUC").SetString("Code", 0, choferCode);

            // nombre del chofer
            oForm.GetDBDataSource("@SYP_CONDUC").SetString("Name", 0, choferName);

            oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_SYP_CHLI",0,choferLicencia);


            // vehiculo placa
            oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_VIS_Vehiculo", 0, vehiculoPlaca);

            // vehiculo código
            oForm.GetDBDataSource("@SYP_VEHICU").SetString("Code", 0, vehiculoCode);


            // vehiculo marca
            oForm.GetDBDataSource("@SYP_VEHICU").SetString("U_SYP_VEMA", 0, vehiculoMarca);


            // código de ayudante
            oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Code", 0, ayudanteCode);

            // nombre de ayudante
            oForm.GetDBDataSource("@VIS_DIS_OAYD").SetString("Name", 0, ayudanteName );




        }
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            //       this.Button0.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button0_ChooseFromListAfter);
            //     this.Button0.ChooseFromListBefore += new SAPbouiCOM._IButtonEvents_ChooseFromListBeforeEventHandler(this.Button0_ChooseFromListBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
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
        }
        private void EditText1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
        //    SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
        //    try
        //    {

        //        if (chooseFromListEvent.SelectedObjects != null)
        //        {
        //            if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
        //            {
        //             //   EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString(); // codigo del ayudante
        //                EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString(); // nombre del ayudante


                     
        //            }
        //        }

            //}
            //catch (Exception ex)
            //{
            //    // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            //}
        }
        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            bool response = false;
            string fechaDespacho = string.Empty;

            string driverCode = string.Empty;
            string driverName = string.Empty;
            string driverLicence = string.Empty;

            string ayudanteCode = string.Empty;
            string ayudanteName = string.Empty;

            string vehiculoCode = string.Empty;
            string vehiculoPlaca = string.Empty;
            string vehiculoMarca = string.Empty;

            fechaDespacho = EditText6.Value.Trim();

            driverCode = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Code");

            if (!string.IsNullOrEmpty(driverCode.ToString().Trim()))
            {
                driverName = oForm.GetDBDataSource("@SYP_CONDUC").GetString("Name");
                driverLicence = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_SYP_CHLI");


                ayudanteCode = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Code");
                ayudanteName = oForm.GetDBDataSource("@VIS_DIS_OAYD").GetString("Name");

                vehiculoCode = oForm.GetDBDataSource("@SYP_VEHICU").GetString("Code");
                vehiculoPlaca = oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo");
                vehiculoMarca = oForm.GetDBDataSource("@SYP_VEHICU").GetString("U_SYP_VEMA");



                /// pide confirmacion para proceder con la programación
                response = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage319(Sb1Globals.Idioma)));

                if (response)
                {
                    //   Modal = false;
                    frmPrograming owner = this.OwnerForm;

                    // caso 1, solo seleccionan la fecha de la programación

                   // Thread myNewThread = new Thread(() => owner.UpdateDespacho(fechaDespacho, driverCode, driverName,driverLicence, ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca));
                   // myNewThread.Start();


                    Thread myNewThread2 = new Thread(() => owner.AddRutaDespacho(fechaDespacho, driverCode, driverName, ayudanteCode, ayudanteName, vehiculoCode, vehiculoPlaca, vehiculoMarca, driverLicence));
                    myNewThread2.Start();


                    // caso 2 seleccionan el conductor al cual van a programar su ruta de despacho




                    // cierro el formulario
                    oForm.Close();
                }
                else
                {
                    //Modal = true;
                }

            }
            else
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage303(Sb1Globals.Idioma));
            }

        }
        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            double vehiculeCapacity = 0;
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

                        // obtiene la placa del vehiculo
                        oForm.GetDBDataSource("@SYP_CONDUC").SetString("U_VIS_Vehiculo", 0, chooseFromListEvent.SelectedObjects.GetValue("U_VIS_Vehiculo", 0).ToString());

                        // obtiene el código de vehículo
                        oForm.GetDBDataSource("@SYP_VEHICU").SetString("Code", 0, Utils.GetVehiculeCode(oForm.GetDBDataSource("@SYP_CONDUC").GetString("U_VIS_Vehiculo", 0), ref vehiculeCapacity, ref brandName)); // // codigo del vehiculo

                        // vehiculo capacidad
                        oForm.GetDBDataSource("@SYP_VEHICU").SetDouble("U_SYP_VEPM", 0, vehiculeCapacity);

                        // vehiculo marca
                        oForm.GetDBDataSource("@SYP_VEHICU").SetString("U_SYP_VEMA", 0, brandName);


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
        private SAPbouiCOM.EditText EditText7;
        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

    }
}
