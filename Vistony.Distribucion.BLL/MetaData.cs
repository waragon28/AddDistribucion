using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forxap.Distribucion.DAL;

namespace Forxap.Distribucion.BLL
{
    public class MetaDataBLL : IDisposable
    {

        /// <summary>
        ///  Creación de Tablas en SAP que se usaran en el modulo
        ///  de Factoring
        /// </summary>
        /// <param name="oCompany"></param>
        public void CreateTable(string fileName)
        {
            using (MetaDataDAL metaDataDAL = new MetaDataDAL())
            {
                metaDataDAL.CreateTables( fileName);
            }
        }

        /// <summary>
        /// Creación de Campos en las Tablas de Usuario usadas en el modulo factoring
        /// </summary>
        /// <param name="fileName"></param>
        public void CreateFields(string  fileName)
        {
            using (MetaDataDAL metaDataDAL = new MetaDataDAL())
            {
                metaDataDAL.CreateFields(fileName);           
                
            }

        }

        public void CreateUdos(string fileName)
        {
            using(MetaDataDAL metaDataDAL = new MetaDataDAL())
            {
                metaDataDAL.CreateUdos(fileName);
            }

        }

        public void CreatePermissionss(string fileName)
        {
            using (MetaDataDAL metaDataDAL = new MetaDataDAL())
            {
                metaDataDAL.CreatePermissions(fileName);
            }

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
        ~MetaDataBLL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }
}
