#define AD_PE


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.DAL;
using SAPbouiCOM;
using Vistony.Distribucion.BLL;
using Forxap.Framework.UI;
using Vistony.Distribucion.BO;
using RestSharp;
using Newtonsoft.Json;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("StartRouteSMS", "UltimaMilla/StartRouteSMS.b1f")]
    class StartRouteSMS : UserFormBase
    {
        public StartRouteSMS()
        {
        }
        SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Grid Grid0;
        EntregaBLL objEntregaBLL = new EntregaBLL();
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText0;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Grid0.LinkPressedAfter += new SAPbouiCOM._IGridEvents_LinkPressedAfterEventHandler(this.Grid0_LinkPressedAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_4").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_9").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }


        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Grid0.AutoResizeColumns();
            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                Utils.LoadQuerySucursales(ref ComboBox0, string.Format(addonMessageInfo.QueryComboBoxSucursales, Sb1Globals.UserSignature));

                ComboBox0.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
            }
            else
            {
                ComboBox0.Item.Visible = false;
                StaticText1.Item.Visible = false;
            }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {

            if (Sb1Globals.AdminPuntoEmision == "1")
            {
                if (EditText0.Value == string.Empty || ComboBox0.GetValue() == string.Empty)
                {
                    BubbleEvent = false;
                    Sb1Messages.ShowError("Datos insuficientes");
                }
                else
                {
                    BubbleEvent = true;
                }
            }
            else
            {
                BubbleEvent = true;
            }


           
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Freeze(true);
            string Query = string.Empty;
            string ab = Sb1Globals.Sucursal;
#if AD_PE
            if (Sb1Globals.AdminPuntoEmision=="1")
           {
                 Query = string.Format(AddonMessageInfo.QueryObtenerDespachosStartRouteDescripcion, EditText0.GetString(), ComboBox0.GetSelectedDescription());
            }
           else
            {
                 Query = string.Format(AddonMessageInfo.QueryObtenerDespachosStartRoute, EditText0.GetString(), Sb1Globals.Sucursal);
            }
            DataTable oDt = oForm.GetDataTable("DT_0");
            objEntregaBLL.ExcecuteDT( ref oDt, Query);
            FormatGrid(Grid0);
#endif
            oForm.Freeze(false);


        }

        public void FormatGrid(Grid oGrid)
        {
            oGrid.AssignLineNro();
            oGrid.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            oGrid.Columns.Item("DocEntry").Visible = false;
            oGrid.Columns.Item("NumDespacho").TitleObject.Caption = "Ruta de Despacho";
            oGrid.Columns.Item("NumDespacho").RightJustified = true;
            Grid0.Columns.Item("NumDespacho").LinkedObjectType(Grid0, "NumDespacho", "VIS_DIS_ODRT");


            oGrid.Columns.Item("Code").TitleObject.Caption = "Cod. Chofer";
            oGrid.Columns.Item("Code").Visible = false;
            oGrid.Columns.Item("U_DriverName").TitleObject.Caption = "Nombre de Chofer";
            Grid0.Columns.Item("U_DriverName").LinkedObjectType(Grid0, "U_DriverName", "CONDUC"); // Choferes

            oGrid.Columns.Item("U_AssistantCode").TitleObject.Caption = "Cod. Ayudante";
            oGrid.Columns.Item("U_AssistantCode").Visible = false;
            oGrid.Columns.Item("U_AssistantName").TitleObject.Caption = "Nombre de Ayudante";

            oGrid.Columns.Item("U_VehiculeName").TitleObject.Caption = "Vehículo";
            oGrid.Columns.Item("U_VehiculeCode").Visible = false;
            Grid0.Columns.Item("U_VehiculeName").LinkedObjectType(Grid0, "U_VehiculeName", "VEHICU"); // Vehiculo

            oGrid.Columns.Item("U_VIS_BranchCode").Visible = false;
            oGrid.Columns.Item("Sucursal").Visible = false;

            EditText2.SetInt(oGrid.Rows.Count);
            EditText2.Item.RightJustified = true;

            oGrid.ReadOnlyColumns();
            oGrid.Columns.Item(0).Editable = true;
            oGrid.AutoResizeColumns();
        }

        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        public StartRoute startRoute(string Value,int Hora)
        {
            StartRoute startRoute = new StartRoute();
            startRoute.U_SendSMS = Value;
            startRoute.U_StartTime = Hora;
            return startRoute;
        }
        private void Button2_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            string time = DateTime.Now.ToString("hhmm");

            var IniciarRuta = Sb1Messages.ShowQuestion("Se enviara un SMS a los clientes asignado a la ruta de despacho seleccionada \n ¿Desea continuar?");
            if (IniciarRuta)
            {
                for (int oRow = 0; oRow < Grid0.Rows.Count; oRow++)
                {

                    Sb1Messages.ShowWarning("Generando Envio de SMS "+ (oRow+1) + " de "+ EditText2.GetString());
                    string Query = string.Format(AddonMessageInfo.QueryObtenerDespachosStartRouteDetalle, Grid0.DataTable.GetString("DocEntry", oRow).ToString());
                    if (Grid0.DataTable.GetString("Marcar", oRow).ToString()=="Y")
                    {

                        DataTable oDt = oForm.GetDataTable("DT_1");
                        objEntregaBLL.ExcecuteDT(ref oDt, Query);

                        for (int o1Row = 0; o1Row < oDt.Rows.Count; o1Row++)
                        {
                            string Mensaje = string.Format("VISTONY : Hola {0} " + ".." +
                                        "Nos complace informarle que su pedido {1} se encuentra en ruta hacia su destino. " + ".." +
                                        "Queremos mantenerlo actualizado sobre el estado de su entrega y asegurarle que estamos haciendo " +
                                        "todo lo posible para garantizar que su compra llegue a usted en perfectas condiciones y en el tiempo estipulado. ",
                                          oDt.GetValue("CardName", o1Row).ToString()
                                        , oDt.GetValue("U_NumAtCard", o1Row).ToString());


                            RestClient client = new RestClient("http://192.168.254.20:88/vs1.0/sms");
                            RestRequest request = new RestRequest(Method.POST);
                            string JsonObtenerCabezera = JsonConvert.SerializeObject(cabecera_mensaje(Mensaje.Replace("..", "\n"),"51"+oDt.GetValue("Num", o1Row).ToString()));
                            string dataReq = JsonObtenerCabezera;
                            IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

                        }
                       // string time = DateTime.Now.ToString("hhmm");

                        StartRoute objStartRoute = startRoute("Y",Convert.ToInt32(time));
                        string jsonData = JsonConvert.SerializeObject(objStartRoute);
                        Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                        dynamic response = methods.PATCH("VIS_DIS_ODRT", Convert.ToInt32(Grid0.DataTable.GetString("DocEntry", oRow).ToString()), jsonData);
                        dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                        if (response.StatusCode.ToString() == "Created")
                        {

                        }
                        else
                        {

                        }

                    }


                }


            }
        }

        private void Grid0_LinkPressedAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "NumDespacho")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NumDespacho")));
                col.LinkedObjectType = "VIS_DIS_ODRT";
            }
            if (pVal.ColUID == "U_DriverName")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_DriverName")));
                col.LinkedObjectType = "CONDUC";
            }
            if (pVal.ColUID == "U_AssistantName")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_AssistantName")));
                col.LinkedObjectType = "OAYD";

            }
            if (pVal.ColUID == "U_VehiculeName")
            {
                SAPbouiCOM.EditTextColumn col = null;
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_VehiculeName")));
                col.LinkedObjectType = "VEHICU";
            }
        }

        private void Grid0_LinkPressedBefore(object sboObject, SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            string docEntry = string.Empty;
            string code = string.Empty;
            SAPbouiCOM.EditTextColumn col = null;

            int rowSelected = pVal.Row;
            int rowIndex = rowSelected;
            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "NumDespacho")
            {
                code = Grid0.DataTable.GetValue("DocEntry", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText1.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "VIS_DIS_ODRT";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("NumDespacho")));
                col.LinkedObjectType = string.Empty;// 
            }
            if (pVal.ColUID == "U_DriverName")
            {
                code = Grid0.DataTable.GetValue("Code", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText1.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "CONDUC";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_DriverName")));
                col.LinkedObjectType = string.Empty;// 
            }
            if (pVal.ColUID == "U_AssistantName")
            {
                code = Grid0.DataTable.GetValue("U_AssistantCode", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText1.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "OAYD";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_AssistantName")));
                col.LinkedObjectType = string.Empty;// 
            }
            if (pVal.ColUID == "U_VehiculeName")
            {
                code = Grid0.DataTable.GetValue("U_VehiculeCode", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                EditText1.Value = code;

                //EditText11.SetFocus();

                LinkedButton0.LinkedObjectType = "VEHICU";
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item("U_VehiculeName")));
                col.LinkedObjectType = string.Empty;// 
            }
        }

        public Cabecera_Mensaje cabecera_mensaje(string Mensaje,string Numero)
        {
            List<Cabecera_Mensaje> ListCabecera_Mensaje = new List<Cabecera_Mensaje>();
            Cabecera_Mensaje objCabecera_Mensaje = new Cabecera_Mensaje();
            objCabecera_Mensaje.Data = DetalleMensaje(Mensaje,Numero);
            return objCabecera_Mensaje;
        }
        public List<Data> DetalleMensaje(string Mensaje,string Numero)
        {
            List<Data> ListData = new List<Data>();
            Data objData = new Data();
            objData.Mensaje = Mensaje;
            objData.NumeroTelf = Numero;
            ListData.Add(objData);
            return ListData;
        }

        private EditText EditText1;
        private LinkedButton LinkedButton0;
        private EditText EditText2;
        private StaticText StaticText2;

        private void Grid0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
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
                    rowSelected = EditText2.GetInt();

                    // debo marcar o desmarcar todo
                    Utils.CheckRowsEstadoDespacho(oForm, Grid0, ref rowSelected);

                    // asigno el nro de documentos seleccionados
                    EditText2.SetInt(rowSelected);

                }

                // si hicieron click enun registro valido dentro del Grid
                else if (pVal.ColUID == "Marcar" && pVal.Row > -1)
                {
                    // obtengo los registros seleccionados
                    rowSelected = EditText2.GetInt();

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
                    EditText2.SetInt(rowSelected);

                }
            }

            catch (Exception ex)
            {
                Sb1Messages.ShowError(ex.ToString());
            }
        }
    }
}
