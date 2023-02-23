using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbouiCOM;

namespace Forxap.Framework.Extensions
{
    public static class MatrixExtensions
    {





        public static void RemoveColumns(this  SAPbouiCOM.Matrix oMatrix)
        {
           
            int rowCount =  (oMatrix.Columns.Count -1);

          

            /// borro las columnas del matrix
            for (int i = rowCount; i > 0; i--)
            {
                oMatrix.Columns.Remove(i);
            }


       

        }

        
        public static void ReadOnly(this  SAPbouiCOM.Matrix oMatrix ,bool readOnly)
        {

            int rowCount = (oMatrix.Columns.Count - 1);



            /// borro las columnas del matrix
            for (int i = rowCount; i > 0; i--)
            {
                oMatrix.Columns.Item(i).Editable = !readOnly;
            }


           
       

        }

        public static void AssignLineNro(this SAPbouiCOM.Matrix oMatrix)
        {
            SAPbouiCOM.EditText oEdit;
            if (oMatrix != null)
            {

                try
                {



                    for (int j = 1; j <= oMatrix.RowCount; j++)
                    {
                        oEdit = (SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(j).Specific;
                        oEdit.Value = j.ToString();
                    }
                }
                catch (Exception EX)
                {

                 
                }
            }
        }

        public static void AssignLineNroEx(this SAPbouiCOM.Matrix oMatrix)
        {
          

            if (oMatrix != null)
            {

                try
                {
                    oMatrix.FlushToDataSource();

                    string datasource = oMatrix.Columns.Item(1).DataBind.TableName;

                    SAPbouiCOM.DBDataSource oDataSource = Forxap.Framework.Base.oApplication.Forms.ActiveForm.GetDBDataSource(datasource);
                    

                    for (int j = 1; j <= oDataSource.Size; j++)
                    {
                        oDataSource.SetValue("LineId",j-1 ,j.ToString());
                    }

                    oMatrix.LoadFromDataSourceEx();
        

                }
                catch (Exception EX)
                {


                }
            }
        }



        public static double GetPriceFromEditText(this SAPbouiCOM.Matrix oMatrix, string colID, int rowNumber)
        {
            double ret = 0;
            SAPbouiCOM.EditText editText = null;



            if (oMatrix.RowCount > 0)
            {
                //  object a = oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


                editText = (SAPbouiCOM.EditText)oMatrix.Columns.Item(colID).Cells.Item(rowNumber).Specific;



                //ret = (oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


                if ( editText != null)
                {
                     if ( !string.IsNullOrEmpty(editText.Value) )
                    ret = Convert.ToDouble(editText.Value);
                }
            }
            return ret;
        }
        public static string GetValueFromEditText(this SAPbouiCOM.Matrix oMatrix, string colID, int rowNumber)
        {
            string ret = string.Empty;
            SAPbouiCOM.EditText editText = null;

            

            if (oMatrix.RowCount > 0)
            {
                //  object a = oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


                editText = (SAPbouiCOM.EditText)oMatrix.Columns.Item(colID).Cells.Item(rowNumber).Specific;



                //ret = (oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


                if (editText != null)
                {
                    ret = editText.Value.ToString();
                }
            }
            return ret;
        }

        public static int GetSelectedRow(this SAPbouiCOM.Matrix oMatrix)
        {
            int row = 0;
            row = oMatrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

          return ( row -1 );

        }

        public static void DeleteRow(this SAPbouiCOM.Matrix oMatrix)
        {
            Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(true);

            string datasource = oMatrix.Columns.Item(1).DataBind.TableName;
            bool isRowSelected = false;
          
            oMatrix.FlushToDataSource();// mando los datos al datasource
            SAPbouiCOM.DBDataSource oDataSource = Forxap.Framework.Base.oApplication.Forms.ActiveForm.GetDBDataSource(datasource);

          
            for (int rowIndex = 1; rowIndex < oMatrix.RowCount; rowIndex++)
            {
                 if( oMatrix.IsRowSelected(rowIndex) )
                 {
                     isRowSelected = true;
                    // oMatrix.DeleteRow(rowIndex);
                     oDataSource.RemoveRecord(rowIndex - 1);// elimino en el datasoirce
                 }
                 
            }
        
          


            oMatrix.LoadFromDataSource();
            oMatrix.AssignLineNroEx();

            Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(false);

        }
        public static string GetValueFromComboBox(this SAPbouiCOM.Matrix oMatrix, string colID, int rowNumber)
        {
            string ret = string.Empty;
            SAPbouiCOM.ComboBox comboBox = null;

            if (oMatrix.RowCount > 0)
            {
                //  object a = oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;





                comboBox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(colID).Cells.Item(rowNumber).Specific;



           

                if (comboBox != null)
                {
                    ret = comboBox.Value.ToString();
                }
            }
            return ret;
        }

        public static string GetDescriptionFromComboBox(this SAPbouiCOM.Matrix oMatrix, string colID, int rowNumber)
        {
            string ret = string.Empty;
            SAPbouiCOM.ComboBox comboBox = null;

            if (oMatrix.RowCount > 0)
            {
             

                comboBox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(colID).Cells.Item(rowNumber).Specific;



                //ret = (oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


                if (comboBox != null)
                {
                    ret = comboBox.GetSelectedDescription();
                }
            }
            return ret;
        }


        /// <summary>
        ///  relaciona un campo con algun objeto de sap, para que aparezca la flecha anarrilla
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="oMatrix"></param>
        /// <param name="fieldName"></param>
        /// <param name="objectType"></param>
        public static void LinkedObjectType(this SAPbouiCOM.Column  gridColumn, SAPbouiCOM.Matrix  oMatrix, object fieldName, string objectType)
        {
            try
            {

                //SAPbouiCOM.EditText txtDocEntry = 

                //grid.Columns.Item(2).LinkedObjectType(grid,objectType);
         ///       SAPbouiCOM.EditTextColumn oEditCol;

         ///       oEditCol = ((SAPbouiCOM.EditTextColumn)(grid.Columns.Item(fieldName)));
         ///       oEditCol.LinkedObjectType = objectType;

            //       Dim oLinkColumn As SAPbouiCOM.LinkedButton = oForm.Items.Item("myMatrix").Specific.Columns.Item("lbColumn")
            //oLinkColumn.LinkedObject = BoLinkedObject.lf_Quotation

              //  LinkedButton oLinkLns = ((SAPbouiCOM.LinkedButton)(oMatrix.Columns.Item(fieldName)));
              //  oLinkLns.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_BusinessPartner;

                //SAPbouiCOM.Column oColumn =  .Add("DBS_Col1", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);


                SAPbouiCOM.EditTextColumn oEditCol;
                SAPbouiCOM.Column oColumn;
                SAPbouiCOM.EditText oEdit;

                oColumn = ((SAPbouiCOM.Column)(oMatrix.Columns.Item(fieldName)));
                oColumn.LinkedObjectType(oMatrix,fieldName, objectType);


                //SAPbouiCOM.LinkedButton oLink = (SAPbouiCOM.LinkedButton)oMatrix.Columns.Item(fieldName).ExtendedObject;
                //oLink.LinkedObject = SAPbouiCOM.BoLinkedObject.lf_BusinessPartner;

            }
            catch (Exception ex)
            {

            }
        }

        public static void Focus(this SAPbouiCOM.Matrix oMatrix, int column, int rowIndex)
        {

            oMatrix.Columns.Item(column).Cells.Item(rowIndex).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }

        public static void ClickAddRow(this SAPbouiCOM.Matrix oMatrix)
        {
            int count = 0;

            count = oMatrix.RowCount + 1;
          
            oMatrix.Columns.Item(1).Cells.Item(count).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }

        public static void SetFocusNewRow(this SAPbouiCOM.Matrix oMatrix)
        {
            int count = 0;

            count = oMatrix.RowCount + 1;

            oMatrix.Columns.Item(1).Cells.Item(count).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }

    }// fin de la clase

}// fin del namespace
