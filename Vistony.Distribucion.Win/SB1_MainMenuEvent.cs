//#define AD_BO
//#define AD_PE
//#define AD_ES
//#define AD_PY
//#define AD_EC
#define AD_CL

using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.Win.UltimaMilla;
using Vistony.Distribucion.Win.Formularios;
using Vistony.Distribucion.Win.Asistentes;
using Vistony.Distribucion.Win.Programacion;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Win.Mantenimiento;

namespace Vistony.Distribucion.Win
{
    public class SB1_MainMenuEvent
    {

        static SAPbouiCOM.Form oForm;
        private string menuCaption = string.Empty;
        private SAPbouiCOM.Form activeForm = null;
        EntregaBLL entregaBLL = new EntregaBLL();


        /// <summary>
        /// Capturo los eventos del Menu del AddOn Iker One

        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_MainMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction)
                {
                    switch (pVal.MenuUID)
                    {
                        #region Modulos/Definiciones/Distribución 
                        case AddonMenuItem.dis_Choferes:
                            {
                                 OnShowChoferes();

                            }
                            break;


                        case AddonMenuItem.dis_Ayudantes:
                            {
                                OnShowAyudantes();

                            }
                            break;

                            


                        case AddonMenuItem.dis_ChoferesUbigeo:
                            {
                                OnShowChoferesUbigeo(pVal.MenuUID);

                            }
                            break;

                        case AddonMenuItem.dis_Vehiculos:
                            {
                                OnShowVehiculos();

                            }
                            break;



                        case AddonMenuItem.dis_Andenes:
                            {
                               OnShowAndenes();

                            }
                            break;



                        #endregion

                        #region Modulos/DISTRIBUCION 
                        case AddonMenuItem.dis_entrega:
                            {
                                onShowEntrega();
                            }
                            break;
                        case AddonMenuItem.dis_asigna:
                            {
                                onShowAsignaDespacho();
                            }
                            break;
                        case AddonMenuItem.dis_asigna_Manual:
                            {
                                onShowAsignaDespachoManual();
                            }
                            break;

                        case AddonMenuItem.dis_estado:
                            {
                                onShowEstadoDespacho();
                            }
                            break;
                        case AddonMenuItem.dis_wizard:
                            {
                                OnShowWzdProgramacion();
                            }
                            break;

                        case AddonMenuItem.dis_rutTra:
                            {
                                OnShowRutaDespacho();
                            }
                            break;
                        case AddonMenuItem.dis_ActualizarImei:
                            {
                                OnShowActualizarIMEI();
                            }
                            break;
                        case AddonMenuItem.dis_UpdateUbi:
                            {
                                OnShowActualizarUbigeo();
                            }
                            break;
                        case AddonMenuItem.dis_PuntoEmiUsu:
                            {
                                OnShowPuntoEmisionUsuario();
                            }
                            break;
                        case AddonMenuItem.dis_sld:
                            {
                                onShowProgramacionSLD();
                            }
                            break;
                        case AddonMenuItem.dis_CodSld:
                            {
                                onShowProgramacionConsolSLD();
                            }
                            break;
                        case AddonMenuItem.dis_Seguisld:
                            {
                                onShowProgramacionConsolSeguimientoDespachoSLD();
                            }
                            break;
                            
                        #endregion

                        #region Modulos/DISTRIBUCION/UltimaMilla 

                        case AddonMenuItem.dis_seguimiento:
                            {
                                OnShowSeguimiento();
                            }
                            break;
                        case AddonMenuItem.dis_seguimientoSec:
                            {
                                OnShowSeguimientoSectorista();
                            }
                            break;
                        #endregion

#if AD_PE

                        #region Modulos/DISTRIBUCION/InformeDistribucionAncon

                        case AddonMenuItem.dis_Control_Documentario_Diario:
                             {
                                  SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                  entregaBLL.Layout_Preview("Control Documentario Diario", "", oRS);
                              }
                             break;
                        case AddonMenuItem.dis_Hoja_listado_Resumen_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Resumen - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Consolidado_chofer_agencias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Consolidado x chofer agencias - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Alistado_Detalle_Agencia_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Detalle Agencia - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Alistado_Agencia_Provincias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Agencia (Provincias) - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_de_Consolidado_Lima:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen de Consolidado - Lima", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Consolidado_Global_Agencias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Consolidado Global Agencias - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Global_Lima:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado -  Global Lima", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Consolidado_Ubicacion:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Consolidado Ubicacion", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Detalle_Despacho_Choferes_Ultima_Milla:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Detalle Despacho Choferes - Ultima Milla", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Despacho_Choferes_Ultima_Milla:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Despacho Choferes - Ultima Milla", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Carga_de_Agencia:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Carga de Agencia", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Control_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Control de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Carga_Ruta_Ubigeo:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Carga - Ruta Ubigeo - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Solicitud_de_devolución_artículo:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Solicitud de devolución (artículo)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Alistado_Provincias:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Alistado Provincias", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Cilindros_local:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Cilindros - local", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_Chofer_Blu_Vis:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia Electronica Chofer (Blu/Vis)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Evaluacion_de_rentabilidad_de_reparto:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Evaluacion de rentabilidad de reparto", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_Chofer_Fecha_Blu_Vis:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia Electronica Chofer Fecha (Blu/Vis)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Agencia_Global:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado Agencia Global", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Ruta_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Ruta de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Detalle_Seguimiento_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Detalle Seguimiento de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guía_Electronica_por_Fecha_V3:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guía Electronica por Fecha V3", "", oRS);
                            }
                            break;
                        #endregion

                        #region Modulos/DISTRIBUCION/InformeDistribucionSucursales
                            case AddonMenuItem.dis_Control_Documentario_Diario2:
                                {
                                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                    entregaBLL.Layout_Preview("Control Documentario Diario", "", oRS);
                                }
                                break;
                        case AddonMenuItem.dis_Control_de_Despacho2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Control de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_Alistado_Chofer_Almacen2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja Alistado - Chofer Almacen", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Almacenes2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado - Almacenes", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_SerieAG2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia_Electronica SerieAG", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guía_Electronica_por_Fecha_V32:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guía Electronica por Fecha V3", "", oRS);
                            }
                            break;
                        #endregion
