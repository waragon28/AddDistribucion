//#define AD_BO
//#define AD_PE
//#define AD_ES
//#define AD_PY
#define AD_EC

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;

using Newtonsoft.Json;
using RestSharp;
using Vistony.Distribucion.DAL;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Data;
using System.ComponentModel;
using Vistony.Distribucion.Win.Formularios;
using Vistony.Distribucion.Win.Asistentes;

using Vistony.Distribucion.BO;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;


namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("frmEstadosDespachos", "UltimaMilla/frmEstadoDespachos.b1f")]
    public class frmEstadoDespachos  : BaseWizard
    {
        public int filaseleccionada = -1;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText3;

        public frmEstadoDespachos()
        {
            string sucursal = string.Empty;
            EditText0.Value = DateTime.Now.ToString("yyyyMMdd");
            Utils.LoadQueryDynamic(ref ComboBox0,AddonMessageInfo.QueryStatusDelivery);
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");

            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                sucursal = entregaBLL.ObtenerSucursal(oDT, Sb1Globals.UserName);
            }


            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = "U_VIS_BranchCode";
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = sucursal;
            cfl.SetConditions(cons);

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText0_ClickAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText1_ChooseFromListAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText2_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_7").Specific));
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText4.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText4_LostFocusAfter);
            this.EditText4.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText4_KeyDownAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_11").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_13").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_14").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.EditText5.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText5_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_16").Specific));
            this.LinkedButton0.ClickAfter += new SAPbouiCOM._ILinkedButtonEvents_ClickAfterEventHandler(this.LinkedButton0_ClickAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.EditText3.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText3_ClickAfter);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button4_ClickAfter);
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("Item_22").Specific));
            this.Button5.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button5_ChooseFromListAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_24").Specific));
            this.ComboBox1.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox1_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();

#if AD_PE
            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                StaticText6.Item.Visible = true;
                ComboBox1.Item.Visible = true;
                ComboBox1.Item.DisplayDesc = true;
                Utils.LoadQuerySucursales(ref ComboBox1, string.Format(addonMessageInfo.QueryComboBoxSucursales, Sb1Globals.UserSignature));

                ComboBox1.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
                Sucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));
            }
            else
            {
                StaticText6.Item.Visible = false;
                ComboBox1.Item.Visible = false;
            }
#else
            StaticText6.Item.Visible = false;
            ComboBox1.Item.Visible = false;
#endif



        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            oForm.Close();
        }

        private void EditText1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void EditText2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText5_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string fecha = EditText0.Value;
                string Chofer = EditText1.Value;
                string Licencia = EditText5.Value;
                string Estado = ComboBox0.GetSelectedValue();

                if (string.IsNullOrEmpty(fecha) )
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage302(Sb1Globals.Idioma));
                    EditText0.SetFocus();
                    return;
                }

                if (string.IsNullOrEmpty(Licencia) )
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage303(Sb1Globals.Idioma));
                    EditText1.SetFocus();
                    return;
                }
                oForm.Freeze(true);
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaStartLoading(Sb1Globals.Idioma));
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                oDT.Clear();

#if AD_PE
                if (Sb1Globals.AdminPuntoEmision == "1")
                {
                    oDT.CopyFrom(EntregaDAL.BuscarDespachos_Sucursal(oDT, Sucursal, Licencia, fecha, Estado));
                }
                else
                {
                    oDT.CopyFrom(EntregaDAL.BuscarDespachos(oDT, Sb1Globals.UserName, Licencia, fecha, Estado));
                }
#else
                oDT.CopyFrom(EntregaDAL.BuscarDespachos(oDT, Sb1Globals.UserName, Licencia, fecha, Estado));
