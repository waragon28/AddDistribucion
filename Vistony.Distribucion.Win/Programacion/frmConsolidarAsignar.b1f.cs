using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Win.Asistentes;
using Vistony.Distribucion.Constans;
using Forxap.Framework.UI;
using Vistony.Distribucion.BO;

using Newtonsoft.Json;
using RestSharp;
using Vistony.Distribucion.DAL;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Data;
using System.ComponentModel;
using Vistony.Distribucion.Win;
using Vistony.Distribucion.BLL;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("frmDatosConsolidar", "Programacion/frmConsolidarAsignar.b1f")]
    class frmConsolidarAsignar : BaseWizard
    {
        frmConsolidation OwnerForm;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        Idioma_BLL idioma_BLL = new Idioma_BLL();

        bool Modal = true;
        string IDForm = "";

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;

        private SAPbouiCOM.ComboBox ComboBox0;

        private SAPbouiCOM.EditText EditText0;

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;


        public frmConsolidarAsignar(frmConsolidation ownerForm)
        {
            EditText0.Value = DateTime.Now.ToString("yyyyMMdd");
            
            OwnerForm = ownerForm;

        }

        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.DeactivateAfter += new SAPbouiCOM.Framework.FormBase.DeactivateAfterHandler(this.Form_DeactivateAfter);
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.VisibleAfter += new VisibleAfterHandler(this.Form_VisibleAfter);

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryConsolited);
            oForm.Select();
            idioma_BLL.GetPackIdiomafrmAsignationConsolidation(Sb1Globals.Idioma, oForm,StaticText0, StaticText1,
                Button0,Button1);

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (string.IsNullOrEmpty(ComboBox0.GetSelectedDescription()))
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage316(Sb1Globals.Idioma), SAPbouiCOM.BoMessageTime.bmt_Short);
                BubbleEvent = false;
            }

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            bool ret = false;
            string tipoConsolidado = string.Empty;
            string fechaConsolidado = string.Empty;

            Modal = false;

            // valida que seleccionen un tipo de consolidado
            // pide confirmacion para proceder con la consolidacion
            ret = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage317(Sb1Globals.Idioma), ComboBox0.GetSelectedDescription()));

            if (ret)
            {

                Modal = false;
                frmConsolidation owner = this.OwnerForm;
                tipoConsolidado = ComboBox0.GetSelectedDescription().Trim();
                fechaConsolidado = EditText0.Value.Trim();

                Thread myNewThread = new Thread(() => owner.UpdateEstadoConsolidadoEntrega(tipoConsolidado, fechaConsolidado));
                myNewThread.Start();
                oForm.Close();

            }
            else
            {
                Modal = true;
            }
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            frmConsolidation owner = this.OwnerForm;
            oForm.Close();
        }

        private void Form_DeactivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Modal)
                    oForm.Select();

            }
            catch (Exception)
            {

            }

        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           

        }

        private void Form_VisibleAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }

    }
}
