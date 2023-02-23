using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Forxap.Framework.UI;

using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;

namespace Forxap.Framework.Extensions
{
    public static class GridExtensions 
    {


        /// <summary>
        /// asigna el numero de registro dentro del Grid en la primera columna pone la númeracion
        /// verifica ´primero que existan registros
        /// </summary>
        /// <param name="oGrid"></param>
        /// <param name="oForm"></param>
        public static int AssignLineNro(this SAPbouiCOM.Grid oGrid)
        {
            //SAPbouiCOM.Form oForm = oApplication.Forms.ActiveForm;
            int i = 0;

            if (oGrid == null)
                throw new ArgumentNullException("oGrid");

        
            try
            {

                //   oForm.Freeze(true);




                if (!oGrid.DataTable.IsEmpty)
                {

                    for (i = 0; i <= oGrid.DataTable.Rows.Count - 1; i++)
                    {
                        oGrid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
                        oGrid.RowHeaders.SetText(i, (i + 1).ToString());
                      //  oGrid.RowHeaders.Width += 15;
                    }
                    
                }

            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }

            finally
            {
               // oForm.Freeze(false);
            }

            return i + 1;
        }


        /// <summary>
        /// asigna el numero de registro dentro del Grid en la primera columna pone la númeracion
        /// </summary>
        /// <param name="oGrid"></param>
        /// <param name="oForm"></param>
        //public static void AssignLineNro(this SAPbouiCOM.Grid oGrid)
        //{
            

        //    try
        //    {


        //        if (!oGrid.DataTable.IsEmpty)
        //        {

        //            for (int i = 0; i <= oGrid.DataTable.Rows.Count - 1; i++)
        //            {
        //                oGrid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
        //                oGrid.RowHeaders.SetText(i, (i + 1).ToString());
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Forxap.Framework.UI.Messages.ShowError(ex.ToString());
        //    }

        //}

        /// <summary>
        ///  Marca todos los registros como seleccionados
        /// </summary>
        /// <param name="oGrid"></param>
        /// <param name="oForm"></param>
       public static void SetAllCheckBox(this SAPbouiCOM.Grid oGrid, SAPbouiCOM.Form oForm)
       {

           if (oForm == null)
               throw new ArgumentNullException("oForm");

           if (oGrid == null)
               throw new ArgumentNullException("oGrid");


           try
           {

               oForm.Freeze(true);



               for (int i = 0; i < oGrid.Rows.Count; i++)
               {
                   string value = string.Empty;

                   value = oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value.ToString();
                   if ((value == "Y"))
                   {
                       oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value = "N";
                   }
                   else if ((value == "N") || (value == ""))
                   {
                       oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value = "Y";
                   }



               }

               
           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());

           }

           finally
           {
               oForm.Freeze(false);
           }
       }

       public static int GetRowCountSelected(this SAPbouiCOM.Grid oGrid)
       {
           int ret = 0;
           if (oGrid == null)
               throw new ArgumentNullException("oGrid");
           SAPbouiCOM.DataTable data = null;
           try
           {

               Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(true);

               

               for (int i = 0; i < oGrid.DataTable.Rows.Count; i++)
               {
                   string value = string.Empty;

                   value = oGrid.DataTable.Columns.Item(0).Cells.Item(i).Value.ToString();
                   if ((value == "Y"))
                   {
                      ret += 1;
                   }
               
        
               }

                if (ret == 0)
                {
                    Sb1Messages.ShowError(MessageInfo.Message201);
                }
                else
                {
                    Sb1Messages.Clear();
                }

               Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(false);

           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());

           }

           finally
           {
               //  oForm.Freeze(false);
           }

