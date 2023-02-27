//#define AD_PE
#define AD_PY
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SAPbobsCOM;
using SAPbouiCOM;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("DispatchRoute", "UltimaMilla/FrmDispatchRoute.b1f")]
    class FrmDispatchRoute : UserFormBase
    {

        public static SAPbouiCOM.Form oForm;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.EditText EditText19;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.ComboBox ComboBox2;
        private EditText EditText20;
        private EditText EditText21;
        private LinkedButton LinkedButton2;
        private EditText EditText22;
        private StaticText StaticText18;
        public static string U_SYP_VEMA = "";
        public static string DocEntryEntrega;
        public static string EstadoEntrega;
        private SAPbouiCOM.Button Button3;
        public static dynamic objDeleteDespachoJson = "";
        public static string Cancelar = "";
        public static AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        public FrmDispatchRoute()
        {
        }
        private static UpdateEntregaDespacho GetObjDespacho( string Placa,string MARCA,string LICENCIA_CONDUCTOR,
            string NOMBRE_CONDUCTOR,string FechaProg,string CodAyudante, string Ayudante)
        {
            UpdateEntregaDespacho objDespacho = new UpdateEntregaDespacho();
            objDespacho.U_SYP_MDVC = Placa;
            objDespacho.U_SYP_MDVN = MARCA;
            objDespacho.U_SYP_MDFC = LICENCIA_CONDUCTOR;
            objDespacho.U_SYP_MDFN = NOMBRE_CONDUCTOR;
            objDespacho.U_SYP_DT_FCDES = FechaProg;
            objDespacho.U_SYP_DT_AYUDANTE = Ayudante;
            return objDespacho;

        }

        public static void ValidarCamposORDT(Recordset GetDataODLN,string DocEntry)
        {
            string ValidarCamposODRT = string.Format(addonMessageInfo.QueryValidacionProgramacion, DocEntry);
            GetDataODLN.DoQuery(ValidarCamposODRT);
        }
        public static void ObtenerDatosChofer(Recordset recordset,string Query,string Parametro)
        {
            string ValidarCamposODRT = string.Format(Query, Parametro);
            recordset.DoQuery(ValidarCamposODRT);
        }

        public static void formEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
                if (BusinessObjectInfo.ActionSuccess &&
                    !BusinessObjectInfo.BeforeAction)
                {
                if (BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_UPDATE)
                {
                    Sb1Messages.ShowWarning("Iniciando Actualizacion...");
                    bool isUpdated = false;
                    SAPbouiCOM.Form oForm = null;
                    oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(BusinessObjectInfo.FormUID);
                    SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource("@VIS_DIS_DRT1");

                    //VALIDAR SI SE ACTUALIZO LOS CAMPOS QUE AFECTAN A LAS ENTREGAS
                    Recordset GetDataODLN = null;
                    for (int i= 0; i < 1; i++)
                    {
                        #if AD_PE
                                ValidarCamposORDT(GetDataODLN, oDatasource.GetString("U_DocEntry", i));
                        #else
                                ValidarCamposORDT(GetDataODLN, oDatasource.GetString("U_DocEntry", i));
                        #endif
                    }

                    if (GetDataODLN.Fields.Item("U_SYP_MDFN").Value.ToString() != oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_DriverName", 0) ||
                        oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_AssistantName", 0) != GetDataODLN.Fields.Item("U_SYP_DT_AYUDANTE").Value.ToString() ||
                        oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_DocDate", 0) != GetDataODLN.Fields.Item("U_SYP_DT_FCDES").Value.ToString())
                    {
                        Recordset Conductorrecordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        ObtenerDatosChofer(Conductorrecordset, addonMessageInfo.QueryObtenerDescripcionVehiculo,
                            oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_DriverCode", 0));

                        Recordset Vehiculorecordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        ObtenerDatosChofer(Vehiculorecordset, addonMessageInfo.QueryObtenerDescripcionConducor,
                            oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_DriverCode", 0));

                        UpdateEntregaDespacho objDespacho = new UpdateEntregaDespacho();
                        objDespacho = GetObjDespacho(Vehiculorecordset.Fields.Item("U_SYP_VEPL").Value.ToString(), 
                                                     Vehiculorecordset.Fields.Item("U_SYP_VEMA").Value.ToString(), 
                                                     Conductorrecordset.Fields.Item("U_SYP_CHLI").Value.ToString(),
                                                     Conductorrecordset.Fields.Item("Name").Value.ToString(),
                                                     oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_DocDate", 0),
                                                     oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_AssistantCode", 0),
                                                     oForm.DataSources.DBDataSources.Item("@VIS_DIS_ODRT").GetValue("U_AssistantName", 0));
                        
                        dynamic objDespachoJson = JsonConvert.SerializeObject(objDespacho);

                            for (int oRows = 0; oRows < oDatasource.Size; oRows++)
                            {
                                string docEntry = oDatasource.GetString("U_DocEntry", oRows);
                                if (docEntry != "")
                                {
                                    using (EntregaBLL entregaBLL = new EntregaBLL())
                                    {
                                        string response = "";
                                        isUpdated = entregaBLL.UpdateEstadoEntrega(Convert.ToInt32(docEntry), objDespachoJson, ref response);
                                        Sb1Messages.ShowSuccess("Se Actualizaron : " + oRows +" de "+oDatasource.Size);
                                    }
                                }
                            }

                    }

                        if (objDeleteDespachoJson != "")
                        {
                            string response1 = "";
                            isUpdated = UpdateEstadoEntrega(Convert.ToInt32(DocEntryEntrega), objDeleteDespachoJson, ref response1);
                        }

                        if (Cancelar == "Cancelar")
                        {
                            for (int oRows = 0; oRows < oDatasource.Size; oRows++)
                            {
                                if (oDatasource.GetString("U_DocEntry", oRows) != "")
                                {
                                    using (EntregaBLL entregaBLL = new EntregaBLL())
                                    {
                                        string response = "";
                                        string JsonV = "{\"U_SYP_DT_ESTDES\"" +":"+"\"V\" }";
                                        isUpdated = entregaBLL.UpdateEstadoEntrega(Convert.ToInt32(oDatasource.GetString("U_DocEntry", oRows)), JsonV, ref response);
                                        
                                    }
                                }
                            }
                        }


                    }

                }
        }
        
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText6.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText6_KeyDownAfter);
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_23").Specific));
            this.EditText8.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText8_ClickAfter);
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_25").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.EditText11.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText11_ClickAfter);
            this.EditText11.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText11_ChooseFromListAfter);
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_27").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_28").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("Item_29").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_32").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("3").Specific));
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Matrix1.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.Matrix1_LinkPressedBefore);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_0").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("Item_30").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_4").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText9.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText9_ChooseFromListAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("Item_35").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("Item_36").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_37").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_38").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("Item_39").Specific));
            this.EditText19 = ((SAPbouiCOM.EditText)(this.GetItem("Item_40").Specific));
            this.EditText19.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText19_KeyDownAfter);
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_41").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_42").Specific));
            //   this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_43").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_44").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_45").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_47").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("Item_48").Specific));
            this.EditText21 = ((SAPbouiCOM.EditText)(this.GetItem("Item_49").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_50").Specific));
            this.EditText22 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_51").Specific));
            this.OnCustomInitialize();

        }
        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);

        }
        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            Folder0.Select();
            Utils.LoadQueryDynamic(ref ComboBox1, "select \"Code\", \"Name\" from \"@VIS_GEN_OCLP\" ");
            Utils.LoadQueryDynamic(ref ComboBox2, "select \"Code\", \"Name\" from \"@VIS_GEN_OCLP\" ");

            oForm.EnabledMenuMatrix();
        }
        public static void MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            objDeleteDespachoJson = "";
            Cancelar = "";
            if (pVal.MenuUID == SboMenuItem.AddRow && pVal.BeforeAction == true)
            {
                BubbleEvent = false;
                Sb1Messages.ShowWarning("No se puede agregar lineas al registro");
            }
            else if (pVal.MenuUID == SboMenuItem.DeleteRow && pVal.BeforeAction == true)
            {
                var Menssage = Sb1Messages.ShowMessageBox("Esta seguro de Eliminar este registro,\n recordar que el documento pasara a estado Volver a programar");
                if (Menssage==1)
                {
                    oForm.Freeze(true);
                    SAPbouiCOM.Matrix oMatrix = ((SAPbouiCOM.Matrix)oForm.Items.Item("3").Specific);
                    SAPbouiCOM.DBDataSource oDBDataSource = oForm.DataSources.DBDataSources.Item("@VIS_DIS_DRT1");
                    int nRow = (int)oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                    oMatrix.FlushToDataSource();
                    oDBDataSource.RemoveRecord(nRow - 1);
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                    oMatrix.LoadFromDataSource();
                    UpdateEstadoDespacho objDespacho = new UpdateEstadoDespacho();
                    objDespacho = UpdateDespacho("V");
                    objDeleteDespachoJson = JsonConvert.SerializeObject(objDespacho);
                    BubbleEvent = false;
                    oForm.Freeze(false);
                }
                else
                {
                    BubbleEvent = false;
                }
               
            }
            else if (pVal.MenuUID == SboMenuItem.Delete && pVal.BeforeAction == true)
            {
                BubbleEvent = false;
                Sb1Messages.ShowWarning("No se puede eliminar el registro");
            }
            else if (pVal.MenuUID == SboMenuItem.Cancel && pVal.BeforeAction == true)
            {
                 BubbleEvent = true;
                var Menssage = Sb1Messages.ShowMessageBox("Esta seguro de Cancelar este registro,\n recordar que los documentos pasaran a estado Volver a programar");
                if (Menssage == 1)
                {
                    Cancelar = "Cancelar";
                }
                else
                {
                    Cancelar = "";
                }
            }
            else if (pVal.MenuUID == SboMenuItem.Close && pVal.BeforeAction == true)
            {
                BubbleEvent = false;
                Sb1Messages.ShowWarning("No se puede cerrar el registro");
            }

            
        }
        public static bool UpdateEstadoEntrega(int? docEntry, dynamic jsonData, ref string response)
        {
            bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;

#if AD_PE
                restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#elif AD_BO
                                    restResponse = methods.PATCH("Invoices", docEntry, jsonData);
#elif AD_ES
                                    restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#elif AD_PY
                                    restResponse = methods.PATCH("DeliveryNotes", docEntry, jsonData);
#endif

                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;
                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }
                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
            }

        }
        private static UpdateEstadoDespacho UpdateDespacho(string Estatus)
        {
            UpdateEstadoDespacho objDespacho = new UpdateEstadoDespacho();
            objDespacho.U_SYP_DT_ESTDES = Estatus;
            return objDespacho;

        }
        public void AddRow()
        {

        }
        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
         
         
        }
        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // Matrix1.AutoResizeColumns();

        }
        private void EditText6_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }
        private void EditText19_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }
        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
           BubbleEvent = true;
            //throw new System.NotImplementedException();
        }
        public bool Layout_Preview(string ReportName, string DocNum)
        {
            SAPbobsCOM.Recordset oRS = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRS.DoQuery("SELECT \"GUID\" FROM OCMN WHERE \"Name\" = '" + ReportName + "' AND \"Type\" = 'C'");
            SAPbouiCOM.Form form2 = null;
            if (oRS.RecordCount > 0)
            {
                string MenuID = oRS.Fields.Item(0).Value.ToString();

               SAPbouiCOM.Framework.Application.SBO_Application.Menus.Item(MenuID).Activate();
                form2 = (SAPbouiCOM.Form)SAPbouiCOM.Framework.Application.SBO_Application.Forms.ActiveForm;
                ((EditText)form2.Items.Item("1000003").Specific).String = DocNum;
                form2.Items.Item("1").Click(BoCellClickType.ct_Regular);
                return true;
            }
            else
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox("Report layout "+ ReportName+" not found.", 0, "OK", null, null);
                return false;
            }

        }
        public  SAPbouiCOM.Matrix GetMatrix()
        {
            return SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID).GetMatrix("Matrix1");
        }
        public static void FrmDispatchRoute_FormMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            //SAPbouiCOM.Matrix oMatrix;
           
            

           // Matrix1.AutoResizeColumns();
            BubbleEvent = true;
        }
        private void Button3_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            Layout_Preview("Informe Ruta de Despacho", EditText8.Value);
        }
        private void EditText8_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
     

        }
        private void Matrix1_LinkPressedBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            BubbleEvent = true;
            string docEntry = string.Empty;
            string code = string.Empty;
            SAPbouiCOM.EditText col = null;

            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;
            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "Entrega")

            {
                docEntry = oForm.GetDBDataSource("@VIS_DIS_DRT1").GetString("U_DocEntry", pVal.Row -1);


                EditText21.Value = docEntry;

                EditText21.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                LinkedButton2.LinkedObject =  BoLinkedObject.lf_DeliveryNotes;
                LinkedButton2.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

            }



            else if (pVal.ColUID == "NroFactura")

            {
                EditText4.Value = docEntry;
                LinkedButton0.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_Invoice;
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
             }

            else if (pVal.ColUID == "Chofer")
            {
                EditText4.Value = code;

                LinkedButton0.LinkedObjectType = "CONDUC";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
            }

            else if (pVal.ColUID == "Vehiculo")
            {
                EditText4.Value = code;
                LinkedButton0.LinkedObjectType = "VEHICU";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
            }

            else if (pVal.ColUID == "Ayudante")
            {
               EditText4.Value = code;
                LinkedButton0.LinkedObjectType = "OAYD";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
            }


            else if (pVal.ColUID == "Vendedor")
            {
                EditText4.Value = code;
                LinkedButton0.LinkedObjectType = "53";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
            }

        }
        private void EditText9_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg ChooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (ChooseFromListEvent.SelectedObjects != null)
                {
                    if (ChooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText12.Value = ChooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPL", 0).ToString();
                        EditText5.Value= ChooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString();
                        U_SYP_VEMA= ChooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEMA", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void EditText11_ChooseFromListAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg ChooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (ChooseFromListEvent.SelectedObjects != null)
                {
                    if (ChooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                       EditText4.Value = ChooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString();
                       // EditText5.Value = ChooseFromListEvent.SelectedObjects.GetValue("U_SYP_VEPM", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void Button2_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {

        }
        private void Matrix1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            DocEntryEntrega = oForm.GetDBDataSource("@VIS_DIS_DRT1").GetString("U_DocEntry", pVal.Row - 1);
            EstadoEntrega = oForm.GetDBDataSource("@VIS_DIS_DRT1").GetString("U_Delivered", pVal.Row - 1);
        }
        private void Form_DataUpdateBefore(BusinessObjectInfo pVal, bool BubbleEvent)
        {
            BubbleEvent = true;
        }
        private void EditText11_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {

        }

    }
}
