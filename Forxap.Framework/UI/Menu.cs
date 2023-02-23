using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;
using Forxap.Framework.Constants;
using SAPbouiCOM;

namespace Forxap.Framework.UI
{
    public class Menu : Base, IDisposable
    {

        public static string GetMenuID(string tableName)
        {
            string ret = string.Empty;

//            Application.SBO_Application.OpenForm
//            Application.SBO_Application.OpenForm

            return ret;
        }

        /// <summary>
        /// Obtiene el MenuID de una tabla especifica dentro de un Menu de SAP
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fatherMenu"></param>
        /// <returns></returns>
        public static string GetMenuID(string tableName,string fatherMenu)
        {
            string menuId = string.Empty;
            SAPbouiCOM.MenuItem menusFather;
            SAPbouiCOM.Menus  subMenus;
            menusFather = oApplication.Menus.Item(fatherMenu);
            subMenus =  menusFather.SubMenus;



            foreach (SAPbouiCOM.MenuItem menuItem in subMenus)
	            {
                    if (menuItem.String.Contains(tableName))
                    {
                        menuId =  menuItem.UID;

                        
                        break;
                    }
	            }



            return menuId;

        }

        public static string GetMenuCaption(string objectName, string fatherMenu)
        {
            string menuId = string.Empty;
            SAPbouiCOM.MenuItem menusFather;
            SAPbouiCOM.Menus subMenus;
            menusFather = oApplication.Menus.Item(fatherMenu);
            subMenus = menusFather.SubMenus;



            foreach (SAPbouiCOM.MenuItem menuItem in subMenus)
            {
                if (menuItem.String.Contains(objectName))
                {
                    menuId = menuItem.String;


                    break;
                }
            }



            return menuId;

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
        ~Menu()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion



    }// fin de la clase


}// fin del namespace
