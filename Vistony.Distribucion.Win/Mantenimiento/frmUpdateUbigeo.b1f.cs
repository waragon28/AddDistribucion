using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.BLL;
using Newtonsoft.Json;
using Vistony.Distribucion.BO;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("Vistony.Distribucion.Win.UltimaMilla.frmUpdateUbigeo", "Mantenimiento/frmUpdateUbigeo.b1f")]
    class frmUpdateUbigeo : UserFormBase
    {
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button Button0;
        EntregaBLL entregaBLL = new EntregaBLL();
        string Sucursal = Sb1Globals.Sucursal;
        public frmUpdateUbigeo()
        {
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            entregaBLL.BuscarChoferesUbigeo(oForm,Matrix0, Sucursal);
            Matrix0.AutoResizeColumns();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_0").Specific));
            this.Matrix0.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix0_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
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
            Matrix0.AutoResizeColumns();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // for (int oMatrixRow = 0; oMatrixRow < Matrix0.RowCount; oMatrixRow++)
           // {
                UbigeoChofer ActualizarUbigeoChoferObj = new UbigeoChofer();
                ActualizarUbigeoChoferObj = ActualizarUbigeoChoferCabecera(Matrix0.GetValueFromEditText("Col_2", Position));
                dynamic jsonDataUpdate = JsonConvert.SerializeObject(ActualizarUbigeoChoferObj);
                UpdateUBIGEOCHOFER(Code, jsonDataUpdate);
           // }

        }

        private UbigeoChofer ActualizarUbigeoChoferCabecera(string U_VIS_CodUbigeo)
        {
            UbigeoChofer ActualizarUbigeoChoferobj = new UbigeoChofer();
            ActualizarUbigeoChoferobj.U_VIS_CodUbigeo = U_VIS_CodUbigeo;

            return ActualizarUbigeoChoferobj;
        }

        public void UpdateUBIGEOCHOFER(string docEntry, dynamic jsonData)
        {
            //  bool ret = false;
            try
            {
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;
                restResponse = methods.PATCH("VIST_UBIGEOCHOFER",docEntry, jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    //  response = "OK";
                    //ret = true;
                }
                else
                {
                    // response = restResponse.Content.ToString();
                    // ret = true;
                }
                // return ret;
            }
            catch (Exception )
            {
                // response = ex.ToString();
                // ret = false;
            }

        }
        string Code;
        int Position;
        private void Matrix0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.Row>0)
            {
                Position = pVal.Row;
                Code = Matrix0.GetValueFromEditText("Col_0", Position);
            }
            
        }
    }
}
