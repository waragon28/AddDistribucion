using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework.Utils
{
    public static class ConvertSAP
    {



//        Alfanumérico
//Numérico
//Fecha/Hora
//Unidades y Totales
//General

        public static SAPbobsCOM.BoFieldTypes ToBoFieldType(string value)
        {
            return (SAPbobsCOM.BoFieldTypes)Enum.Parse(typeof(SAPbobsCOM.BoFieldTypes),value);

        }
        public static SAPbobsCOM.BoYesNoEnum ToBoYesNoEnum(bool value)
        {
            SAPbobsCOM.BoYesNoEnum ret = SAPbobsCOM.BoYesNoEnum.tNO;


            {

                if (value)
                    ret = SAPbobsCOM.BoYesNoEnum.tYES;
                else
                    ret = SAPbobsCOM.BoYesNoEnum.tNO;

            }

            return ret;

            
        }

        public static SAPbobsCOM.BoYesNoEnum BoYesNoEnum(string value)
        {
            string boYesNo = string.Empty;

            if (value != null)
            {

                if (value.Length > 0 )
                    boYesNo = value;
                else
                    boYesNo = value;

            }


            return (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), boYesNo);
        }

        public static bool ToBoolean (SAPbobsCOM.BoYesNoEnum boYesNo)
        {
            bool ret = false;

            if (boYesNo == SAPbobsCOM.BoYesNoEnum.tYES)
            {
                ret = true;
            }

            return ret;
        }



    }// final de la clase

}// final del namespace
