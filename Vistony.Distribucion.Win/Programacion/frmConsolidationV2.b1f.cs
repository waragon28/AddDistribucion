using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.BLL;
using Forxap.Framework.Extensions;

namespace Vistony.Distribucion.Win.Programacion
{
    [FormAttribute("Vistony.Distribucion.Win.Programacion.frmConsolidationV2", "Programacion/frmConsolidationV2.b1f")]
    class frmConsolidationV2 : UserFormBase
    {
        public frmConsolidationV2()
        {
        }
        EntregaBLL entregaBLL = new EntregaBLL();
        SAPbouiCOM.Form oForm;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText EditText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            //oMatrix = oForm.GetMatrix("Item_2");
        }

        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        public SAPbouiCOM.Matrix oMatrix;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, bool BubbleEvent)
        {
            BubbleEvent = true;
            
        }

        private SAPbouiCOM.Button Button1;

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string Query = "CALL P_VIS_GET_PRUEBA()";
            entregaBLL.Consolidados(oForm, oMatrix, Query);
        }
    }
}