#elif AD_PY

                        #region Modulos/DISTRIBUCION/InformeDistribucionAncon

                        case AddonMenuItem.dis_Control_Documentario_Diario:
                             {
                                  SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                  entregaBLL.Layout_Preview("Control Documentario Diario", "", oRS);
                              }
                             break;
                        case AddonMenuItem.dis_Hoja_listado_Resumen_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Resumen - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Consolidado_chofer_agencias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Consolidado x chofer agencias - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Alistado_Detalle_Agencia_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Detalle Agencia - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Alistado_Agencia_Provincias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Alistado Agencia (Provincias) - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_de_Consolidado_Lima:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen de Consolidado - Lima", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_de_Consolidado_Global_Agencias_Ancon:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja de Consolidado Global Agencias - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Global_Lima:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado -  Global Lima", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Consolidado_Ubicacion:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Consolidado Ubicacion", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Detalle_Despacho_Choferes_Ultima_Milla:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Detalle Despacho Choferes - Ultima Milla", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Despacho_Choferes_Ultima_Milla:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Despacho Choferes - Ultima Milla", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Carga_de_Agencia:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Carga de Agencia", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Control_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Control de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Carga_Ruta_Ubigeo:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Carga - Ruta Ubigeo - Ancon", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Solicitud_de_devolución_artículo:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Solicitud de devolución (artículo)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Alistado_Provincias:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Alistado Provincias", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Cilindros_local:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Cilindros - local", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_Chofer_Blu_Vis:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia Electronica Chofer (Blu/Vis)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Evaluacion_de_rentabilidad_de_reparto:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Evaluacion de rentabilidad de reparto", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_Chofer_Fecha_Blu_Vis:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia Electronica Chofer Fecha (Blu/Vis)", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Agencia_Global:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado Agencia Global", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Ruta_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Ruta de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Detalle_Seguimiento_de_Despacho:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Detalle Seguimiento de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guía_Electronica_por_Fecha_V3:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guía Electronica por Fecha V3", "", oRS);
                            }
                            break;
                        #endregion

                        #region Modulos/DISTRIBUCION/InformeDistribucionSucursales
                            case AddonMenuItem.dis_Control_Documentario_Diario2:
                                {
                                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                    entregaBLL.Layout_Preview("Control Documentario Diario", "", oRS);
                                }
                                break;
                        case AddonMenuItem.dis_Control_de_Despacho2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Control de Despacho", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Hoja_Alistado_Chofer_Almacen2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Hoja Alistado - Chofer Almacen", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Resumen_Consolidado_Almacenes2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Resumen Consolidado - Almacenes", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guia_Electronica_SerieAG2:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guia_Electronica SerieAG", "", oRS);
                            }
                            break;
                        case AddonMenuItem.dis_Guía_Electronica_por_Fecha_V32:
                            {
                                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                                entregaBLL.Layout_Preview("Guía Electronica por Fecha V3", "", oRS);
                            }
                            break;
                        #endregion

