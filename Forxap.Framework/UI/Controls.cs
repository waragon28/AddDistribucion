using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forxap.Framework.UI.Utils;

namespace Forxap.Framework.UI.Utils
{
    public static class Controls
    {

        /// <summary>
        ///  le agrega  a las columnas de un oGrid la característica de permitir
        ///  ordenar de forma ascendente y descendente
        /// </summary>
        /// <param name="oGrid"></param>
        public static void Sortable (ref  SAPbouiCOM.Grid oGrid )
        {
            if (oGrid != null)
            {
                for (int i = 0; i < oGrid.Columns.Count; i++)
                {
                    oGrid.Columns.Item(i).TitleObject.Sortable = true;

                    oGrid.Columns.Item(i).TitleObject.Sortable = true;
                }
            }
        }

        /// <summary>
        ///  le agrega  a las columnas de un oMatrix la característica de permitir
        ///  ordenar de forma ascendente y descendente
        /// </summary>
        public static void Sortable(ref  SAPbouiCOM.Matrix oMatrix)
        {
            if (oMatrix != null)
            {
                for (int i = 0; i < oMatrix.Columns.Count; i++)
                {
                    oMatrix.Columns.Item(i).TitleObject.Sortable = true;

                    oMatrix.Columns.Item(i).TitleObject.Sortable = true;
                }
            }
        }


