using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.BLL;

namespace Vistony.Distribucion.Win.Mantenimiento
{
    [FormAttribute("FrmSerieSUNAT", "Mantenimiento/FrmSerieSUNAT.b1f")]
    class FrmSerieSUNAT : UserFormBase
    {
        public FrmSerieSUNAT()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button2;
        SAPbouiCOM.Matrix oMatrix;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        EntregaBLL entregaBLL = new EntregaBLL();
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_3").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_5").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_6").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_9").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_10").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Matrix0.AutoResizeColumns();
            Utils.LoadQueryDynamic(ref ComboBox0, addonMessageInfo.QueryObtenerSerieSUNAT);
            ComboBox0.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);
            Folder0.Select();
            if(Sb1Globals.AdminPuntoEmision == "1")
            {
                Utils.LoadQueryDynamic(ref ComboBox1, string.Format(addonMessageInfo.QueryComboBoxSucursales,Sb1Globals.UserSignature));
                ComboBox1.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
            }
            else
            {
                Utils.LoadQueryDynamic(ref ComboBox1,string.Format("CALL SP_VIS_DIS_OBTENERPUNTOEMISION('{0}')",Sb1Globals.UserSignature));
                ComboBox1.Select(1, SAPbouiCOM.BoSearchKey.psk_Index);

            }

            

        }


        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           entregaBLL.addItem(oForm, string.Format(addonMessageInfo.QueryObtenerDocumentosSUNAT, ComboBox0.Value, ComboBox1.Value));
        }


        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string Code = ComboBox0.GetValue();
            oMatrix = oForm.GetMatrix("Item_9");
            entregaBLL.ActualizarCorrelativoSunat(oForm,Code, Matrix0);
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }
    }
}
