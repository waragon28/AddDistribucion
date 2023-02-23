using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.Distribucion.Win.UltimaMilla;

namespace Vistony.Distribucion.Win
{
    class FormDataEvent
    {
        public void SB1_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            switch (BusinessObjectInfo.FormTypeEx)
            {
                case "DispatchRoute":
                    FrmDispatchRoute.formEvent(ref BusinessObjectInfo, out BubbleEvent);
                    break;
            }
        }
    }
}
