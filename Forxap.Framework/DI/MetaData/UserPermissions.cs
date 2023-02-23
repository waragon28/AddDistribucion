using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SAPbouiCOM;
using Forxap.Framework.Utils;


namespace Forxap.Framework.DI
{
    public class Sb1UserPermissions : Base, IDisposable
    {

        public  Sb1Error CreatePermission(string permissionId, string permissionName, BoUPTOptions options, string parentID, List<string> formType, int level )
        {
      
            int retCode = 0;
            string ErrorMsg = string.Empty;
            SAPbobsCOM.UserPermissionTree oUserPermission = null;

         
            
            Sb1Error sb1Error = null;

            try
            {
                oUserPermission = (SAPbobsCOM.UserPermissionTree)(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserPermissionTree));


                if (!oUserPermission.GetByKey(permissionId))

                {
                    oUserPermission.PermissionID = permissionId;
                    oUserPermission.Name = permissionName;
                    oUserPermission.Options =  options;

                    if (level > 1)
                    {
                        oUserPermission.ParentID = parentID;
                    }

                    if (formType != null)
                    {
                        foreach (var form in formType)
                        {
                            oUserPermission.UserPermissionForms.FormType = form;
                            oUserPermission.UserPermissionForms.Add();
                        }

                    }


                    retCode = oUserPermission.Add();


                    
                    if (retCode != 0)
                    {

                        sb1Error = Utils.Errors.GetLastErrorMessage(oCompany);
                    }

                    else if (retCode == -1)
                    {
                        //quiere decir que no hubo ningun error debe delvolver error 0
                        sb1Error = new Sb1Error(oCompany.CompanyName, retCode = 0, string.Format("{0}: {1} {2}", "Permiso ", permissionName, ", se creo con exito"));

                    }



                }

                else
                {
                    sb1Error = new Sb1Error(oCompany.CompanyName, retCode = 0, string.Format("{0}: {1} {2}", "Objeto ", permissionName, ", ya existe"));
                }

                
            }
            catch (Exception ex)
            {
                // verificar que este mensaje salga solo si lo invocaron desde sap b1
                Forxap.Framework.UI.Sb1Messages.ShowError(string.Format("Error : {1}", ex.Message.ToString()));

            }

            finally
            {
                if (oUserPermission != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oUserPermission);
            }

            return sb1Error;
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
        ~Sb1UserPermissions()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase
}
