using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbobsCOM;
using Forxap.Framework.Utils;
using System.IO;

namespace Forxap.Framework.DI
{
    public class Sb1QueryUser :Base, IDisposable
    {
        SAPbobsCOM.UserQueries oUserQueries = (SAPbobsCOM.UserQueries)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserQueries);
        SAPbobsCOM.QueryCategories oQueryCategory = (QueryCategories)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oQueryCategories);

       public string GetByKey(string categoryName, string queryName)
        {
            string ret = string.Empty;
            int categoryCode = 0;
            int queryCode = 0;


            // si lo encuentra
            if ( oUserQueries.GetByKey(queryCode, categoryCode) )
            {

                ret = oUserQueries.Query.ToString();
            }



            return ret;
        }

       public void CreateQuery(string categoryName, string queryName, string fileName, out Sb1Error sb1Error)
        {
        //   oUserQueri es.
        //   oUserQueries.QueryType = UserQueryTypeEnum.uqtStoredProcedure;
        //   SAPbobsCOM.FormattedSearches oFormatted = (SAPbobsCOM.FormattedSearches)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oFormattedSearches);

            // busco el ID de la categoría
            string sqlStr = "SELECT CategoryId FROM OQCN WHERE CatName = '{0}'";

           // con el categoryName obtengo el codigo de la categorya
          // oQueryCategory.GetByKey
           int categoryCode = 0;
           string queryScript = string.Empty;
           
           // busco el codigo de la categoria ingresada
           categoryCode = Convert.ToInt32( Forxap.Framework.DI.Helper.Querys.GetSingleValue(string.Format(sqlStr, categoryName), out sb1Error));



           // si la categoria no existe entonces la agrego
           if (categoryCode < 1)
           {
               oQueryCategory.Name = categoryName;
               oQueryCategory.Add();

               categoryCode = Convert.ToInt32(Forxap.Framework.DI.Helper.Querys.GetSingleValue(string.Format(sqlStr, categoryName), out sb1Error));

           }

           // con el fileName debo obtener el archivo sql leerlo y asignarlo a la variable queryScriotx|

           

           // debo abrir el archivo recorrerlo  y ponerlo en una variable


            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    queryScript += sr.ReadLine();
                }
            }
 
           
            oUserQueries.QueryDescription = queryName;
            oUserQueries.QueryCategory = categoryCode;
            oUserQueries.Query = queryScript;
            oUserQueries.Add();    
           
            

            sb1Error = null;
    

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
        ~Sb1QueryUser()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion



    }// fin de la clase

}// fin del namespace