#endif
                EditText7.SetInt(oDT.Rows.Count);
                FormatoGrilla();
                Grid0.Columns.Item("Marcar").Editable = true;
                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
            }
        }

        void FormatoGrilla()
        {
            Grid0.AssignLineNro();
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item("DocEntry").Visible = false;
            Grid0.Columns.Item("U_DocEntryRef").Visible = false;
            Grid0.Columns.Item("CORRDESPACHO").Visible = false;
            Grid0.Columns.Item("ORDENITEM").Visible = false;
            Grid0.Columns.Item("LineId").Visible = false;
            Grid0.Columns.Item("DocEntryCabecera").Visible = false;
            
            Grid0.Columns.Item("Marcar").Editable = true;
            Grid0.Columns.Item("N° Entrega").Editable = false;
            Grid0.Columns.Item("N° Guía Entrega").Editable = false;
            Grid0.Columns.Item("Código SN").Editable = false;
            Grid0.Columns.Item("Nombre SN").Editable = false;
            Grid0.Columns.Item("Estado").Editable = false;
            Grid0.Columns.Item("Ocurrencia").Editable = false;
            Grid0.Columns.Item("Código Chofer").Editable = false;
            Grid0.Columns.Item("Chofer").Editable = false;
            Grid0.Columns.Item("N° Referencia").Editable = false;


            Grid0.Columns.Item("ORDENITEM").Visible = false;

            Grid0.Columns.Item("N° Entrega").LinkedObjectType(Grid0, "N° Entrega", "15");
            Grid0.Columns.Item("Código SN").LinkedObjectType(Grid0, "Código SN", "2");
            Grid0.Columns.Item("N° Referencia").LinkedObjectType(Grid0, "N° Referencia", "13");
            Grid0.Columns.Item("Chofer").LinkedObjectType(Grid0, "Chofer", "CONDUC");
            Grid0.Columns.Item("Código Chofer").LinkedObjectType(Grid0, "Código Chofer", "CONDUC");

            Grid0.ReadOnlyColumns();
            Grid0.AutoResizeColumns();


        }

        private EstadoDespacho AsignaObjetoDespacho(string estado, string ocurrencia)
        {
            EstadoDespacho obj = new EstadoDespacho();
            obj.U_SYP_DT_ESTDES = estado;
            obj.U_SYP_DT_OCUR = ocurrencia;
            return obj;
        }

        private RutaTransportista1EstadoCabecera ActualizarEstadoObjetoDespachoCabecera(string DocEntry,string LineId, string U_Delivered, string U_ReturnReason)
        {
            RutaTransportista1EstadoCabecera Actualizarobj = new RutaTransportista1EstadoCabecera();
            Actualizarobj.DocEntry = DocEntry;
            Actualizarobj.VIS_DIS_DRT1Collection = ObtenerDetalle(LineId, U_Delivered, U_ReturnReason);
            return Actualizarobj;
        }
        public List<RutaTransportista1Estado> ObtenerDetalle(string LineId, string U_Delivered, string U_ReturnReason)
        {

            List<RutaTransportista1Estado> VIS_TRN_REP_DDocumentDetalls = new List<RutaTransportista1Estado>();

          
                RutaTransportista1Estado DocumentoRutaTransportistaDetalls = new RutaTransportista1Estado();
                DocumentoRutaTransportistaDetalls.LineId = LineId;
                DocumentoRutaTransportistaDetalls.U_Delivered = U_Delivered;
                DocumentoRutaTransportistaDetalls.U_ReturnReason = U_ReturnReason;

                VIS_TRN_REP_DDocumentDetalls.Add(DocumentoRutaTransportistaDetalls);


            return VIS_TRN_REP_DDocumentDetalls;

        }
        
        private EstadoDespachoVolverProgramar AsignaObjetoDespachoSinProgramar(string U_SYP_DT_ESTDES,string U_SYP_DT_OCUR)
        {
            EstadoDespachoVolverProgramar objSinProgramar = new EstadoDespachoVolverProgramar();
            objSinProgramar.U_SYP_DT_ESTDES = U_SYP_DT_ESTDES;
            objSinProgramar.U_SYP_DT_OCUR = U_SYP_DT_OCUR;


            return objSinProgramar;
        }
        private HistoricoDespachos AsignaDatosObject(string docentry, string NumDespacho, string Estado,
                            string OrdenDespacho, string fechaDespacho, string Chofer, string NombreChofer,
                            string Placa, string Ayudante, string Ocurrencias, string Usuario)
        {
            HistoricoDespachos obj = new HistoricoDespachos();
            obj.Code = docentry;
            obj.U_NumLine = NumDespacho;
            obj.U_Status = Estado;
            obj.U_OrderNum = OrdenDespacho;
            obj.U_DateProgram = fechaDespacho;
            obj.U_DriverCode = Chofer;
            obj.U_DriverName = NombreChofer;
            obj.U_VehicleCode = Placa;
            obj.U_Assistent = Ayudante;
            obj.U_Comments = Ocurrencias;
            obj.U_User = Usuario;

            return obj;

        }
        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //Thread mythr = new Thread(AsignarEstados);
            //mythr.Name = "Estado";
            //mythr.Start();
            //mythr.IsBackground = true;
        }

        public void AsignarEstados(string Estado, string Ocurrencia)
        {
            string response = string.Empty;
            bool asigno = false;

            try
            {
                string fecha = EditText0.Value;
                string Chofer = EditText1.Value;
                string NombreChofer = EditText2.Value;
                string Licencia = EditText5.Value;
                //string Estado = ComboBox0.GetSelectedValue();
                Int32 Filas = Grid0.Rows.Count;
                if (Filas == 0)
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    return;
                }
                int ContarMarcados = 0;
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row) == "Y")
                    {
                        ContarMarcados += 1;
                    }
                }
                if (ContarMarcados == 0)
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    return;
                }
                bool Consulta = Sb1Messages.ShowQuestion(addonMessageInfo.MessageIdiomaMessage309(Sb1Globals.Idioma));
                if (!Consulta)
                {
                    return;
                }
                oForm.Freeze(true);
                /////////////////////////////GRABAR DESPACHO
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row) == "Y")
                    {
                        int? docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                        string NumDespacho = Grid0.DataTable.GetString("ORDENITEM", row);
                        string OrdenDespacho = Grid0.DataTable.GetString("CORRDESPACHO", row);
                        string LineId = Grid0.DataTable.GetString("LineId", row);
                        string DocEntryCabecera = Grid0.DataTable.GetString("DocEntryCabecera", row);

                        if (Estado == "E")
                        {
                            EstadoDespacho obj = new EstadoDespacho();
                            obj = AsignaObjetoDespacho(Estado, Ocurrencia);
                            dynamic jsonData = JsonConvert.SerializeObject(obj);



                            /////////////////////////////CORRDESPACHO
                            response = string.Empty;

                            using (EntregaBLL entregaBLL = new EntregaBLL())
                            {
                                asigno = entregaBLL.UpdateEstadoEntrega(docEntry, jsonData, ref response);
                            }

                            if (asigno)
                            {
                            RutaTransportista1EstadoCabecera ActualizarEstadoObj = new RutaTransportista1EstadoCabecera();
                            ActualizarEstadoObj = ActualizarEstadoObjetoDespachoCabecera(DocEntryCabecera, LineId, Estado, Ocurrencia);
                            dynamic jsonDataUpdate = JsonConvert.SerializeObject(ActualizarEstadoObj);

                            EntregaDAL.UpdateEstadoEntregaDRT1(DocEntryCabecera, jsonDataUpdate);

                            //    HistoricoDespachos objHistorico = new HistoricoDespachos();
                            //    objHistorico = AsignaDatosObject(docEntry, NumDespacho.ToString(), Estado, OrdenDespacho, fecha, Chofer, NombreChofer, "", "", "", Sb1Globals.UserName);
                            //    dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                            //    string rpta = "";
                            //    EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                            //    Sb1Messages.ShowMessageBoxWarning("Actualizado a Entregado:  " + OrdenDespacho + " Chofer: " + NombreChofer);
                            }
                            else
                            {
                                Sb1Messages.ShowError(response);
                            }
                        }
                        else if (Estado == "S")
                        {
                            
                        }
                        /////////////////////////////
                    }
                }
                
                Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage310(Sb1Globals.Idioma));

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
            }
            Button0.Item.Click();
        }

        private void PrevioOcurrencias()
        {

            string ID = oForm.UniqueID.ToString();
            frmOcurrenciaDespacho Datos = new frmOcurrenciaDespacho(this);
            Datos.Show();

        }

        public void ProcesoOcurrencia(string idOcurrencia,string ocurrencia, string estado)
        {
            try
            {

                string fecha = EditText0.Value;
                string Chofer = EditText1.Value;
                string NombreChofer = EditText2.Value;
                string Licencia = EditText5.Value;
                string response = string.Empty;
                string LineId = string.Empty;
                int? docentry = 0;
                string entrega = string.Empty;
                string NumDespacho = string.Empty;
                string OrdenDespacho = string.Empty;
                bool ActualizoRegistro = false;
                oForm.Freeze(true);
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row) == "Y")
                    {
                        docentry = Grid0.DataTable.GetInt("DocEntry", row);
                        entrega = Grid0.DataTable.GetString("N° Entrega", row);
                        LineId = Grid0.DataTable.GetString("LineId", row);

                        NumDespacho = Grid0.DataTable.GetString("ORDENITEM", row);
                        OrdenDespacho = Grid0.DataTable.GetString("CORRDESPACHO", row);
                        string DocEntryCabecera = Grid0.DataTable.GetString("DocEntryCabecera", row);

                        EstadoDespachoVolverProgramar obj = new EstadoDespachoVolverProgramar();
                        obj = AsignaObjetoDespachoSinProgramar(estado, ocurrencia);
                        dynamic jsonData = JsonConvert.SerializeObject(obj);
                        response = string.Empty;

                        
                        using (EntregaBLL entregaBLL = new EntregaBLL())
                        {
                           ActualizoRegistro = entregaBLL.UpdateEstadoEntrega(docentry, jsonData, ref response);
                        }

                        if (ActualizoRegistro)
                        {
                            RutaTransportista1EstadoCabecera ActualizarEstadoObj = new RutaTransportista1EstadoCabecera();
                            ActualizarEstadoObj = ActualizarEstadoObjetoDespachoCabecera(DocEntryCabecera, LineId, estado, idOcurrencia);
                            dynamic jsonDataUpdate = JsonConvert.SerializeObject(ActualizarEstadoObj);

                            EntregaDAL.UpdateEstadoEntregaDRT1(DocEntryCabecera, jsonDataUpdate);

                            //HistoricoDespachos objHistorico = new HistoricoDespachos();
                            //objHistorico = AsignaDatosObject(docentry, NumDespacho.ToString(), estado, OrdenDespacho, fecha, Chofer, NombreChofer, "", "", ocurrencia, Sb1Globals.UserName);
                            //dynamic jsonHist = JsonConvert.SerializeObject(objHistorico);
                            //string rpta = "";
                            //EntregaDAL.GrabarHistorial(jsonHist, out rpta);
                            //Sb1Messages.ShowMessage("Registro: " + entrega + " Actualizado");

                        }
                        else
                        {
                            Sb1Messages.ShowError("Registro: " + entrega + " No se pudo actualizar " + response);
                        }
                    }
                }
                Button0.Item.Click();
                Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage310(Sb1Globals.Idioma));
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                int ContarMarcados = 0;
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("Marcar", row) == "Y")
                    {
                        ContarMarcados += 1;
                    }
                }
                if (ContarMarcados == 0)
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    return;
                }
                PrevioOcurrencias();

            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaFinishLoading(Sb1Globals.Idioma));
            }

        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();
        }

        private void LinkedButton0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }

        private void Grid0_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "N° Entrega")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("N° Entrega")));
                col.LinkedObjectType = "15";// muestra la flecha amariilla asociada al objeto pedidos  
            }
        }

        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.EditTextColumn col = null;
            string docEntry = string.Empty;
            string code = string.Empty;

            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;

            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "N° Entrega")

            {
                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                docEntry = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText6.Value = docEntry;

                EditText6.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_DeliveryNotes;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("N° Entrega")));
                col.LinkedObjectType = string.Empty;// 
            }
            else if (pVal.ColUID == "NumAtCard")

            {
                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                docEntry = Grid0.DataTable.GetValue("U_DocEntryRef", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText6.Value = docEntry;

                EditText6.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NumAtCard")));
                col.LinkedObjectType = string.Empty;// 
            }
            else if (pVal.ColUID == "Chofer")
            {
                code = Grid0.DataTable.GetValue("Chofer", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText6.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "CONDUC";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("Código Chofer")));
                col.LinkedObjectType = string.Empty;// 
            }
            else if (pVal.ColUID == "N° Referencia")
            {
                docEntry = Grid0.DataTable.GetValue("U_DocEntryRef", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                EditText6.Value = docEntry;

                EditText6.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("N° Referencia")));
                col.LinkedObjectType = "13";// 
            }

        }

        private void EditText3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }

        private void EditText4_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string texto = EditText4.Value;
                if (texto.Length < 8)
                {
                    filaseleccionada = -1;
                    return;
                }
                if (pVal.CharPressed != 13)
                {
                    for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                    {
                        string docnum = Grid0.DataTable.GetString("N° Entrega", row);
                        if (docnum == texto)
                        {
                            Grid0.Rows.SelectedRows.Clear();
                            Grid0.Rows.SelectedRows.Add(row);
                            filaseleccionada = row;
                            return;
                        }
                    }
                }
                else
                {
                    if (filaseleccionada != -1)
                    {
                        if (Grid0.DataTable.GetValue(0, filaseleccionada).ToString() != "Y")
                        {
                            Grid0.DataTable.SetValue(0, filaseleccionada, "Y");
                        }
                        else
                        {
                            Grid0.DataTable.SetValue(0, filaseleccionada, "N");
                        }
                    }
                }
            }
            catch
            { }

        }

        private void EditText4_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            filaseleccionada = -1;

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            // si hicieron Check o deschekearon debo actualizar el contador de documentos seleccionados
            int rowSelected = 0;
            int rowIndex = 0;
            string isCheck = "N";
            try
            {
                // si hicieron clic en la columna para marcar o desmarcar
                if (pVal.ColUID == "Marcar" && pVal.Row == -1)
                {

                    // obtengo los registros seleccionados
                    rowSelected = EditText4.GetInt();


                    // debo marcar o desmarcar todo
                    Utils.CheckRowsEstadoDespacho(oForm, Grid0, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText7.SetInt(rowSelected);
                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marcar" && pVal.Row > -1)
                {
                    EditText7.SetFocus();

                    // obtengo los registros seleccionados
                    rowSelected = EditText7.GetInt();

                    rowIndex = pVal.Row;

                    isCheck = Grid0.DataTable.GetString("Marcar", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                    

                    // si hicieron check
                    if (isCheck == "Y")
                    {
                        rowSelected += 1;
                    }
                    else
                    {
                        // si descheckearon
                        if (rowSelected > 0) // para evitar negativos
                        {
                            rowSelected -= 1;
                        }
                    }

                    // asigno el nro de documentos seleccionados
                    EditText7.SetInt(rowSelected);

                }
            }

            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }

        }

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }

        private SAPbouiCOM.Button Button4;

        private void Button4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            int RegistrosMarcados = 0;
            for (int oRow = 0; oRow < Grid0.Rows.Count; oRow++)
            {
                if (Grid0.DataTable.GetString("Marcar", oRow) == "Y")
                {
                    RegistrosMarcados += 1;
                }
            }
            if (RegistrosMarcados > 0)
            {
                UltimaMilla.frmCambiarEstadoDespacho frmCambiarEstadoDespacho = new UltimaMilla.frmCambiarEstadoDespacho(this);
                frmCambiarEstadoDespacho.Show();
            }
            else
            {
                Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage327(Sb1Globals.Idioma));
            }
               
        }

        public void UpdateDespacho(string dispatchDate, string driverCode = "", string driverName = "", string driverLicence = "", string assistantCode = "", string assistantName = "", string vehiculeCode = "", string vehiculeName = "", string vehiculeBrandName = "")
        {

           // string pesoDespacho = this.EditText16.Value.Trim();

          
            bool isUpdated = false;
            string response = string.Empty;

            try
            {

                int ContarMarcados = 0;

                if (ContarMarcados == 0)
                {
                    string docNum = string.Empty;
                    int? docEntry = 0;
                    string choferLicencia = string.Empty;
                    string vehiculoMarca = string.Empty;
                    string vehiculoPlaca = string.Empty;
                    string ayudanteName = string.Empty;
                    string ordenDespacho = string.Empty;

                    
                    oForm.Freeze(true);
                    //PROGRAMAR DESPACHO
                    SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                    for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                    {
                        // verifico si el documento se encuentra seleccionado
                        if (Grid0.DataTable.GetString("Marca", row) == "Y")
                        {
                            docEntry = Grid0.DataTable.GetInt("DocEntry", row);
                            docNum = Grid0.DataTable.GetString("Entrega", row);

                          
                            oDT.Clear();

                            // realmente necesito obtener este numero ???
                            using (EntregaBLL entregaBLL = new EntregaBLL())
                            {
                                ordenDespacho = entregaBLL.ObtenerCorrelativoDespacho(oDT, dispatchDate);
                            }

                            //////////////////////// obtengo los datos para actualizar la guia ////////////////////////////
                            EntregaDespacho objDespacho = new EntregaDespacho();
                            objDespacho = GetObjDespacho(driverLicence, ordenDespacho, dispatchDate, driverName, assistantName, vehiculeName, vehiculeBrandName, "P", "PE", "-1", "1", dispatchDate, dispatchDate);
                            dynamic objDespachoJson = JsonConvert.SerializeObject(objDespacho);



                            Sb1Messages.ShowMessage(string.Format(addonMessageInfo.MessageIdiomaMessage210(Sb1Globals.Idioma), docNum));
                            using (EntregaBLL entregaBLL = new EntregaBLL())
                            {
                                isUpdated = entregaBLL.UpdateEstadoEntrega(docEntry, objDespachoJson, ref response);
                            }

                        }
                    }
                    
                    ///////////////////////////////
                    Sb1Messages.ShowMessageBoxWarning(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));

                    /// DEBO GENERAR o BUSCAR EL DOCUMENTO DE SALIDA DEL CHOFER VEHICULO "HOJA DE DESPACHO DEL CHOFER"

                    
                    Sb1Messages.ShowMessage(addonMessageInfo.MessageIdiomaMessage308(Sb1Globals.Idioma));
                    // FIN PROGRAMAR

                }
                else
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage301(Sb1Globals.Idioma));
                    return;
                }
            }
            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private EntregaDespacho GetObjDespacho(string driverLicence, string ordenDespacho, string fechaDespacho,
               string nombreChofer, string ayudanteName, string placaVehiculo, string marcaVehiculo, string status,
               string U_SYP_FEEST, string U_SYP_FEESUNAT, string U_SYP_FEMEX, string U_SYP_FEGFI, string U_SYP_FEGFE)
        {
#if AD_PE
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_FEEST = U_SYP_FEEST;
            objDespacho.U_SYP_FEESUNAT = U_SYP_FEESUNAT;
            objDespacho.U_SYP_FEMEX = U_SYP_FEMEX;
            objDespacho.U_SYP_FEGFI = U_SYP_FEGFI;
            objDespacho.U_SYP_FEGFE = U_SYP_FEGFE;

            objDespacho.U_SYP_DT_ESTDES = status;
#elif AD_BO
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_DT_ESTDES = status;
#else
            EntregaDespacho objDespacho = new EntregaDespacho();
            objDespacho.U_SYP_MDFC = driverLicence;
            objDespacho.U_SYP_DT_CORRDES = ordenDespacho;
            objDespacho.U_SYP_DT_FCDES = fechaDespacho;
            objDespacho.U_SYP_MDFN = nombreChofer;
            objDespacho.U_SYP_DT_AYUDANTE = ayudanteName;
            objDespacho.U_SYP_MDVC = placaVehiculo;
            objDespacho.U_SYP_MDVN = marcaVehiculo;
            objDespacho.U_SYP_DT_ESTDES = status;
#endif

            return objDespacho;

        }

        private void Button5_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString();
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                        EditText5.Value = chooseFromListEvent.SelectedObjects.GetValue("U_SYP_CHLI", 0).ToString();

                    }
                }

            }
            catch (Exception)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }
        }

        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox ComboBox1;
        string Sucursal;
        private void ComboBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void ComboBox1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            /*
             
           
            Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = Sb1Globals.IDSucursal;
            cfl1.SetConditions(cons1);

             */
#if AD_PE
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            cfl.SetConditions(null);
            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                // Conductores se filtran por sucursal 
                SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
                SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
                SAPbouiCOM.Condition con1;
                con1 = cons1.Add();
                con1.Alias = "U_VIS_BranchCode";
                con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                con1.CondVal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));
                cfl1.SetConditions(cons1);

                Sucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));
            }
            else
            {

            }

#else
            Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox1.GetSelectedDescription()));

            // Conductores se filtran por sucursal 
            SAPbouiCOM.ChooseFromList cfl1 = oForm.ChooseFromLists.Item("CFL_0");
            SAPbouiCOM.Conditions cons1 = cfl1.GetConditions();
            SAPbouiCOM.Condition con1;
            con1 = cons1.Add();
            con1.Alias = "U_VIS_BranchCode";
            con1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con1.CondVal = Sb1Globals.IDSucursal;
            cfl1.SetConditions(cons1);

#endif

        }
    }
}
