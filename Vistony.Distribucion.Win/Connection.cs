//#define AD_EC
//#define AD_BO
//#define AD_CL
//#define AD_PY
#define AD_PE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

using SAPbouiCOM.Framework;
using Forxap.Framework;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;
using System.Globalization;

namespace Vistony.Distribucion.Win
{
    public class Sb1Connection
    {
        /// <summary>
        /// Conecta el AddOn a la instancia de SAP que se encuentra cargada (desarrollo) o en la instancia
        /// que lo invoca en Producción.
        /// </summary>
        /// <returns></returns>
        public static bool ConnectToSAP()
        {
   
            bool ret = true;
           

            try
            {
                AddonMessageInfo addonMessageInfo = new AddonMessageInfo();


                Sb1Globals.oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
                Sb1Globals.oCompanyService = Sb1Globals.oCompany.GetCompanyService();
                Sb1Globals.DbServerType = Sb1Globals.oCompany.DbServerType.ToString();
                Sb1Globals.Path = System.Windows.Forms.Application.StartupPath;
                SAPbouiCOM.BoLanguages lenguaje = Application.SBO_Application.Language;
                Sb1Initialize.SetFramework(Application.SBO_Application, Sb1Globals.oCompany);//inicializa el framework.
                Vistony.Distribucion.DAL.BaseDAL.SetDataAccesLayer(Application.SBO_Application, Sb1Globals.oCompany);//inicializa el DAL
                Forxap.Framework.ServiceLayer.Sb1Initialize.SetFramework(Application.SBO_Application, Sb1Globals.oCompany);
                
                Sb1Globals.UserSignature = Sb1Globals.oCompany.UserSignature;// obtiene el codigo del usuario logeado
                Sb1Globals.UserName = Sb1Globals.oCompany.UserName; // Nombre  del usuario logeado
                Sb1Globals.Sucursal = Utils.GetSucursal(Sb1Globals.UserName);
                Sb1Globals.Departamento = Utils.GetDepartamento(Sb1Globals.UserName);
                Sb1Globals.CompanyName = Sb1Globals.oCompany.CompanyName; // Nombre de la compañia a la que esta logeado

#if AD_EC
                Sb1MetaData.AddUserProcedure();//CREAR PROCEDIMIENTOS ALMACENADOS
#endif

                if (Sb1Globals.Idioma == "")
                {
                    Sb1Globals.Idioma = Utils.GetIdiomaSAP(Sb1Globals.UserName);
                }

                #region Creación del Menu, Iconos, Tablas, Campos, UDOs,Permisos, Scripts

                if (Sb1Globals.Idioma == "English (United States)")
                {
                    Sb1MetaData.AddMenusEnglisUnitedStates(); // agrega el menu del addon
                }
                else if (Sb1Globals.Idioma == "French")
                {
                    Sb1MetaData.AddMenusFrench(); // agrega el menu del addon
                }
                else
                {
#if AD_PE
                        if (Sb1Globals.CompanyName == "VISTONY COMPAÑIA INDUSTRIAL DEL PERU S.A.C.")
                            {
                                Sb1MetaData.AddMenusEspanolPeru(); // agrega el menu del addon
                                Sb1Globals.AdminPuntoEmision = Utils.GetMultiSucursal(string.Format(addonMessageInfo.QueryGetListAdminSucu, Sb1Globals.UserSignature)); // Consulta Usuario Multi Sucursal
                                Sb1Globals.SucursalDefault = Utils.GetSucursalDefault(string.Format(addonMessageInfo.QueryComboBoxSucursalesDefault, Sb1Globals.UserSignature));
                                Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, Sb1Globals.SucursalDefault));
                    }
                            else
                            {
                                Sb1MetaData.AddMenusEspanol(); // agrega el menu del addon
                            }
#elif AD_CL
                    Sb1MetaData.AddMenusChile();
#else

#endif

                    Sb1Globals.cultura.NumberFormat.NumberDecimalSeparator = Utils.GetNumberDecimalSeparator(addonMessageInfo.QueryObtenerDecimalSeparator);
                    Sb1Globals.cultura.NumberFormat.NumberGroupSeparator = Utils.GetNumberMilesSeparator(addonMessageInfo.QueryObtenerMilesSeparator);

                    Sb1Messages.ShowSuccess(string.Format(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma)), SAPbouiCOM.BoMessageTime.bmt_Short);

                    Sb1MetaData.AddIcon();


                    #endregion
                    
                }
                Sb1Messages.ShowSuccess(string.Format(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma)), SAPbouiCOM.BoMessageTime.bmt_Short);

                ret = true;

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.Message);
            }
            
            return ret;

        }// fin del metodo connectToSAP
        
    }// fin de la clase

}// fin del namespace
