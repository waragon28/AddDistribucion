using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.Distribucion.BO;
using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.BLL
{
    public class EntregaBLL : IDisposable
    {
        public void Consolidados(SAPbouiCOM.Form oForm,SAPbouiCOM.Matrix oMatrix, string Sucural)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    entregaDAL.Consolidados(oForm, oMatrix, Sucural);
                }
            }
            catch (Exception)
            {

                //
            }
        }
        public double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.CalcularDistancia(lat1, lon1, lat2,lon2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public SAPbouiCOM.DataTable GetInfoUsuario(string USUARIO, SAPbouiCOM.DataTable oDT)
        {
            try
            {
                using (EntregaDAL entregaDAL= new EntregaDAL())
                {
                   return entregaDAL.GetInfoUsuario(USUARIO, oDT);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public void BuscarChoferesUbigeo(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string Sucural)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                     entregaDAL.BuscarChoferesUbigeo(oForm,oMatrix , Sucural);
                }
            }
            catch (Exception)
            {

               // return null;
            }
        }
        public SAPbouiCOM.DataTable GetEmplIMEI(string IMEI,SAPbouiCOM.DataTable oDT)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                   return entregaDAL.GetEmplIMEI(IMEI, oDT);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool ValidarIMEI(string IMEI, Recordset recordset, EditText ID_Empleado, EditText Nombre_OHEM)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.ValidarIMEI( IMEI, recordset, ID_Empleado, Nombre_OHEM);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateIMEI(int? EmployeeID, dynamic jsonData, ref string response)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                   return entregaDAL.UpdateIMEI(EmployeeID, jsonData,ref response);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Layout_Preview(string ReportName, string DocNum, Recordset oRS)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                   entregaDAL.Layout_Preview(ReportName, DocNum, oRS);
                }

            }
            catch (Exception ex)
            {
                
            }
        }

        public SAPbouiCOM.DataTable GetEntrega(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string userName)
        {
            try
            {
                using (EntregaDAL  entregaDAL = new EntregaDAL()  )
                {
                  return    entregaDAL.Entrega(ref oDT, startDate, endDate, consolidado, agencia, userName);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SAPbouiCOM.DataTable GetSLD(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string AlmacenDesde, string AlmacenHasta, string Query)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.GetSLD(ref oDT, startDate, endDate, AlmacenDesde, AlmacenHasta,Query);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SAPbouiCOM.DataTable GetConsolidadoSLD(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string AlmacenDesde, string AlmacenHasta, string Query,string Consolidado, string Agencia)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.GetConsolidadoSLD(ref oDT, startDate, endDate, AlmacenDesde, AlmacenHasta, Query, Consolidado, Agencia);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public SAPbouiCOM.DataTable GetEntrega_Sucursal(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string Sucursal)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.Entrega_Sucursal(ref oDT, startDate, endDate, consolidado, agencia, Sucursal);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C_TEST(ref SAPbouiCOM.DataTable oDT, string fecha,
            string TRACKER, string Sucursal,string TipoRuta)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_C_TEST(ref oDT, fecha,TRACKER,Sucursal, TipoRuta);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C(ref SAPbouiCOM.DataTable oDT, string fecha)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL() )
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_C(ref oDT, fecha);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_D(ref SAPbouiCOM.DataTable oDT,string Fecha, int HORA_INI, int HORA_FIN, string CodChofer,string CodVehiculo)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_D(ref oDT, Fecha, HORA_INI, HORA_FIN, CodChofer, CodVehiculo);
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_VENTAS(ref SAPbouiCOM.DataTable oDT, string Fecha, int HORA_INI, int HORA_FIN, string CodVendedor)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_VENTAS(ref oDT, Fecha, HORA_INI, HORA_FIN, CodVendedor);
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_C_VENTAS(ref SAPbouiCOM.DataTable oDT, string Fecha, int HORA_INI, int HORA_FIN, string departamento)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_C_VENTAS(ref oDT, Fecha, HORA_INI, HORA_FIN, departamento);
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SAPbouiCOM.DataTable SP_VIS_DIS_GET_TRACKER_D_VENTAS(ref SAPbouiCOM.DataTable oDT, string fecha, int HORA_INI, int HORA_FIN, string CodVendedor, string Dept)
        {
            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    return entregaDAL.SP_VIS_DIS_GET_TRACKER_D_VENTAS(ref oDT, fecha, HORA_INI, HORA_FIN, CodVendedor, Dept);
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool UpdateEstadoEntrega(int? docEntry, dynamic jsonData, ref  string  response )
        {

            bool ret = false;

            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    ret = entregaDAL.UpdateEstadoEntrega(docEntry,jsonData, ref response);
                }

            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }

          
           
                return ret;
          
        }
        public bool UpdateEstadoSLD(int? docEntry, dynamic jsonData, ref string response)
        {

            bool ret = false;

            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    ret = entregaDAL.UpdateEstadoSLD(docEntry, jsonData, ref response);
                }

            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }



            return ret;

        }
        public  SAPbouiCOM.DataTable ListPrevDespacho( string startDate, string endDate, string usuario, string chofer, string agencia, ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
               return  entregaDAL.ListPrevDespacho( startDate, endDate, usuario, chofer,agencia, ref oDT);
            } 
        }
        public SAPbouiCOM.DataTable ListPrevDespacho_Sucursal(string startDate, string endDate, string Sucursal, string chofer, string agencia, ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ListPrevDespacho_Sucursal(startDate, endDate, Sucursal, chofer, agencia, ref oDT);
            }

        }
        public SAPbouiCOM.DataTable ListPrevDespachoManual(string startDate, string endDate, string usuario, string chofer,string Agencia,ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ListPrevDespachoManual(startDate, endDate, usuario, chofer, Agencia, ref oDT);
            }
        }
        public SAPbouiCOM.DataTable ListPrevDespachoEdit(string startDate, string endDate, string usuario, string chofer, ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ListPrevDespachoEdit(ref oDT, startDate, endDate, usuario, chofer );
            }
            
        }
        public  string ObtenerSucursal(SAPbouiCOM.DataTable oDT, string usuario)
        {

            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ObtenerSucursal(oDT, usuario);
            }
        }
        public string ObtenerSucursal(string usuario)
        {

            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ObtenerSucursal( usuario);
            }
        }
        public string ObtenerDepartamento(string usuario)
        {

            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ObtenerDepartamento(usuario);
            }
        }
        
        public void GetDatosChofer(ref string choferCode, ref string choferName, ref string choferLicencia, ref string vehiculoPlaca, ref string vehiculoMarca, ref string ayudanteCode, ref string ayudanteName, ref double pesoUtil)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                 entregaDAL.GetDatosChofer( ref choferCode,ref choferName, ref choferLicencia, ref vehiculoPlaca,ref vehiculoMarca, ref ayudanteCode, ref ayudanteName, ref pesoUtil );
            }
        }

        public string ObtenerCorrelativoDespacho(SAPbouiCOM.DataTable oDT, string fecha)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ObtenerCorrelativoDespacho(oDT, fecha);
            }


        }

        public void GenerarRutaTransportista(Grid Grid0, EditText U_DriverCode, EditText U_DriverName, EditText U_VehiculeCode, EditText U_VehicleCapacity,
                                               EditText U_CountDocuments, EditText U_DocumentsCapacity, EditText U_AssistantCode, EditText U_AssistantName)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                entregaDAL.GenerarRutaTransportista(Grid0, U_DriverCode, U_DriverName, U_VehiculeCode, U_VehicleCapacity,
                                            U_CountDocuments, U_DocumentsCapacity, U_AssistantCode, U_AssistantName);
            }
        }
        
        public void GetDataTableResumen(ref SAPbouiCOM.DataTable oDatatable, int rows)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                entregaDAL.GetDataTableResumen(ref oDatatable, rows);
            }

        }


        public Programacion ObtenerCabeceraDocuemtProgramacion(SAPbouiCOM.Grid dt, string docDate, string driverCode,
        string driverName,string assistantCode,string assistantName,string vehiculeCode,string vehiculeName, double? vehiculeapacity, double? documentsWeight,
        string successQuantity,string failedQuantity,string documentsQuantity,string TipoRuta)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
               return entregaDAL.ObtenerRutaTransportista(dt, docDate,driverCode,driverName,  assistantCode,  assistantName, vehiculeCode,  vehiculeName, vehiculeapacity, documentsWeight,
                         successQuantity,  failedQuantity, documentsQuantity,TipoRuta);
            }
        }

        public string  GuardarHojaDespacho(SAPbouiCOM.Grid dt, string docDate, string driverCode,string driverName, string assistantCode,
            string assistantName, string vehiculeCode, string vehiculeName,double? vehiculeCapacity, double? documentsWeight,  
            string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
              return  entregaDAL.GuardarProgramacion(dt, docDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName, vehiculeCapacity,
                  documentsWeight, successQuantity, failedQuantity, documentsQuantity, TipoRuta);
            }
        }

        public string GuardarHojaDespachoSLD(SAPbouiCOM.Grid dt, string docDate, string driverCode, string driverName, string assistantCode,
    string assistantName, string vehiculeCode, string vehiculeName, double? vehiculeCapacity, double? documentsWeight,
    string successQuantity, string failedQuantity, string documentsQuantity,string TipoRuta)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.GuardarProgramacionSLD(dt, docDate, driverCode, driverName, assistantCode, assistantName, vehiculeCode, vehiculeName, vehiculeCapacity,
                    documentsWeight, successQuantity, failedQuantity, documentsQuantity, TipoRuta);
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
        ~EntregaBLL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase


}// fin del namespace
