using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.Constans;
using Forxap.Framework.Extensions;
using System.Threading;
using Vistony.Distribucion.Win.Formularios;
using Forxap.Framework.UI;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("Vistony.Distribucion.Win.UltimaMilla.frmCambiarEstadoDespacho", "UltimaMilla/frmCambiarEstadoDespacho.b1f")]
    class frmCambiarEstadoDespacho : UserFormBase
    {
        private frmEstadoDespachos OwnerForm;

        private SAPbouiCOM.StaticText StaticText0;
        public SAPbouiCOM.Form oForm;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText0;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public frmCambiarEstadoDespacho(frmEstadoDespachos FormID)
        {
            OwnerForm =FormID;
            Utils.LoadQueryDynamicStatus(ref ComboBox0, AddonMessageInfo.QueryStatusDelivery);
            Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryListOcurrencia);
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_2").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_5").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
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

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            frmEstadoDespachos owner = this.OwnerForm;
            if (ComboBox0.GetSelectedValue() == "A")
            {
                bool Consulta = Sb1Messages.ShowQuestion("Seguro de grabar la Ocurrencia " + ComboBox1.GetSelectedDescription() + " a los registros marcados?");
                if (Consulta)
                {
                    if (ComboBox1.GetSelectedValue() == "") { Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage330(Sb1Globals.Idioma)); }
                    else { owner.ProcesoOcurrencia(ComboBox1.GetSelectedValue(), ComboBox1.GetSelectedDescription(), ComboBox0.GetSelectedValue()); } /*Agregar Ocurrencia*/
                }
            }
            else if (ComboBox0.GetSelectedValue() == "E")
            {
                bool Consulta = Sb1Messages.ShowQuestion("Seguro de grabar al estado " + ComboBox1.GetSelectedDescription() + " a los registros marcados?");
                if (Consulta)
                {
                    owner.AsignarEstados(ComboBox0.GetSelectedValue(), "");  /*Cambiar estado de Programación a entregado*/

                }
            }
            else if (ComboBox0.GetSelectedValue() == "P")
            {
                Sb1Messages.ShowError("No es posible cambiar al estado " + ComboBox0.GetSelectedValue());    // Sb1Messages.ShowError(AddonMessageInfo.Message329);
            }
            else if (ComboBox0.GetSelectedValue() == "S")
            {
                Sb1Messages.ShowError("No es posible cambiar al estado "+ ComboBox0.GetSelectedValue());
            }
            else if (ComboBox0.GetSelectedValue() == "V")
            {
                bool Consulta = Sb1Messages.ShowQuestion("Seguro de grabar la Ocurrencia " + ComboBox1.GetSelectedDescription() + " a los registros marcados?");
                if (Consulta)
                {
                    if (ComboBox1.GetSelectedValue() == "") { Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage330(Sb1Globals.Idioma)); }
                    else { owner.ProcesoOcurrencia(ComboBox1.GetSelectedValue(), ComboBox1.GetSelectedDescription(), ComboBox0.GetSelectedValue()); } /*Agregar Ocurrencia*/
                }
            }
            else
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage328(Sb1Globals.Idioma));
            }
            //Thread mythr = new Thread(AsignarEstados);
            //mythr.Name = "Estado";
            //mythr.Start();
            //mythr.IsBackground = true;
            oForm.Close();
        }

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (ComboBox0.GetSelectedValue() == "V")
            {
                ComboBox1.Item.Visible = true;
                StaticText2.Item.Visible = true;

                StaticText3.Item.Visible = false;
                EditText0.Item.Visible = false;
            }
            else if (ComboBox0.GetSelectedValue() == "A")
            {
                ComboBox1.Item.Visible = true;
                StaticText2.Item.Visible = true;

                StaticText3.Item.Visible = false;
                EditText0.Item.Visible = false;
            }
            else if (ComboBox0.GetSelectedValue() == "P")
            {
                StaticText2.Item.Visible = false;
                ComboBox1.Item.Visible = false;

                StaticText3.Item.Visible = true;
                EditText0.Item.Visible = true;
            }
            else
            {
                StaticText2.Item.Visible = false;
                ComboBox1.Item.Visible = false;
                StaticText3.Item.Visible = false;
                EditText0.Item.Visible = false;
            }

        }


    }
}