#endif
                        default:
                            break;

                    } // fin dl switch

                }// fin del IF


            }

            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }/// fin del  metodo

        private void onShowProgramacionConsolSeguimientoDespachoSLD()
        {
            try
            {
                frmDispatchTruckingSLD form = new frmDispatchTruckingSLD();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void onShowProgramacionConsolSLD()
        {
            try
            {
                frmConsolidationSLD form = new frmConsolidationSLD();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void onShowProgramacionSLD()
        {
            try
            {
                frmProgrammingSLD form = new frmProgrammingSLD();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void OnShowPuntoEmisionUsuario()
        {
            try
            {
              FrmPuntoEmisionUsuario form  = new FrmPuntoEmisionUsuario();
                form.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        // integración de SelesForce con SAP
        private void OnShowInicializar()
        {
            try
            {
                //frmInicializar form  = new  frmInicializar();
                //form.Show();
            }
            catch (Exception ex)
            {
                
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowConfigForm(string tableName)
        {
          
            SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.Matrix oMatrix = null;
            //SAPbouiCOM.MenuItem oMenuItem = null;
            //SAPbouiCOM.Menus oMenu = null;
            string menuID = string.Empty;
            string menuCaption = string.Empty;
            int index = 0;

            try
            {


                //obtiene el ID del menu que encontra a traves del nombre de la tablas
                menuID = Forxap.Framework.UI.Menu.GetMenuID(tableName, SboMenuItem.WindowsDefinedUser);

                
                Application.SBO_Application.ActivateMenuItem(menuID);

                menuCaption = Application.SBO_Application.Menus.Item(menuID).String;




                index = menuCaption.IndexOf("-", 0);



                activeForm = Application.SBO_Application.Forms.ActiveForm;
                activeForm.Freeze(true);

                activeForm.Title = menuCaption.Substring(index + 2);

                // SAPbouiCOM.Item oItem = null;
                // SAPbouiCOM.StaticText lblInfo = null;



                oButton = activeForm.GetButton("2");
                oMatrix = activeForm.GetMatrix("3");

                oMatrix.Columns.Item(3).TitleObject.Caption = "Código";
                oMatrix.Columns.Item(4).TitleObject.Caption = "Descripción";


                //    oMatrix.CommonSetting.MergeCell(1,3,true); 


                //oItem = activeForm.Items.Add("lblInfo1", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                //oItem.Left = oButton.Item.Left + 75;
                //oItem.Width = oMatrix.Item.Width;
                //oItem.Top = oButton.Item.Top - oButton.Item.Height;
                //oItem.Height = oButton.Item.Height;
                //oItem.Enabled = true;
                //lblInfo = ((SAPbouiCOM.StaticText)(oItem.Specific));
                //lblInfo.Caption = "Height : " + oItem.Height.ToString() + "Top : " +  oItem.Top.ToString();



                activeForm.Freeze(false);





            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {

                // libero recursos

                if (activeForm != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(activeForm);
                    activeForm = null;
                    GC.Collect();
                }

                if (oMatrix != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oMatrix);
                    oMatrix = null;
                    GC.Collect();
                }

            }

        }
        private void onShowEntrega()
        {
            try
            {

               frmConsolidation form = new frmConsolidation();
               form.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowWzdProgramacion()
        {
            try
            {

                wzdProgramacion   wizard = new wzdProgramacion();
                wizard.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void onShowAsignaDespacho()
        {
            try
            {
                frmPrograming wizard = new frmPrograming();
                wizard.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void onShowAsignaDespachoManual()
        {
            try
            {
                frmProgrammingHandbook wizard = new frmProgrammingHandbook();
                wizard.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void onShowEstadoDespacho()
        {
            try
            {
                frmEstadoDespachos wizard = new frmEstadoDespachos();
                wizard.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowSeguimiento()
        {
            try
            {

                frmDispatchTrucking  form = new frmDispatchTrucking();
                form.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowSeguimientoSectorista()
        {
            try
            {

                frmDispatchTruckingVentas form = new frmDispatchTruckingVentas();
                form.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowActualizarUbigeo()
        {
            try
            {

                frmUpdateUbigeo form = new frmUpdateUbigeo();
                form.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowChoferes()
        {
            try
            {
                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "CONDUC", string.Empty);
                

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void OnShowAyudantes()
        {
            try
            {
                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "OAYD", string.Empty);


            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowActualizarIMEI()
        {
            try
            {
                // Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "VIS_DIS_ODRT", string.Empty);

                Mantenimiento.FrmActualizarIMEI form = new Mantenimiento.FrmActualizarIMEI();
                form.Show();
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowRutaDespacho()
        {
            try
            {
                // Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "VIS_DIS_ODRT", string.Empty);

                FrmDispatchRoute form = new FrmDispatchRoute();
                form.Show();
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowAndenes()
        {
            SAPbouiCOM.Matrix oMatrix = null;
            try
            {


                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "OAND", string.Empty);


                activeForm = Application.SBO_Application.Forms.ActiveForm;

                activeForm.Freeze(true);
                oMatrix = activeForm.GetMatrix("3");

                oMatrix.Columns.Item(3).TitleObject.Caption = "Código x";
                oMatrix.Columns.Item(4).TitleObject.Caption = "Descripción x";
                oMatrix.Columns.Item(5).TitleObject.Caption = "Sucursal x";

                //        oColumn = (SAPbouiCOM.Column)oMatrix.Columns.Item("4");

                //  oCombobox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(5);
                //  oCombobox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(5).Cells.Item(oMatrix.VisualRowCount).Specific;

                //  _cmbExpDate = (SAPbouiCOM.ComboBox)oIMatrix.Columns.Item("iV_15")
                //  oColumn.Type = SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX;

                activeForm.Freeze(false);

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void OnShowChoferesUbigeo(string menuID)
        {
            try
            {
          

                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "VIST_UBIGEOCHOFER", string.Empty);

                
                Application.SBO_Application.Forms.ActiveForm.Title = Application.SBO_Application.Menus.Item(menuID).String;
                Application.SBO_Application.Forms.ActiveForm.GetMatrix("3").Columns.Item(3).TitleObject.Caption = "Código";

  
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        

        private void OnShowVehiculos()
        {
            try
            {
                Application.SBO_Application.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "VEHICU", string.Empty);


            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        private void OnShowAsisAnulaDoc()
        {
            try
            {
                //wzdAnulacion wzd = new wzdAnulacion();

                //wzdConciliar wzd = new wzdConciliar();
          //      wzd.Show();
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }





    }// fin de la clase


}// fin del namespace
