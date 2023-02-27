//#define AD_BO
//#define AD_PE
//#define AD_MA
//#define AD_ES
//#define AD_CL
#define AD_PY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using SAPbouiCOM;
using Forxap.Framework.UI;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.BLL;
using SAPbobsCOM;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;

namespace Vistony.Distribucion.Win.Mantenimiento
{
    [FormAttribute("FrmActIMEI", "Mantenimiento/FrmActualizarIMEI.b1f")]
    class FrmActualizarIMEI : UserFormBase
    {
        public FrmActualizarIMEI()
        {
        }
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText0;
        private EditText EditText5;
        private EditText EditText6;
        private SAPbouiCOM.Form oForm;
        string Sucursales = Sb1Globals.Sucursal;
        EntregaBLL entregaBLL = new EntregaBLL();
        Recordset recordset;
        AddonMessageInfo addonMessageInfo = new AddonMessageInfo();
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_11").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_6").Specific));
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
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
#if AD_PE
                if (Sb1Globals.AdminPuntoEmision=="1")
                {
                StaticText1.Item.Visible = true;
                ComboBox0.Item.Visible = true;
                ComboBox0.Item.DisplayDesc = true;
                Utils.LoadQuerySucursales(ref ComboBox0, string.Format(addonMessageInfo.QueryComboBoxSucursales,Sb1Globals.UserSignature));
              
                ComboBox0.Select(Sb1Globals.SucursalDefault, SAPbouiCOM.BoSearchKey.psk_ByDescription);
                Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox0.GetSelectedDescription()));
                ChooseFromList_Choferes("CFL_0", "position", "73", "branch",Sb1Globals.IDSucursal);
            }
                else
                {
                StaticText1.Item.Visible = false;
                    ComboBox0.Item.Visible = false;
                } 
#endif

            ChooseFromList_Choferes("CFL_0", "position","73", "branch", Sucursales);
        }

        /*
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            cfl.SetConditions(null);
           Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox0.GetSelectedDescription()));
                ChooseFromList_Choferes("CFL_0", "position", "73", "branch",Sb1Globals.IDSucursal);

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
        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText0.Value = chooseFromListEvent.SelectedObjects.GetValue("empID", 0).ToString();
                        EditText4.Value = chooseFromListEvent.SelectedObjects.GetValue("U_VIS_Imei", 0).ToString();
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("lastName", 0). ToString() + " " +
                                          chooseFromListEvent.SelectedObjects.GetValue("firstName", 0).ToString() + "" +
                                          chooseFromListEvent.SelectedObjects.GetValue("middleName", 0).ToString();
                        Button1.Caption = "Actualizar";
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }
        public void ChooseFromList_Choferes(string CFL_, string Campo1, string condicion1, string Campo2, string condicion2)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item(CFL_);
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = Campo1;
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = condicion1;
            con.Relationship = BoConditionRelationship.cr_AND;
            con = cons.Add();
            con.Alias = Campo2;
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = condicion2;
            cfl.SetConditions(cons);
        }
        private void Button2_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            oForm.Close();
        }
        private void Button1_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            if (Button1.Caption == "Actualizar")
            {
                string response = "";

                if (EditText4.Value.Length == 15)
                {
                    recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    if (entregaBLL.ValidarIMEI(EditText4.Value, recordset, EditText5, EditText6) == true)
                    {
                        var Respuesta = Sb1Messages.ShowQuestion(addonMessageInfo.MessageIdiomaMessage332(Sb1Globals.Idioma));
                        if (Respuesta)
                        {
                            Sb1Messages.ShowWarning(addonMessageInfo.MessageIdiomaMessage334(Sb1Globals.Idioma));

                            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                            entregaBLL.GetEmplIMEI(EditText4.Value, oDT);
                            for (int oRows = 0; oRows < oDT.Rows.Count; oRows++)
                            {
                                Choferes objChoferes = new Choferes();
                                objChoferes = GetObjChoferes(Convert.ToInt32(oDT.GetValue("empID", oRows).ToString()), "");
                                dynamic GetObjJsonChoferes = JsonConvert.SerializeObject(objChoferes);
                                entregaBLL.UpdateIMEI(Convert.ToInt32(oDT.GetValue("empID", oRows).ToString()), GetObjJsonChoferes, ref response);
                            }

                            Choferes objChoferes1 = new Choferes();
                            objChoferes1 = GetObjChoferes(EditText0.GetInt(), EditText4.Value);
                            dynamic GetObjJsonChoferes1 = JsonConvert.SerializeObject(objChoferes1);
                            entregaBLL.UpdateIMEI(EditText0.GetInt(), GetObjJsonChoferes1, ref response);
                            if (response == "OK")
                            {
                                Sb1Messages.ShowSuccess(addonMessageInfo.MessageIdiomaMessage333(Sb1Globals.Idioma));
                                Button1.Caption = "OK";
                            }
                        }


                    }
                    else
                    {
                        Choferes objChoferes = new Choferes();
                        objChoferes = GetObjChoferes(EditText0.GetInt(), EditText4.Value);
                        dynamic GetObjJsonChoferes = JsonConvert.SerializeObject(objChoferes);

                        entregaBLL.UpdateIMEI(EditText0.GetInt(), GetObjJsonChoferes, ref response);
                        if (response == "OK")
                        {
                            Sb1Messages.ShowSuccess(addonMessageInfo.MessageIdiomaMessage333(Sb1Globals.Idioma));
                            Button1.Caption = "OK";
                        }
                    }

                }
                else
                {
                    Sb1Messages.ShowError(addonMessageInfo.MessageIdiomaMessage331(Sb1Globals.Idioma));
                }
            }
            else
	        {
                oForm.Close();
            }
        }
        private Choferes GetObjChoferes(int EmployeeID, string U_VIS_Imei)
        {
            Choferes objChofer = new Choferes();
            objChofer.EmployeeID = EmployeeID;
            objChofer.U_VIS_Imei = U_VIS_Imei;

            return objChofer;

        }
        private void Button0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
        }

        private StaticText StaticText1;
        private ComboBox ComboBox0;

        private void ComboBox0_ClickAfter(object sboObject, SBOItemEventArg pVal)
        {
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item("CFL_0");
            cfl.SetConditions(null);
            Sb1Globals.IDSucursal = Utils.GetIDSucursal(string.Format(addonMessageInfo.QueryGetIDSucursal, ComboBox0.GetSelectedDescription()));
            ChooseFromList_Choferes("CFL_0", "position", "73", "branch", Sb1Globals.IDSucursal);
        }
    }
}
