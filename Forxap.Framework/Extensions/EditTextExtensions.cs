using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM;
using SAPbobsCOM;
using System.Globalization; 

namespace Forxap.Framework.Extensions
{
   public static class EditTextExtensions
    {

       public static void Clear(this EditText editText)
       {
           editText.Value = string.Empty;
       }
       public static void SetFocus(this EditText editText)
       {
           editText.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
       }
       public static string GetString(this EditText  editText)
       {
           if (editText == null)
               throw new ArgumentNullException("editText");

           string ret = string.Empty;

           ret =  editText.Value.Trim();     

           return ret;
       }

        public static int GetInt(this EditText editText)
        {
            int ret = 0;
            // VALIDO QUE EL OBJETO NO SEA NULO
            if (editText == null)
                throw new ArgumentNullException("editText");
            // VALIDO QUE EL TEXTBOX  NO SE ENCUENTRE VACIO
            if (editText.Value.Trim().Length > 0)
                ret = Convert.ToInt32( editText.Value.Trim());

            return ret;
        }

        public static void SetNow(this EditText editText)
        {
            if (editText == null)
                throw new ArgumentNullException("editText");

            try
            {
                editText.String =    DateTime.Now.ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string GetDate(this EditText editText)
        {
            string ret = string.Empty;

            if (editText == null)
                throw new ArgumentNullException("editText");

            try
            {
               
                ret =  editText.Value;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public static void SetValue (this EditText editText, string value)
       {
           if (editText == null)
               throw new ArgumentNullException("editText");

           try
           {
               editText.String = value.Trim();
              
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }



       public static double GetDouble(this EditText editText)
       {
           if (editText == null)
               throw new ArgumentNullException("editText");

           string sourceValue = editText.Value.Trim();
            double value = 0;
           if (string.IsNullOrEmpty(sourceValue))
           {
               return 0;
           }


            //     var value = double.Parse(sourceValue, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
            //       CultureInfo.InvariantCulture);

            value = Convert.ToDouble(sourceValue);

           return value;
       }


       public static void SetDouble(this EditText editText, double? value)
       {
           if (editText == null)
               throw new ArgumentNullException("editText");

           
           if (value != null)
           {
               editText.String =  value.ToString();
           }
       }

        public static void SetInt(this EditText editText, int value)
        {
            if (editText == null)
                throw new ArgumentNullException("editText");


            if (value >= 0)
            {
                editText.String = ((int)value).ToString();
            }
        }

    }// fin de la clase


}// fin del namespace