        /// <summary>
        ///  Retorna el valor de una columna y registro especifico, dentro de un matrix
        /// </summary>
        /// <param name="oMatrix"></param>
        /// <param name="colID"></param>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public static string GetMatrixValues(SAPbouiCOM.Matrix oMatrix, string colID,  int rowNumber)
        {
            string ret = string.Empty;
            SAPbouiCOM.EditText editText= null;

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


        public static string GetMatrixValues2(SAPbouiCOM.Matrix oMatrix, string colID, int recordNumber)
        {
            string ret = string.Empty;
            SAPbouiCOM.ComboBox comboBox = null;

            if (oMatrix.RowCount > 0)
            {
                //  object a = oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;





              comboBox =  (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;



                //ret = (oMatrix.Columns.Item(colID).Cells.Item(recordNumber).Specific;


              if (comboBox != null)
                {
                    ret = comboBox.Value.ToString();
                }
            }
            return ret;
        }

       public static void SetMatrixValues(SAPbouiCOM.Matrix oMatrix, string coluid, int row, string newValue)
        {
          // aMatrix.Columns.Item(coluid).Cells.Item(row).Specific = (object) newValue;

            ((SAPbouiCOM.EditText)oMatrix.Columns.Item(coluid).Cells.Item(row).Specific).Value = newValue;

          
       }

       
       public static int GetRowCount(SAPbouiCOM.Matrix oMatrix )
       {
           return oMatrix.RowCount;
       }

        public static void AssignMatrixLineNro(ref SAPbouiCOM.Grid grid)
        {
            if (!grid.DataTable.IsEmpty)
            {

                for (int i = 0; i <= grid.DataTable.Rows.Count - 1; i++)
                {
                    grid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
                    grid.RowHeaders.SetText(i, (i + 1).ToString());
                }
            }
        }


        public static void AssignMatrixLineNro(ref SAPbouiCOM.Matrix oMatrix)
        {
            for (int i = 1; i <  oMatrix.RowCount; i++)
            {
               ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(i).Specific).Value = i.ToString();

            }
            
        }

        public static string GetValueFromEditText(SAPbouiCOM.Form oform, string controlID)
        {
            string ret = string.Empty;

            SAPbouiCOM.EditText oEditText = default(SAPbouiCOM.EditText);
            oEditText = (SAPbouiCOM.EditText)oform.Items.Item(controlID).Specific;

            if (oEditText != null)
            {
                ret = oEditText.Value.ToString().Trim();
            }

            return ret;
        }


        public static void SetEditTextValue(SAPbouiCOM.Form oForm, string controlID, string value)
        {
            SAPbouiCOM.EditText oEditText = default(SAPbouiCOM.EditText);
            oEditText = (SAPbouiCOM.EditText)oForm.Items.Item(controlID).Specific;

            if (oEditText != null)
            {
                oEditText.String = value;
            }
        }

        public static string GetDescriptionFromComboBox(SAPbouiCOM.Form oForm, string controlID)
        {
            string ret = string.Empty;

            SAPbouiCOM.ComboBox oComboBox = default(SAPbouiCOM.ComboBox);
            oComboBox = (SAPbouiCOM.ComboBox)oForm.Items.Item(controlID).Specific;

            if (oComboBox.Selected != null)
            {
                ret = oComboBox.Selected.Description.Trim();
            }
            return ret;
        }

        public static string GetValueFromComboBox(SAPbouiCOM.Form oForm, string controlID)
        {
            string ret =  string.Empty;

            SAPbouiCOM.ComboBox oComboBox = default(SAPbouiCOM.ComboBox);
            oComboBox = (SAPbouiCOM.ComboBox)oForm.Items.Item(controlID).Specific;

            if (oComboBox.Selected != null)
            {
                ret = oComboBox.Selected.Value.Trim();
            }
            return ret;
        }

        public static void SetValuetoComboBox(SAPbouiCOM.Form oForm, ref SAPbouiCOM.ComboBox combobox, SAPbobsCOM.Recordset oRecorset )
        {
          

            
            while (!oRecorset.EoF)
            {
                
            }
	         
	

        }



        public static void setlabeltextvalue(SAPbouiCOM.Form oForm, string controlID, string value)
        {
            SAPbouiCOM.StaticText oStaticText = default(SAPbouiCOM.StaticText);
            oStaticText = (SAPbouiCOM.StaticText)oForm.Items.Item(controlID).Specific;
            
            if (oStaticText != null)
            {
                oStaticText.Caption =  value;
            }
            
        }


        public static void AssignMatrixLineNro(ref SAPbouiCOM.Grid oGrid, SAPbouiCOM.Form oForm)
        {
            oForm.Freeze(true);
            try
            {
                for (int intNo = 0; intNo <= oGrid.DataTable.Rows.Count - 1; intNo++)
                {
                    oGrid.RowHeaders.SetText(intNo, (intNo + 1).ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oGrid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
            oForm.Freeze(false);
        }


        public static void AssignMatrixLineNro(string controlID, SAPbouiCOM.Form oForm)
        {

            //SAPbouiCOM.Grid oGrid = oForm.Items() SAPbouiCOM.ComboBox oComboBox = default(SAPbouiCOM.ComboBox);

            SAPbouiCOM.Grid oGrid = default(SAPbouiCOM.Grid);

            oGrid = (SAPbouiCOM.Grid)oForm.Items.Item(controlID).Specific;


            oForm.Freeze(true);
            try
            {
                for (int intNo = 0; intNo <= oGrid.DataTable.Rows.Count - 1; intNo++)
                {
                    oGrid.RowHeaders.SetText(intNo, (intNo + 1).ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            oGrid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
            oForm.Freeze(false);
        }



        /// <summary>
        ///  realiza un seleccionado (chekcBox) a todos los registros de un grid
        /// </summary>
        /// <param name="oGrid"></param>
        public static void SetAllCheckBox(ref SAPbouiCOM.Grid oGrid, SAPbouiCOM.Form oForm )
        {
            try
            {

                oForm.Freeze(true);

                

                for (int i = 0; i < oGrid.Rows.Count; i++)
                {
                    string value = string.Empty;

                    value = oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value.ToString();
                    if ((value == "Y") )
                    {
                        oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value = "N";
                    }
                    else if ((value == "N") || (value == ""))
                    {
                        oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value = "Y";
                    }



                }

                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());

            }
        }


        //public static void AssignMatrixLineNro(ref SAPbouiCOM.Grid grid)
        //{

        //    for (int i = 0; i <= grid.DataTable.Rows.Count; i++)
        //    {
        //        grid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
        //        grid.RowHeaders.SetText(i, (i + 1).ToString());
        //    }
        //}


        

    }// fin de la clase

}// fin del namespace
