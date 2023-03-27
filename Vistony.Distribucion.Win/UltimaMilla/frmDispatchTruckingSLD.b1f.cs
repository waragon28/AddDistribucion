using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("Vistony.Distribucion.Win.UltimaMilla.frmDispatchTruckingSLD", "UltimaMilla/frmDispatchTruckingSLD.b1f")]
    class frmDispatchTruckingSLD : UserFormBase
    {
        public frmDispatchTruckingSLD()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_7").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_9").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_10").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_11").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
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

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
    }
}
