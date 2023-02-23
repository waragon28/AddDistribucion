using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework.Constants
{
    public class Sb1Table
    {
        #region Empleados
        
        
        public const string Empleado = "OHEM";

        /// <summary>
        /// Ausentismo
        /// </summary>
        public const string Ausentismo = "HEM1";

        /// <summary>
        ///  estudios realizados
        /// </summary>
        public const string Formacion = "HEM2";


        public const string Valoracion = "HEM3";

        /// <summary>
        /// trabajos anteriores
        /// </summary>
        public const string EmpleoAnterior = "HEM4";


        /// <summary>
        /// funciones
        /// </summary>
        public const string Funciones = "HEM6";
        
        
        #endregion



        #region Query Manager

        public const string QueryCategory = "OQCN";
        public const string Query = "OUQR";
        

        #endregion

        /// <summary>
        ///  lista de precios
        /// </summary>
        public const string PriceList = "OPLN";

        /// <summary>
        ///  socio de negocio
        /// </summary>
        public const string BusinessPartner = "OCRD";

        /// <summary>
        /// Facturas
        /// </summary>
        public const string Invoice = "OINV";


        public const string Order = "ORDR";

        public const string DeliveryNote = "ODLN";

        public const string DeliveryNotePackage = "DLN7";

        public const string PaymentTerm = "OCTG";

        public const string ShippingType = "OSHP";
    
        /// <summary>
        /// Periodos Financieros
        /// </summary>
        public const string FinancedPeriod = "OFPR";

        /// <summary>

        /// Sales Tax. Non EU Taxes

        /// </summary>

        public const string SalesTax = "OSTC";

        /// <summary>

        /// VAT Group. EU Taxes

        /// </summary>

        public const string VatGroup = "OVTG";

        /// <summary>
        /// Articulos
        /// </summary>
        public const string Item = "OITM";


        /// <summary>
        /// Grupo de Articulos
        /// </summary>
        public const string ItemGroup = "OITB";


        #region ApprovalFlow
        /// <summary>
        /// 
        /// </summary>
        public const string ApprovalTemplate = "OWTM";


        /// <summary>
        /// usuarios que estan asignados a una regla de aprobacion
        /// </summary>
        public const string  ApprovalUsers = "WTM1";

        public const string ApprovalDocuments = "WTM3";
        #endregion
        




        
        public const string FormationType = "OHED";///Clases de formación


        #region Contratos

        public const string CancelationType = "OHTR";///Motivo del fin del periodo TABLA 17 



        
        #endregion


        #region Tablas y Campos definidos por el usuario

        public const string UserTable  = "OUTB";// tablas definidas por el usuario
        public const string UserField  = "CUFD";// campos definidos por el usuario
        public const string UserObject = "OUDO";// objetos definidos por el usuario



        #endregion



        public const string Dashboard = "ODAB"; //


        #region Feriados

        public const string Holiday = "OHLD"; //
        public const string HolidayDate = "HLD1";

        #endregion

    }// fin de la clase

}// fin del namespace
