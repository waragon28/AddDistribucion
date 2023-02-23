using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;
using Forxap.Framework.Utils;

namespace Forxap.Framework.DI
{
    public class Sb1QueryCategory : Base, IDisposable
    {

        /// <summary>
        ///  Crea una categoría dentro del Query Manager
        /// </summary>
        /// <param name="oCompany"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool CreateCategory(string categoryName, out Sb1Error sb1Error)
        {

            bool ret = false;
            int retCode = 0;


            sb1Error = null;

            SAPbobsCOM.QueryCategories oQueryCategory = (QueryCategories)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oQueryCategories);

    
            if (oQueryCategory != null)
            {
                oQueryCategory.Name = categoryName;

                try
                {
                //    if (!oQueryCategory.GetByKey(categoryName) )
                    retCode = oQueryCategory.Add();

                    if (retCode == 0)
                    {
                        ret = true; ;
                    }

                    else
                    {
                        sb1Error = Errors.GetLastErrorMessage();
                    }
                }
                catch (Exception ex)
                {
                   sb1Error = Errors.GetLastErrorFromHRException( ex);
                }

                finally
                {
                    if (oQueryCategory != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oQueryCategory);
                }
            }

            return ret;
        }

        

        
        #region Disposable
        
        


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
        ~Sb1QueryCategory()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase

}// fin del namespace
