using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Forxap.Framework.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveNonNumericChars(this string value, string decimalSeparator)
        {
            string ret = string.Empty;

            if (value.Length > 0)
            {
                Regex regex = new Regex(String.Format(@"[^-?\d+\{0}]", decimalSeparator));

                ret = regex.Replace(value, "");
            }
            return ret;
        }

        public static string RemoveNonNumericChars(this string value)
        {
            string ret = string.Empty;

            if (value.Length > 0)
            {

                ret = Regex.Replace(value, @"[^-?\d+\{0}]", "");

                //Regex regex = new Regex(String.Format(@"[^-?\d+\{0}]", decimalSeparator));
                
            }
            return ret;
        }


        public static bool IsNumber(this string key)
        {
            return Regex.IsMatch(key, @"^[0-9]*\.?[0-9]+$");
        }

        /// <summary>
        /// retorna una fecha en formato dd-MM-yyyy
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static DateTime ToDate(this  string strDate)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));

            string year = strDate.Substring(0, 4);
            string month = strDate.Substring(4, 2);
            string day = strDate.Substring(6, 2);

            return Convert.ToDateTime(day + "-" + month + "-" + year);

        }

        /// <summary>
        /// retorna una cadena en formato yyyy-MM-dd
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string ToDateSAP(this  string strDate)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));

            string date = string.Empty;

            if (strDate.Length > 0)
            {
                string year = strDate.Substring(0, 4);
                string month = strDate.Substring(4, 2);
                string day = strDate.Substring(6, 2);

                return date = (year + "-" + month + "-" + day);
            }

            return date;
        }


        /// <summary>
        /// Utilizar cuando la entrada es formato "dd/mm/yyyy"
        ///  retorna una cadena en formato yyyyMMdd
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string ToDateSAPEx(this  string strDate)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));

            string date = string.Empty;

            if (strDate.Length > 0)
            {
                string year = strDate.Substring(0, 4);
                string month = strDate.Substring(4, 2);
                string day = strDate.Substring(6, 2);

                return date = (year + month + day );
            }

            return date;
        }
        public static string ToDateSAPEx2(this string strDate)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));

            string date = string.Empty;

            if (strDate.Length > 0)
            {
                string year = strDate.Substring(6, 4); // 06/09/2021
                string month = strDate.Substring(3, 2);
                string day = strDate.Substring(0, 2);

                return date = (year + month + day);
            }

            return date;
        }

        public static string ToTimeSave(this string time)
        {
            string  strTime = string.Empty ;

            if (time.Length > 0)
            {
                strTime = time.RemoveNonNumericChars().ToString();
            }
            return strTime;
        }

        public static string ToTime(this  string time)
        {
            //DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            //return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));
            string timeStr = time.RemoveNonNumericChars(":").Replace(":", "").ToString();//Agregadas las funciones RemoveNonNumericChars y Replace - Gustavo Alexander Carrillo Rueda (07/08/2018 14:41)

            int longitud = timeStr.Length;
            string firstPart = string.Empty;
            string lastPart = string.Empty;

            if (longitud == 4)
            {
                //firstPart = time.Substring(0, 2);
                //lastPart = time.Substring(2, 2);
                firstPart = timeStr.Substring(0, 2);//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)
                lastPart = timeStr.Substring(2, 2);//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)
            }
            else if (longitud == 3)
            {
                //firstPart = "0" + time.Substring(0, 1);//Agregué un 0 a firstPart - Gustavo Alexander Carrillo Rueda (07/08/2018 14:12)
                //lastPart = time.Substring(1, 2);
                firstPart = "0" + timeStr.Substring(0, 1);//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)
                lastPart = timeStr.Substring(1, 2);//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)
            }

            else if (longitud == 2)
            {
                firstPart = "00";
                //lastPart = time.PadRight(2);
                lastPart = timeStr;//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)
            }

            else if (longitud == 1)
            {
                firstPart = "00";
                //lastPart = "0" + time.PadRight(1);//Agregué un 0 a lastPart - Gustavo Alexander Carrillo Rueda (07/08/2018 14:06)
                lastPart = "0" + timeStr;//Asignación agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 15:24)


            }
            //Condición agregada - Gustavo Alexander Carrillo Rueda (07/08/2018 16:32)
            else if (longitud == 0)
            {
                return "";
            }






            return firstPart + ":" + lastPart;

        }


        public static bool isTime(this  string value)
        {
            //bool ret = true;//Comentado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:30)
            //if ((value.Length != value.RemoveNonNumericChars(":").Length) || (value.Length - value.RemoveNonNumericChars(":").Replace(":", "").Length > 1)) return false;//Agregado - Gustavo Alexander Carrillo Rueda (07/08/2018 17:13)
            value = value.RemoveNonNumericChars(":").Replace(":", "");//Agregado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:34)


            if (value.Length >= 0 && value.Length < 5)//Condición value.Length < 5 - Gustavo Alexander Carrillo Rueda (07/08/2018 10:18)
            {
                //Contenido Comentado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:29)
                //string[] array = value.Split(':');

                //if (!value.Contains(":"))
                //{
                //    ret = false;
                //}
                ////Condición agregada por Gustavo Alexander Carrillo Rueda(GACR) 03/08/2018 12:00
                ////Modificada - Gustavo Alexander Carrillo Rueda (07/08/2018 10:21)
                //else if ((array[0].Length != 2) || (array[1].Length != 2))
                //{
                //    ret = false;
                //}
                ////Fin de la condición agregada por GACR
                //else if (Convert.ToInt32(array[0]) < 0 | Convert.ToInt32(array[0]) > 23)
                //{
                //    ret = false;
                //}
                //else if (Convert.ToInt32(array[1]) < 0 | Convert.ToInt32(array[1]) > 59)
                //{
                //    ret = false;
                //}

                int longitud = value.Length;

                if (longitud == 4)
                {
                    return (Convert.ToInt32(value.Substring(0, 2)) >= 0 && Convert.ToInt32(value.Substring(0, 2)) < 24) && (Convert.ToInt32(value.Substring(2, 2)) >= 0 && Convert.ToInt32(value.Substring(2, 2)) < 60);
                }
                else if (longitud == 3)
                {
                    return (Convert.ToInt32(value.Substring(0, 1)) >= 0 && Convert.ToInt32(value.Substring(0, 1)) < 10) && (Convert.ToInt32(value.Substring(1, 2)) >= 0 && Convert.ToInt32(value.Substring(1, 2)) < 60);
                }

                else if (longitud == 2)
                {
                    return (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) < 60);
                }

                else if (longitud == 1)
                {
                    return (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) < 10);
                }
                else if (longitud == 0) return true;

                return false;
            }
            else
            {
                //ret = false;//Comentado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:30)
                return false;//Agregado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:31)
            }

            //else if (array.GetLength ==)





            //else if (!IsNumeric(arr[0]))
            //    return false;
            //else if (!IsNumeric(arr[1]))
            //    return false;
            //else if (!IsNumeric(arr[2]))
            //    return false;
            //else if (arr[0] < 0 | arr[0] > 23)
            //    return false;
            //else if (arr[1] < 0 | arr[0] > 59)
            //    return false;
            //else if (arr[2] < 0 | arr[0] > 59)
            //    return false;

            //return ret;//Comentado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:30)
            return false;//Agregado - Gustavo Alexander Carrillo Rueda (07/08/2018 14:31)
        }


        /// <summary>
        ///  quita los acentos y devuelve un string 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static string RemoveAccents(this string value)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string RemoveArroba(this string value)
        {
            return value.Replace("@",string.Empty);
            
        }

    }// fin de la clase


}// fin del namespace
