//#define AD_PE
//#define AD_BO
//#define AD_EC
//#define AD_PY
#define AD_CL


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.Constans;
using Forxap.Framework.Extensions;
using System.Threading;
using Forxap.Framework.UI;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmConsolidationSLDAsignar", "Programacion/frmConsolidationSLDAsignar.b1f")]
    class frmConsolidationSLDAsignar : UserFormBase
    {
        frmConsolidationSLD OwnerForm;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();

        public frmConsolidationSLDAsignar()
        {
        }

        public frmConsolidationSLDAsignar(frmConsolidationSLD ownerForm)
        {
            EditText0.Value = DateTime.Now.ToString("yyyyMMdd");

            OwnerForm = ownerForm;

        }

        public SAPbouiCOM.Form oForm;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
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
            Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryConsolited);
            oForm.ScreenCenter();
        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            bool ret = false;
            string tipoConsolidado = string.Empty;
            string fechaConsolidado = string.Empty;

            

            /// valida que seleccionen un tipo de consolidado

            /// pide confirmacion para proceder con la consolidacion
                ret = Sb1Messages.ShowQuestion(string.Format(addonMessageInfo.MessageIdiomaMessage317(Sb1Globals.Idioma), ComboBox0.GetSelectedDescription()));

            if (ret)
            {
#if AD_PE
                frmConsolidationSLD owner = this.OwnerForm;
                tipoConsolidado = ComboBox0.GetSelectedDescription().Trim();
                fechaConsolidado = EditText0.Value.Trim();

                Thread myNewThread = new Thread(() => owner.UpdateEstadoConsolidadoSLD(tipoConsolidado, fechaConsolidado));
                myNewThread.Start();
                oForm.Close();
#elif AD_BO
                frmConsolidationSLD owner = this.OwnerForm;
                tipoConsolidado = ComboBox0.GetSelectedDescription().Trim();
                fechaConsolidado = EditText0.Value.Trim();

                Thread myNewThread = new Thread(() => owner.UpdateEstadoConsolidadoSLD(tipoConsolidado, fechaConsolidado));
                myNewThread.Start();
                oForm.Close();
#else
                frmConsolidationSLD owner = this.OwnerForm;
                tipoConsolidado = ComboBox0.GetSelectedDescription().Trim();
                fechaConsolidado = EditText0.Value.Trim();

                Thread myNewThread = new Thread(() => owner.UpdateEstadoConsolidadoSLD(tipoConsolidado, fechaConsolidado));
                myNewThread.Start();
                oForm.Close();
#endif

            }

        }
    }
}
