using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPbobsCOM;

using Forxap.Demo.Configuracion.BO;
using Forxap.Demo.Configuracion.BLL;

namespace Forxap.Demo.UI
{
    public class MiscelaneoUI
    {
        /// <summary>
        /// Carga un combobox con los estados civiles
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadMiscelaneo(ref  SAPbouiCOM.ComboBox oComboBox, string tableName)
        {
            if (oComboBox != null)
            {
                List<Miscelaneo> listObject = new List<Miscelaneo>();
                MiscelaneoBLL businessLogic = new MiscelaneoBLL();

                listObject = businessLogic.GetAll(tableName);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Code, item.Name);
                }

            }

        }
    }
}
