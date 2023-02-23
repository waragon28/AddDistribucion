using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Forxap.Banco.UI.Win.Configuracion
{
    [FormAttribute("Forxap.Payroll.Win.Configuracion.frmBase", "Configuracion/frmBase.b1f")]
    class frmBase : UserFormBase
    {
        public static SAPbouiCOM.Form oForm { get; set; }
        public SAPbouiCOM.Button btnOK;
        public SAPbouiCOM.Button btnCancel;
        public SAPbouiCOM.Matrix oMatrix;
      //  public string FormType { get; set; }

        public virtual void LoadData () {}
        public virtual void EnabledMenu() {}

  //      public virtual void FormCenter() { }
        public frmBase()
        {
            //Forxap.Framework.UI.Messages.ShowMessageBox("test BAse");

          //  FormCenter();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
           // this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
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
            LoadData();

            oForm.DefButton = "1";


        }



        //public void FormCenter()
        //{
        //    oForm.Left = (this.UIAPIRawForm.ClientWidth - oForm.Left) / 2;
        //    oForm.Top = (this.UIAPIRawForm.ClientHeight - oForm.Top) / 2;
        //}  
    }
}
