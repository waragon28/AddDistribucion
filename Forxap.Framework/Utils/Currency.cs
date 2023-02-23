using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbobsCOM;


using Forxap.Framework.Utils;


namespace Forxap.Framework.Utils
{
    public class Currency : Base, IDisposable
    {
        

        public static string GetSystemCurrency(SAPbobsCOM.Company oCompany ,out Sb1Error sb1Error)
        {

            SAPbobsCOM.SBObob oSBObob = null;
            SAPbobsCOM.Recordset oRecordSet = null;
            sb1Error = null;
            string ret = string.Empty;


           try
           {
                if (oCompany == null)
                     Errors.HandleErrorWithExceptionNullCompany();

                oSBObob = (SBObob)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);

                if (oSBObob == null)
                     Errors.HandleErrorWithExceptionNullSBObob();


                oRecordSet = oSBObob.GetSystemCurrency();

                if (oRecordSet == null)
                    Errors.HandleErrorWithExceptionNullRecordSet();

           
                    if (oRecordSet.RecordCount > 0)
                    {
                        ret = oRecordSet.Fields.Item(0).Value.ToString();
                    
                    }
            }

           
            catch (Exception exception)
            {
              sb1Error =  Errors.GetLastErrorFromHRException(exception);
            }
            

            finally
            {
                if (oRecordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
                    oRecordSet = null;
                    GC.Collect();
                }

                if (oSBObob != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSBObob);
                    oSBObob = null;
                    GC.Collect();
                }
                
            }

            return ret;
        }

        public static string GetLocalCurrency(SAPbobsCOM.Company oCompany, out Sb1Error sb1Error)
        {

            SAPbobsCOM.SBObob oSBObob = null;
            SAPbobsCOM.Recordset oRecordSet = null;
            sb1Error = null;
            string ret = string.Empty;


            try
            {
                if (oCompany == null)
                    Errors.HandleErrorWithExceptionNullCompany();

                oSBObob = (SBObob)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);

                if (oSBObob == null)
                    Errors.HandleErrorWithExceptionNullSBObob();

               

                oRecordSet = oSBObob.GetLocalCurrency();

                if (oRecordSet == null)
                    Errors.HandleErrorWithExceptionNullRecordSet();


                if (oRecordSet.RecordCount > 0)
                {
                    ret = oRecordSet.Fields.Item(0).Value.ToString();

                }
            }


            catch (Exception exception)
            {
                sb1Error = Errors.GetLastErrorFromHRException(exception);
            }


            finally
            {
                if (oRecordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
                    oRecordSet = null;
                    GC.Collect();
                }

                if (oSBObob != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSBObob);
                    oSBObob = null;
                    GC.Collect();
                }

            }

            return ret;
        }





        public static double GetCurrencyRateToday (string currency,out Sb1Error sb1Error)
        { 
            return GetCurrencyRate(currency, DateTime.Now.Date,  out sb1Error );
        }

        /// <summary>
        ///  Obtiene el tipo de cambio para una determinada Fecha
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <param name="sb1Error"></param>
        /// <returns></returns>
        public static double GetCurrencyRate(string currency, DateTime date,  out Sb1Error sb1Error)
        {

            SAPbobsCOM.SBObob oSBObob = null;
            SAPbobsCOM.Recordset oRecordSet = null;
            sb1Error = null;
            double ret =  0 ;


            try
            {
                if (oCompany == null)
                    Errors.HandleErrorWithExceptionNullCompany();

                oSBObob = (SBObob)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);

                if (oSBObob == null)
                    Errors.HandleErrorWithExceptionNullSBObob();

                

                oRecordSet = oSBObob.GetCurrencyRate(currency,date);

                if (oRecordSet == null)
                    Errors.HandleErrorWithExceptionNullRecordSet();


                if (oRecordSet.RecordCount > 0)
                {
                   if  (oRecordSet.RecordCount > 0)
                    ret = Convert.ToDouble( oRecordSet.Fields.Item(0).Value);

                }
            }


            catch (Exception exception)
            {
                sb1Error = Errors.GetLastErrorFromHRException(exception);
            }


            finally
            {
                if (oRecordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
                    oRecordSet = null;
                    GC.Collect();
                }

                if (oSBObob != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSBObob);
                    oSBObob = null;
                    GC.Collect();
                }

            }

            return ret;
        }



        #region IDisposable Implementation
        
        

        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~Currency()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }// fin de la clase

}// fin del namespace
