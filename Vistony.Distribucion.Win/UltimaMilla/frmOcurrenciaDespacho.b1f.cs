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
using Vistony.Distribucion.BO;
using Vistony.Distribucion.DAL;
using Vistony.Distribucion.Win.Formularios;
using Vistony.Distribucion.Win.Asistentes;
using Vistony.Distribucion.Constans;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("OcurrenciaDespacho", "UltimaMilla/frmOcurrenciaDespacho.b1f")]
    class frmOcurrenciaDespacho : BaseWizard
    {
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        frmEstadoDespachos OwnerForm;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox ComboBox1;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public frmOcurrenciaDespacho(frmEstadoDespachos FormID)
        {
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryListOcurrencia);
            //Utils.LoadQueryDynamic(ref ComboBox1, AddonMessageInfo.QueryStatusDelivery);
            OwnerForm = FormID;
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
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_3").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
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

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();

        }

        private void EditText0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
    //        throw new System.NotImplementedException();

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (ComboBox0.GetSelectedDescription() == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage312(Sb1Globals.Idioma), SAPbouiCOM.BoMessageTime.bmt_Short);
                return;
            }
            if (ComboBox1.GetSelectedDescription() == "")
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage313(Sb1Globals.Idioma), SAPbouiCOM.BoMessageTime.bmt_Short);
                return;
            }
            bool Consulta = Sb1Messages.ShowQuestion("Seguro de grabar la Ocurrencia " + ComboBox0.GetSelectedDescription() + " a los registros marcados?");
            if (Consulta)
            {
                frmEstadoDespachos owner = this.OwnerForm;
                string Ocurrencia = ComboBox0.GetSelectedValue();
                string Estado = ComboBox1.GetSelectedValue();
                Thread myNewThread = new Thread(() =>
                owner.ProcesoOcurrencia(ComboBox0.GetSelectedValue(), Ocurrencia,Estado));
                myNewThread.Start();
                oForm.Close();
            }
        }

        private SAPbouiCOM.Grid Grid0;

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            if (ComboBox0.GetSelectedValue()=="V")
            {
                ComboBox1.Item.Visible = false;
            }
        }
    }
}
