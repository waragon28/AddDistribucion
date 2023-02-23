using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Distribucion.DAL
{
    public class MetaDataDAL : IDisposable
    {

        public void CreateTables(string fileName)
        {
            // creo las tablas 


             //using ( Forxap.Framework.DI.UserTables userTables = new Forxap.Framework.DI.UserTables())
             //   {

             //       Forxap.Framework.DI.UserFields userFields = new Forxap.Framework.DI.UserFields();
             //       Forxap.Framework.DI.UserObjects userObjects = new Forxap.Framework.DI.UserObjects();

    
             //       /// Cargo las tablas a crear
             //       Forxap.Framework.Utils.XmlFile.LoadUserTablesFromXmlFile(fileName);

             //   }


             //using (Forxap.Framework.DI.UserObjects userObject = new Forxap.Framework.DI.UserObjects())
             //   {
             //       //  userObject.CreateUDO(oCompany, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoYesNoEnum.tYES, SAPbobsCOM.BoYesNoEnum.tNO, "MIX_FAC1", "MIXO1", "OFAC", SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoUDOObjType.boud_Document, "MIX_OFAC");
             //   }

        }


        public void CreateFields( string fileName)
        {
            //Forxap.Framework.Utils.XmlFile.LoadUserFieldsFromXmlFile(fileName);
        }



        public void CreateUdos (string fileName)
        {
            //Forxap.Framework.Utils.XmlFile.LoadUserObjectFromXmlFile(fileName);
        }

        public void CreatePermissions(string fileName)
        {
            //Forxap.Framework.Utils.XmlFile.LoadUserPermissionFromXmlFile(fileName);
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
        ~MetaDataDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }// fin de la clase


}// fin del namespace
