using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;
using Vistony.Distribucion.Constans;
using Forxap.Framework.UI;

namespace Vistony.Distribucion.Win.Mantenimiento
{
    [FormAttribute("dis_PuntoEmiUsu", "Mantenimiento/FrmPuntoEmisionUsuario.b1f")]
    class FrmPuntoEmisionUsuario : UserFormBase
    {
        public FrmPuntoEmisionUsuario()
        {
        }
        private static SAPbouiCOM.Form oForm;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_7").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.OnCustomInitialize();

        }

        public static void MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            oForm.GetMatrix("Item_7").AssignLineNro();

            // Menu Agregar Linea en el matrix
            if (pVal.MenuUID == SboMenuItem.AddRow && pVal.BeforeAction == true)
            {
                AddRow();
                BubbleEvent = true;

            }
            // Menu eliminar linea en el matrix
            if (pVal.MenuUID == SboMenuItem.DeleteRow && pVal.BeforeAction == true)
            {

                DeleteRow();
                BubbleEvent = true;

            }
            if (pVal.MenuUID == SboMenuItem.Delete)
            {
                BubbleEvent = false;
                Sb1Messages.ShowError("No puede Eliminar el Registro");
            }

        }
        private static void AddRow()
        {
            // accedo al matrix
            SAPbouiCOM.Matrix oMatrix = oForm.GetMatrix("Item_7");
            // accedo al datasource del formulario 
            SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource(AddonUserTables.Tabla_VIS_EMI_OUSR_D);

            int rowCount;

            rowCount = oDatasource.Offset;

            rowCount = rowCount + 1;

            oDatasource.InsertRecord(oDatasource.Size);
            oDatasource.Offset = oDatasource.Size - 1;
            oMatrix.AddRow(1, rowCount);

            //    oMatrix.SetFocusNewRow();
            oMatrix.AssignLineNro();


        }
        private static void DeleteRow()
        {

            //SAPbouiCOM.Matrix oMatrix = oForm.GetMatrix("Item_7");
            //SAPbouiCOM.DBDataSource oDataSource = oForm.GetDBDataSource(AddonUserTables.TrasvaseArticulo1);
            //int count = 0;
            //int offset = 0;

            //oMatrix.FlushToDataSource();

            //oDataSource.RemoveRecord(1);

            // count = oDataSource.Size;
            // offset = oDataSource.Offset;




        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
           
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.EnabledMenuMatrix();
            Matrix0.AddRow(1);
            Matrix0.AssignLineNro();
            Matrix0.AutoResizeColumns();
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Matrix Matrix0;

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        //EditText0.Value = chooseFromListEvent.SelectedObjects.GetValue("USER_CODE", 0).ToString();
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("U_NAME", 0).ToString();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText1;
    }
}
