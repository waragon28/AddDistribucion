using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Vistony.Distribucion.Win.Asistentes
{ 
    [FormAttribute("BaseWizard", "Asistentes/BaseWizard.b1f")]
    public class BaseWizard :  UserFormBase
    {

        public SAPbouiCOM.Form oForm;
        public SAPbouiCOM.Grid oGrid;
        public int panelevel = 1;
        public int paneMax = 3;
        public SAPbouiCOM.StaticText lblTitle;
        public SAPbouiCOM.StaticText lblPageNumber;
        public SAPbouiCOM.Button btnPrior;
        public SAPbouiCOM.Button btnNext;
        public SAPbouiCOM.Button btnCancel;
   
        /// <summary>
        /// 
        /// </summary>
        public int PaneLevel
        {
            get { return oForm.PaneLevel; }
            set { oForm.PaneLevel = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int PaneMax
        {
            get { return paneMax; }
            set { paneMax = value; }
        }
        

    /*    public BaseWizard()
        {
        }
        */
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }
    }
}