           return ret;
       }
       public static void SetAllCheckBox(this SAPbouiCOM.Grid oGrid)
       {
           if (oGrid == null)
               throw new ArgumentNullException("oGrid");

         
           try
           {

               Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(true);
        


               for (int i = 0; i < oGrid.Rows.Count; i++)
               {
                   string value = string.Empty;

                   value = oGrid.DataTable.Columns.Item("Col1").Cells.Item(i).Value.ToString();
                   if ((value == "Y"))
                   {
                       oGrid.DataTable.Columns.Item("Col1").Cells.Item(i).Value = "N";
                   }
                   else if ((value == "N") || (value == ""))
                   {
                       oGrid.DataTable.Columns.Item("Col1").Cells.Item(i).Value = "Y";
                   }



               }

               Forxap.Framework.Base.oApplication.Forms.ActiveForm.Freeze(false);
        
           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());

           }

           finally
           {
             //  oForm.Freeze(false);
           }
       }


        /// <summary>
        ///  relaciona un campo con algun objeto de sap, para que aparezca la flecha anarrilla
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="oGrid"></param>
        /// <param name="fieldName"></param>
        /// <param name="objectType"></param>
       public static void LinkedObjectType(this SAPbouiCOM.GridColumn gridColumn, SAPbouiCOM.Grid oGrid, object fieldName, string objectType)
       {
           if (gridColumn == null)
               throw new ArgumentNullException("oForm");

           if (oGrid == null)
               throw new ArgumentNullException("oGrid");



           try
           {
               
                //SAPbouiCOM.EditText txtDocEntry = 
           
               //grid.Columns.Item(2).LinkedObjectType(grid,objectType);
               SAPbouiCOM.EditTextColumn oEditCol;

               oEditCol = ((SAPbouiCOM.EditTextColumn)(oGrid.Columns.Item(fieldName)));
               oEditCol.LinkedObjectType = objectType;

           }
           catch 
           {

           }
       }

       public static void ChooseFromList(this SAPbouiCOM.GridColumn gridColumn, SAPbouiCOM.Grid grid, object fieldName, string objectType, string uniqueID,  string alias)
       {
           try
           {

               SAPbouiCOM.ChooseFromListCollection oCFLS;
               oCFLS = Forxap.Framework.UI.App.GetActiveForm().ChooseFromLists;
               SAPbouiCOM.ChooseFromList oCFL;
               SAPbouiCOM.ChooseFromListCreationParams oCFLCRPARAM;
               oCFLCRPARAM = (SAPbouiCOM.ChooseFromListCreationParams)Forxap.Framework.UI.App.oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
               oCFLCRPARAM.MultiSelection = false;
               oCFLCRPARAM.ObjectType = objectType;
               oCFLCRPARAM.UniqueID = uniqueID;

                oCFL = oCFLS.Add(oCFLCRPARAM);

                SAPbouiCOM.EditTextColumn oEditCol;

                oEditCol = ((SAPbouiCOM.EditTextColumn)(grid.Columns.Item(fieldName)));
                oEditCol.ChooseFromListUID = uniqueID;
                oEditCol.ChooseFromListAlias = alias;


           }
           catch
           {

           }
       }


       public static void LinkedObjectTypeEx(this SAPbouiCOM.GridColumn gridColumn, SAPbouiCOM.Grid grid, object fieldName, int rowIndex,string objectType)
       {
           try
           {

               //SAPbouiCOM.EditText txtDocEntry = 

               //grid.Columns.Item(2).LinkedObjectType(grid,objectType);
               SAPbouiCOM.EditTextColumn oEditCol;

               oEditCol = ((SAPbouiCOM.EditTextColumn)(grid.Columns.Item(fieldName)));
               oEditCol.LinkedObjectType = objectType;


               if (objectType == "17")
               {

                   //if (fieldName == "DocNum")
                   //{
                   //    //SAPbouiCOM.EditTextColumn oEditCol2;
                   //    //txtNroPedido.Value = grid.DataTable.GetValue(1, grid.GetDataTableRowIndex(rowIndex)).ToString();
                   //    //lnkSalesQuotation.LinkedObjectType = "17";

                   //    //oEditCol = ((SAPbouiCOM.EditTextColumn)(grid.Columns.Item("DocNum")));
                   //    //oEditCol.LinkedObjectType = string.Empty; // borro el linkedbutton de la columna

                   //    ////hago clic en el linkboton que se encuentra escondido
                   //    //lnkSalesQuotation.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);
                   //}

               }


           }
           catch
           {

           }
       }
 

        /// <summary>
        ///  verifica que el Grid tenga registros
        /// </summary>
        /// <param name="oGrid"></param>
        /// <returns></returns>
       public static bool IsEmpty(this SAPbouiCOM.Grid oGrid)
       {
           bool ret = true;

           if  ( oGrid.Rows.Count > 0)
           {
               ret = false;
           }
            



           return ret;
       }

            
       public static bool GetCellEditable(this  SAPbouiCOM.Grid oGrid, int rowNum, int colNum)
       {
           bool ret = false;
           try
           {
                ret = oGrid.CommonSetting.GetCellEditable(rowNum, colNum);
           }
           catch
           {

           }

           return ret;
       }

       public static void SetRowBackColor(this SAPbouiCOM.Grid oGrid, int rowNum, int rgbColor)
       {
           try
           {
               oGrid.CommonSetting.SetRowBackColor(rowNum, rgbColor);
           }
           catch 
           {
               
           }
           
       }

       public static void   SetCellFontColor(this SAPbouiCOM.Grid oGrid, int rowNum,int colNum, Color color)
       {

            oGrid.CommonSetting.SetCellFontColor( rowNum, colNum, ColorTranslator.ToOle(color));

       }

       public static void SetCellBackColor(this SAPbouiCOM.Grid oGrid,int rowNum, int colNum, Color color )
       {
           try
           {
               oGrid.CommonSetting.SetCellBackColor(rowNum, colNum, ColorTranslator.ToOle(color));

               //oGrid.SetCellFocus()

               //oGrid.CommonSetting.SetRowBackColor
                   
               
           }
           catch (Exception)
           {
               
           }
           

           //oGrid.CommonSetting.

           //oGrid.CommonSetting.SetCellEditable  solo lectura

           //oGrid.CommonSetting.SetRowEditable solo lectura
       }

       public static void SetCellFontStyle(this SAPbouiCOM.Grid oGrid, int rowNum, int colNum, SAPbouiCOM.BoFontStyle fontStyle)
       {
           oGrid.CommonSetting.SetCellFontStyle(rowNum, colNum, fontStyle);
       }
       public static void SetCellEditable(this SAPbouiCOM.Grid oGrid, int rowNum, int colNum, bool enabled)
       {
           oGrid.CommonSetting.SetCellEditable(rowNum,colNum,enabled);
       }

       public static void SetCellEditable(this SAPbouiCOM.Grid oGrid, int rowNum, bool enabled)
       {
           oGrid.CommonSetting.SetRowEditable(rowNum, enabled);
       }



       public static void GetCellBackColor(this SAPbouiCOM.Grid oGrid, int rowNum, int colNum)
       {
           oGrid.CommonSetting.GetCellBackColor(rowNum, colNum);

           
       }


        /// <summary>
        ///  Ir al siguiente Registro
        /// </summary>
        /// <param name="oGrid"></param>
       public static void NextRow(this SAPbouiCOM.Grid oGrid)
       {
           int row = 0;



           while (row < oGrid.Rows.Count)
           { 
               
              if ( oGrid.Rows.IsSelected(row) )
              {
                  if (row < oGrid.Rows.Count-1)
                  oGrid.Rows.SelectedRows.Add(row + 1);
                  return;

               
              }

               row += 1;
           }

       }

        /// <summary>
        /// Ir al Anterior registro
        /// </summary>
        /// <param name="oGrid"></param>
       public static void PrevRow(this SAPbouiCOM.Grid oGrid)
       {
           int row = 0;



           while (row < oGrid.Rows.Count)
           {

               if (oGrid.Rows.IsSelected(row))
               {
                   if (row >= 1)
                   oGrid.Rows.SelectedRows.Add(row - 1);
                   
                   return;

                  
               }

               row += 1;
           }

       }

       public static int  GetColNum( this SAPbouiCOM.Grid oGrid, string uniquedId )
       {
           var columns = oGrid.Columns;
           int indexFound = -1;

           // oMatrix.Columns.Item("ColNumber").Cells.Item(RowNumber).Specific.value.ToString 

           //oGrid.GetDataTableRowIndex(  GetDataTableRowIndex

            //ColorTranslator.ToOle(Color.LightGreen)
           

            for (int j = 0; j < columns.Count; j++)

                {

                    if (columns.Item(j).UniqueID == uniquedId)
    
                        {
                            indexFound = j;

                            break;
                        }
    
                }

            return indexFound;
       }
 

        /// <summary>
        ///  remueve todos los registros de un datatable
        /// </summary>
        /// <param name="oGrid"></param>
        public static void RemoveRows( this SAPbouiCOM.Grid oGrid)
        {

            int rowCount = oGrid.DataTable.Rows.Count;

            if (rowCount > 0)
            {
                oGrid.DataTable.Rows.Clear();
            }
            
        }


        public static void SetWhiteCells(this SAPbouiCOM.Grid oGrid)
        {

            for (int iRow = 1; iRow < oGrid.Rows.Count + 1; iRow++)
            {

                for (int iColumn = 17; iColumn < oGrid.Columns.Count + 1; iColumn++)
                {

                   // if (oGrid.GetCellEditable(iRow, iColumn))
                    oGrid.SetCellEditable(iRow, iColumn, true);
                    oGrid.SetCellBackColor(iRow, iColumn,Color.White);
                }

            }

        }



        public static void DisabledRows(this SAPbouiCOM.Grid oGrid, int row)
        {

            for (int iRow = 0; iRow < oGrid.Rows.Count ; iRow++)
            {

                for (int iColumn = 0; iColumn < oGrid.Columns.Count; iColumn++)
                {
                   oGrid.SetCellEditable(iRow, iColumn, false);
               }

            }

        }


        /// <summary>
        /// crea un campo de tipo combobox
        /// </summary>
        /// <param name="oGridColumns"></param>
        /// <param name="columName"></param>
        /// <param name="lista"></param>
        public static void ComboBox(this SAPbouiCOM.GridColumns oGridColumns, string columName ,Dictionary<string,string>  lista )
        {

            oGridColumns.Item(columName).Type =  SAPbouiCOM.BoGridColumnType.gct_ComboBox;
            SAPbouiCOM.ComboBoxColumn oCombo = (SAPbouiCOM.ComboBoxColumn)oGridColumns.Item(columName);

            oCombo.DisplayType = SAPbouiCOM.BoComboDisplayType.cdt_both;

            foreach (var item in lista)
            {
                oCombo.ValidValues.Add(item.Key, item.Value);
            }



        }


        /// <summary>
        ///  le agrega  a las columnas de un oGrid la característica de permitir
        ///  ordenar de forma ascendente y descendente
        /// </summary>
        /// <param name="oGrid"></param>
        public static void Sortable(this  SAPbouiCOM.Grid oGrid)
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
        ///  le agrega  a las columnas de un oGrid la característica de permitir
        ///  ordenar de forma ascendente y descendente
        /// </summary>
        /// <param name="oGrid"></param>
        public static void ReadOnlyColumns(this SAPbouiCOM.Grid oGrid)
        {
            if (oGrid != null)
            {
                for (int i = 0; i < oGrid.Columns.Count; i++)
                {
                    oGrid.Columns.Item(i).Editable =false;

                    oGrid.Columns.Item(i).TitleObject.Sortable = true;
                }
            }
        }
        public static void ReadOnlyColumnsEx(this SAPbouiCOM.Grid oGrid)
        {
            if (oGrid != null)
            {
                for (int i = 0; i < oGrid.Columns.Count; i++)
                {
                    oGrid.Columns.Item(i).Editable = false;

                    oGrid.Columns.Item(i).TitleObject.Sortable = true;
                }

                oGrid.Columns.Item(0).Editable = true;
            }
        }


        public static void ShowSum(this SAPbouiCOM.GridColumn gridColumn, SAPbouiCOM.Grid grid, object fieldName,string caption )
        {
            SAPbouiCOM.EditTextColumn colSum = (SAPbouiCOM.EditTextColumn)grid.Columns.Item(fieldName);

            

            colSum.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;


            //colSum.GetText();
            //colSum.SetText();


        }
        /// <summary>
        /// selecciona un registro especifico dentro de un grid
        /// </summary>
        /// <param name="selectedRows"></param>
        /// <param name="rowIndex"></param>
        public static void SelectRow(this SAPbouiCOM.SelectedRows selectedRows, int rowIndex)
        {
            selectedRows.Add(rowIndex);
        }

        /// <summary>
        /// selecciona el primer registro especifico dentro de un grid
        /// </summary>
        /// <param name="selectedRows"></param>
        /// <param name="rowIndex"></param>
        public static void SelectFirstRow(this SAPbouiCOM.SelectedRows selectedRows)
        {
            selectedRows.Add(0);
        }


        ///// <summary>
        ///// Campo Combobox con valores definidos en SAP ValidValues
        ///// </summary>
        ///// <param name="oGridColumns"></param>
        ///// <param name="columName"></param>
        //public static void ComboBox(this SAPbouiCOM.GridColumns oGridColumns, string columName)
        //{

        //    oGridColumns.Item(columName).Type = SAPbouiCOM.BoGridColumnType.gct_ComboBox;

        //    SAPbouiCOM.ComboBoxColumn oCombo = (SAPbouiCOM.ComboBoxColumn)oGridColumns.Item(columName);



        //}

    }// fin de la clase
    

}// fin del namespace



//col.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;

//col.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Manual

//Grid0.Columns.Item(10).RightJustified = true;
//SAPbouiCOM.EditTextColumn col2 = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(10);

//col2.ColumnSetting.SumType = SAPbouiCOM.BoColumnSumType.bst_Auto;