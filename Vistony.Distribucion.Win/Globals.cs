using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.Win
{
    /// <summary>
    /// 
    /// </summary>
    public class Sb1Globals
    {
        /// <summary>
        /// 
        /// </summary>
        public static SAPbobsCOM.Company oCompany;


        /// <summary>
        /// 
        /// </summary>
        public static SAPbobsCOM.CompanyService oCompanyService;

        /// <summary>
        /// 
        /// </summary>
        public static string DbServerType;


        public static string Path;
        
        /// <summary>
        /// 
        /// </summary>
        public static string CompanyName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public static string CompanyDB;

        /// <summary>
        /// 
        /// </summary>
        public static string Autorizacion = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public static SAPbouiCOM.Form oForm = null;

        /// <summary>
        /// 
        /// </summary>
        public static int UserSignature = 0;

        /// <summary>
        /// 
        /// </summary>
        public static string UserName = string.Empty;
        public static string Departamento = string.Empty;

        public static string Sucursal = string.Empty;
        public static string IDSucursal = string.Empty;
        public static string Idioma = string.Empty;
        public static string AdminPuntoEmision = string.Empty;
        public static string SucursalDefault = string.Empty;

    }// fin de la clase

}// fin del namespace
