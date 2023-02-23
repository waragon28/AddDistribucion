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
            SAPbobsCOM.BoFieldTypes ret = SAPbobsCOM.BoFieldTypes.db_Alpha;

            try
            {
                ret = (SAPbobsCOM.BoFieldTypes)Enum.Parse(typeof(SAPbobsCOM.BoFieldTypes), value);
            }
            catch (Exception ex)
            {
                LogFile.Error(ex.ToString(), true);
            }


            return ret;

        }

        public static SAPbobsCOM.BoYesNoEnum ToBoYesNoEnum(bool value)
        {
            SAPbobsCOM.BoYesNoEnum ret = SAPbobsCOM.BoYesNoEnum.tNO;
            try
            {
                
                    if (value)
                        ret = SAPbobsCOM.BoYesNoEnum.tYES;
                    else
                        ret = SAPbobsCOM.BoYesNoEnum.tNO;
                
            }
            catch (Exception ex)
            {
                LogFile.Error(ex.ToString(),true);
            }

            return ret;

            
        }

        public static SAPbobsCOM.BoYesNoEnum BoYesNoEnum(string value)
        {
            string boYesNo = string.Empty;
            SAPbobsCOM.BoYesNoEnum ret = SAPbobsCOM.BoYesNoEnum.tNO ;

            try
            {

                if (value != null)
                {
                    if (value.Length > 0)
                        boYesNo = value;
                    else
                        boYesNo = value;
                }


                ret = (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), boYesNo);

            }
            catch (Exception ex)
            {
                LogFile.Error(ex.ToString(), true);
            }

            return ret;
        }

        public static bool ToBoolean (SAPbobsCOM.BoYesNoEnum boYesNo)
        {
            bool ret = false;

            try
            {
                if (boYesNo == SAPbobsCOM.BoYesNoEnum.tYES)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.Error(ex.ToString(), true);
            }



            return ret;
        }





    }// final de la clase

}// final del namespace
