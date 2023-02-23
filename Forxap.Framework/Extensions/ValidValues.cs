using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Framework.Extensions
{
    public static  class ValidValues
    {
        public static void Clear(this SAPbouiCOM.Column oColumn)
        {
            int a = 0;
            if ( oColumn.ValidValues.Count > 0 )
            {
               for (int i = 1; i < oColumn.ValidValues.Count - 1; i++)
                {
                    oColumn.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
                  
               }

               a = oColumn.ValidValues.Count;


            }
        }


    }// fin de la clase

}// fin del namespace
