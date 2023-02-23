using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;
using Forxap.Banco.UI.Win.Configuracion;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.Win.Mantenimiento;
using Vistony.Distribucion.Win.UltimaMilla;

namespace Vistony.Distribucion.Win
{
    public class SB1_FormMenuEvent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_FormMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                
                switch (Application.SBO_Application.Forms.ActiveForm.TypeEx)
                {
                    
                  case AddonWinForms.frmPuntoEmisionUsuario:
                       {

                           FrmPuntoEmisionUsuario.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }
                    case AddonWinForms.frmDisparchRoute:
                        {
                            FrmDispatchRoute.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }


                }

            }
            catch (Exception)
            {

                // TODO: crear un log de forma asincrona
                //Forxap.Framework.UI.Messages.ShowError(ex.ToString());
            }



        }// fin del metodo FormMenuEvent



    }// fin de la clase

}// fin del namespace
