using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Forxap.Framework.Extensions
{


    public static class DoubleExtensions
    {
        /// <summary>
        /// redondea un número hacia arriba
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double RoundUp(this double value, int decimalPlaces)
        {
            double multiplier = System.Math.Pow(10, Convert.ToDouble(decimalPlaces));
            return System.Math.Ceiling(value * multiplier) / multiplier;
            
        }

        public static double Redondeo(this double value, int decimalPlaces)
        {
            double multiplier = System.Math.Pow(10, Convert.ToDouble(decimalPlaces));
            return System.Math.Ceiling(value * multiplier) / multiplier;

        }

        public static int Contar(this string cadena)
        {
            return 15;
        }

        public static double RoundDown(this double value, int decimalPlaces)
        {
            double multiplier = System.Math.Pow(10, Convert.ToDouble(decimalPlaces));
            return System.Math.Floor(value * multiplier) / multiplier;
        }
    }

}
