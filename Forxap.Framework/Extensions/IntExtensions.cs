using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework.Extensions
{
    public static class IntExtensions
    {

        public static string ToTime(this  int time)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));
            string timeStr = time.ToString();

            int longitud = timeStr.Length;
            string resultado = string.Empty;
            
            if (longitud == 4)
            {
                resultado = timeStr.PadLeft(2) + ":" + timeStr.PadRight(2);
            }
            else if  (longitud == 3)
            {
                resultado = timeStr.PadLeft(1) + ":" + timeStr.PadRight(2);
            }
            else if (longitud == 2)
            {
                resultado = "00:" + timeStr.PadRight(2);
            }
            else if (longitud == 1)
            {
                resultado = "00:0" + timeStr.PadRight(1); 
            }


            return resultado;

        }


    }// fin de la clase


}// fin del namespace
