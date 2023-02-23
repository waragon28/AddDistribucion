using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbouiCOM;
using SAPbobsCOM;

namespace Forxap.Framework.Extensions
{
   public static class ComboBoxExtensions
    {


       public static void Clear(this ComboBox comboBox)
        {
            comboBox.Select("", SAPbouiCOM.BoSearchKey.psk_Index);
        }
       public static void SetFocus(this ComboBox comboBox)
        {
            comboBox.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }

        public static void SetFocusEx(this ComboBox comboBox)
        {
            comboBox.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }
        public static Recordset AddValuesFromRecordset(this SAPbouiCOM.ComboBox oComboBox, Recordset oRecordset, string fieldValue = null,
                                             string fieldDescription = null)
        {
            if (oComboBox == null) 
                throw new ArgumentNullException("comboBox");
            if (oRecordset == null) 
                throw new ArgumentNullException("recordset");

            oRecordset.MoveFirst();

            if (fieldDescription == null)
            {
                if (fieldValue == null)
                {
                    var fields = oRecordset.Fields;

                    if (fields.Count > 1)
                    {
                        fieldValue = fields.Item(0).Name;
                        fieldDescription = fields.Item(1).Name;
                    }
                    else
                    {
                        fieldValue = fieldDescription = fields.Item(0).Name;
                    }
                }
                else
                {
                    var fields = oRecordset.Fields;

                    if (fields.Count > 1)
                    {
                        fieldDescription = fields.Item(0).Name == fieldValue ? fields.Item(1).Name : fields.Item(0).Name;
                    }
                    else
                    {
                        fieldDescription = fieldValue;
                    }
                }
            }


            //var validValues = comboBox.ValidValues;

            //while (!recordset.EoF)
            //{
            //    var value = recordset.Fields.Item(fieldValue);
            //    var description = recordset.Fields.Item(fieldDescription);

            //    validValues.Add(value.Value.ToString(), description.Value.ToString());

            //    recordset.MoveNext();
            //}

            return oRecordset;
        }


        //public static void AddValuesFromQuery(this SAPbouiCOM.ComboBox oComboBox, string query, bool firstRowEmpty)
        //{
        //    if (oComboBox == null) throw new ArgumentNullException("comboBox");
        //    if (string.IsNullOrEmpty(query))  throw new ArgumentNullException("query");


        //    oRecordset = (SAPbobsCOM.Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);


        //    oRecordset.MoveFirst();

        //    if (fieldDescription == null)
        //    {
        //        if (fieldValue == null)
        //        {
        //            var fields = oRecordset.Fields;

        //            if (fields.Count > 1)
        //            {
        //                fieldValue = fields.Item(0).Name;
        //                fieldDescription = fields.Item(1).Name;
        //            }
        //            else
        //            {
        //                fieldValue = fieldDescription = fields.Item(0).Name;
        //            }
        //        }
        //        else
        //        {
        //            var fields = oRecordset.Fields;

        //            if (fields.Count > 1)
        //            {
        //                fieldDescription = fields.Item(0).Name == fieldValue ? fields.Item(1).Name : fields.Item(0).Name;
        //            }
        //            else
        //            {
        //                fieldDescription = fieldValue;
        //            }
        //        }
        //    }


        //    //var validValues = comboBox.ValidValues;

        //    //while (!recordset.EoF)
        //    //{
        //    //    var value = recordset.Fields.Item(fieldValue);
        //    //    var description = recordset.Fields.Item(fieldDescription);

        //    //    validValues.Add(value.Value.ToString(), description.Value.ToString());

        //    //    recordset.MoveNext();
        //    //}

        //    return oRecordset;
        //}

       public static Recordset AddValuesFromRecordset(this SAPbouiCOM.ComboBox oComboBox, Recordset oRecordset,  bool firstRowEmpty, string fieldValue = null,
                                             string fieldDescription = null)
        {
            if (oComboBox == null) throw new ArgumentNullException("comboBox");
            if (oRecordset == null) throw new ArgumentNullException("recordset");


            if ( firstRowEmpty == true)
            {
                oComboBox.ValidValues.Add(" ", "  ");
            }

            oRecordset.MoveFirst();

            if (fieldDescription == null)
            {
                if (fieldValue == null)
                {
                    var fields = oRecordset.Fields;

                    if (fields.Count > 1)
                    {
                        fieldValue = fields.Item(0).Name;
                        fieldDescription = fields.Item(1).Name;
                    }
                    else
                    {
                        fieldValue = fieldDescription = fields.Item(0).Name;
                    }
                }
                else
                {
                    var fields = oRecordset.Fields;

                    if (fields.Count > 1)
                    {
                        fieldDescription = fields.Item(0).Name == fieldValue ? fields.Item(1).Name : fields.Item(0).Name;
                    }
                    else
                    {
                        fieldDescription = fieldValue;
                    }
                }
            }


            //var validValues = comboBox.ValidValues;

            //while (!recordset.EoF)
            //{
            //    var value = recordset.Fields.Item(fieldValue);
            //    var description = recordset.Fields.Item(fieldDescription);

            //    validValues.Add(value.Value.ToString(), description.Value.ToString());

            //    recordset.MoveNext();
            //}

            return oRecordset;
        }

        public static string GetSelectedDescription(this SAPbouiCOM.ComboBox oComboBox)
        {
            string ret = string.Empty;

            try
            {
                if ((((oComboBox.ValidValues.Count > 0) && ((oComboBox.Selected != null))) && (oComboBox.Selected.Value != string.Empty)))
                {
                    ret = oComboBox.Selected.Description.Trim();

                    

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        

            return ret;
        }


        public static string GetSelectedValue(this SAPbouiCOM.ComboBox oComboBox)
        {
            string ret = string.Empty;

            try
            {
                if ((((oComboBox.ValidValues.Count > 0) && ((oComboBox.Selected != null))) && (oComboBox.Selected.Value != string.Empty)))
                {
                    ret = oComboBox.Selected.Value.Trim();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ret;
        }



        public static string GetValue(this SAPbouiCOM.ComboBox oComboBox)
        {
            string ret = string.Empty;

            try
            {
                if ((((oComboBox.ValidValues.Count > 0) && ((oComboBox.Selected != null))) && (oComboBox.Selected.Value != string.Empty)))
                {
                    ret = oComboBox.Value.Trim();

                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ret;
        }



        public static bool RemoveValidValues(this SAPbouiCOM.ComboBox oComboBox)
        {

            bool ret = false;
            try
            {
                while (oComboBox.ValidValues.Count > 0)
                {
                    oComboBox.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
                }
                ret = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }



    }// fin de la clase




}// fin del namespace
