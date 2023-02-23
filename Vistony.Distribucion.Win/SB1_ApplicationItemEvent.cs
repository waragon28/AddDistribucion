using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
namespace Vistony.Distribucion.Win
{
    public class ApplicationItemEvent
    {
        public void SB1_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = false;
            //  Don't let the user to move to other forms
            SAPbouiCOM.BoEventTypes EventEnum = 0;
            EventEnum = pVal.EventType;

            

            //if ( FormUID != "DatosConsolidar")
            //{
            //    Application.SBO_Application.Forms.ActiveForm.Select(); //  Select the modal form
            //    BubbleEvent = false;

            //}
            ////  If the modal from is closed...
            //if (FormUID == "Modal1" & (EventEnum == SAPbouiCOM.BoEventTypes.et_FORM_CLOSE) & bModal)
            //{
            //    bModal = false;
            //}
        }

    }//  fin de la clase

}//  fin del namespace
