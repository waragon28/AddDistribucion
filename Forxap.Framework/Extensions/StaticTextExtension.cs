using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Forxap.Framework.Extensions
{
    public static class StaticTextExtension
    {

        public static void SetUnderline(this  SAPbouiCOM.StaticText label)
        {
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_UNDERLINE;
     
        }


        public static void SetFormatLinkEx(this  SAPbouiCOM.StaticText label)
        {
            
           // label.Item.ForeColor = ColorTranslator.ToOle(Color.LightSkyBlue);

           // label.Item.ForeColor = ColorTranslator.ToOle(Color.AliceBlue);

           // label.Item.ForeColor = ColorTranslator.ToOle(Color.CadetBlue);
           // label.Item.ForeColor = ColorTranslator.ToOle(Color.DarkBlue);
           // label.Item.ForeColor = ColorTranslator.ToOle(Color.DeepSkyBlue);
           //  label.Item.ForeColor = ColorTranslator.ToOle(Color.AliceBlue);
           // label.Item.ForeColor = ColorTranslator.ToOle(Color.CornflowerBlue);// puede ser
            
            label.Item.ForeColor = ColorTranslator.ToOle(Color.Blue);
            
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
 
        }

        public static void SetColor(this SAPbouiCOM.StaticText label, Color color)
        {
            label.Item.ForeColor = ColorTranslator.ToOle(color);
        }
        public static void SetHeight(this SAPbouiCOM.StaticText label, int height)
        {
            label.Item.Height = height;

        }
        public static void SetFormatLink(this  SAPbouiCOM.StaticText label)
        {
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_UNDERLINE;

            
            label.Item.ForeColor = ColorTranslator.ToOle(Color.SteelBlue);


        }

        public static void SetFormatDescription(this SAPbouiCOM.StaticText label)
        {
            label.Item.ForeColor = ColorTranslator.ToOle(Color.Gray);
        }

        public static void SetBold(this SAPbouiCOM.StaticText label)
        {
            label.Item.TextStyle = (int)SAPbouiCOM.BoTextStyle.ts_BOLD;
            
        }

        public static void SetSize(this SAPbouiCOM.StaticText label, int size)
        {
            label.Item.FontSize  = size;
        }

        public static void SetUnderLine(this SAPbouiCOM.StaticText label)
        {
            label.Item.FontSize = (int)SAPbouiCOM.BoTextStyle.ts_UNDERLINE;
        }


    }// fin de la clase


}// fin del namespace
