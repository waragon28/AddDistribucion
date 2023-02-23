using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM;
//using System.Windows.Forms;

using  Forxap.Framework.DI;

namespace Forxap.Framework.Extensions
{
    public static class FormExtensions 
    {

        public static UserDataSource GetUserDataSource(this IForm oForm, string userDataSource)
        {
            if (oForm == null)
                throw new ArgumentNullException("UserDataSources");

            if (string.IsNullOrEmpty(userDataSource))
                throw new ArgumentException("No puede ser nulo o vacio.");


            return oForm.DataSources.UserDataSources.Item(userDataSource);
        }
        public static DBDataSource  GetDBDataSource(this IForm oForm,string dbDataSource)
        {
            if (oForm == null)
                throw new ArgumentNullException("dbDataSources");

            if (string.IsNullOrEmpty(dbDataSource))
                throw new ArgumentException("No puede ser nulo o vacio.");


            return oForm.DataSources.DBDataSources.Item(dbDataSource);
        }

        public static DataTable GetDataTable(this IForm oForm, string dataTable)
        {
            if (oForm == null)
                throw new ArgumentNullException("dataTable");

            if (string.IsNullOrEmpty(dataTable))
                throw new ArgumentException("No puede ser nulo o vacio.");


            return oForm.DataSources.DataTables.Item(dataTable);
        }

        /// <summary>
        /// Get Static Text
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static StaticText GetStaticText(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as StaticText;
        }


        /// <summary>
        /// Get Combo Box
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static ComboBox GetComboBox(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as ComboBox;
        }



        /// <summary>
        /// Get Button
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static Button GetButton(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as Button;
        }


        /// <summary>
        /// Get Edit Text
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static EditText GetEditText(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as EditText;
        }

        public static string GetString(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return (oForm.Items.Item(itemId).Specific as EditText).Value.ToString().Trim() ;
        }
        
        public static void SetEditText(this IForm oForm, string itemId, string value, bool enabled = true )
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");


            try
            {


                // return oForm.Items.Item(itemId).Specific as EditText;
                EditText editText = oForm.Items.Item(itemId).Specific as EditText;
                editText.SetValue(value);

                //Form.Items. .Item("1").Click(BoCellClickType. .ct_Regular);
                
                
                editText.Item.Enabled = enabled;

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void EnabledItem(this IForm oForm, string itemId, bool value)
        {

            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            
            try
            {


                oForm.Items.Item(itemId).Enabled = value;               

               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SetFocus(this IForm oForm, string itemId)
        {

            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");


            try
            {
                oForm.Items.Item(itemId).Click(BoCellClickType.ct_Regular);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void EnabledMenuMatrix(this IForm oForm)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");


            try
            {
                
                oForm.EnableMenu(Forxap.Framework.Constants.SboMenuItem.AddRow,true);
                oForm.EnableMenu(Forxap.Framework.Constants.SboMenuItem.DeleteRow, true);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SetEnabled(this IForm oForm, string itemId, bool value)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");


            try
            {
                oForm.Items.Item(itemId).Enabled = value;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Check Box
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static CheckBox GetCheckBox(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as CheckBox;
        }

        public static Folder GetFolder(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as Folder;

        }


        /// <summary>
        /// Get Matrix
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static Matrix GetMatrix(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");

            return oForm.Items.Item(itemId).Specific as Matrix;
        }

        /// <summary>
        /// Get Grid
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static Grid GetGrid(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");


            return oForm.Items.Item(itemId).Specific as Grid;
        }


     
        public static void DataTable(this IForm oForm,  string dataTableName)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(dataTableName))
                throw new ArgumentNullException("No puede ser nulo o vacio.");


            try
            {
                oForm.DataSources.DataTables.Add(dataTableName);

            }
            catch
            {

            }

         
        }


        public static void AddChooseFromList(this IForm oForm, SAPbouiCOM.Application SBOApp, string objectType, string cflName, string oCFLAlias)
        {

            SAPbouiCOM.ChooseFromListCollection oChooseFromListCollection;
            oChooseFromListCollection = oForm.ChooseFromLists;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.ChooseFromListCreationParams oCFLCRPARAM;
            oCFLCRPARAM = (SAPbouiCOM.ChooseFromListCreationParams)SBOApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
            oCFLCRPARAM.MultiSelection = false;
            oCFLCRPARAM.ObjectType = objectType;
            oCFLCRPARAM.UniqueID = cflName;

            try
            {
                oChooseFromList = oChooseFromListCollection.Add(oCFLCRPARAM);
            }
            catch
            {
 
            }

            //oTextBox.ChooseFromListUID = oCFLName;
            //oTextBox.ChooseFromListAlias = oCFLAlias;
        }


        public static void AddChooseFromList(this IForm oForm, SAPbouiCOM.Application SBOApp, string objectType, string cflName, string oCFLAlias, SAPbouiCOM.EditText oTextBox)
        {

            

            SAPbouiCOM.ChooseFromListCollection oChooseFromListCollection;
            oChooseFromListCollection = oForm.ChooseFromLists;
            SAPbouiCOM.ChooseFromList oChooseFromList;
            SAPbouiCOM.ChooseFromListCreationParams oCflParams;
            oCflParams = (SAPbouiCOM.ChooseFromListCreationParams)SBOApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
            oCflParams.MultiSelection = false;
            oCflParams.ObjectType = objectType;
            oCflParams.UniqueID = cflName;

            

            try
            {
                oChooseFromList = oChooseFromListCollection.Add(oCflParams);
            }
            catch (Exception )
            {
                throw;
            }

            oTextBox.ChooseFromListUID = cflName;
            oTextBox.ChooseFromListAlias = oCFLAlias;
        }


        public static void AddCFL(this IForm oForm, SAPbouiCOM.Application SBOApp, string oObjType, string oCFLName, string oCFLAlias, SAPbouiCOM.EditText oTextBox)
        {
            SAPbouiCOM.ChooseFromListCollection oCFLS;
            oCFLS = oForm.ChooseFromLists;
            bool exist = false;


            foreach (var item in oCFLS)
            {
                 if ( item.ToString() == oCFLName)
                {
                    exist = true;
                }
            }

             

            if (exist )
                {
                    return;
                }

            // si no existe el CFL entonces lo agrego
            
            
            SAPbouiCOM.ChooseFromList oCFL;
            SAPbouiCOM.ChooseFromListCreationParams oCFLCRPARAM;
            oCFLCRPARAM = (SAPbouiCOM.ChooseFromListCreationParams)SBOApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
            oCFLCRPARAM.MultiSelection = false;
            oCFLCRPARAM.ObjectType = oObjType;
            oCFLCRPARAM.UniqueID = oCFLName;
            try
            {
                oCFL = oCFLS.Add(oCFLCRPARAM);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (oCFLS != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCFLS);
                    oCFLS = null;
                    GC.Collect();
                }
            }



            oTextBox.ChooseFromListUID = oCFLName;
            oTextBox.ChooseFromListAlias = oCFLAlias;

        }

        public static void AddCFL(this IForm oForm, SAPbouiCOM.Application SBOApp, string oObjType, string oCFLName, string oCFLAlias)
        {
            SAPbouiCOM.ChooseFromListCollection oCFLS;
            oCFLS = oForm.ChooseFromLists;
            SAPbouiCOM.ChooseFromList oCFL;
            SAPbouiCOM.ChooseFromListCreationParams oCFLCRParam;
            oCFLCRParam = (SAPbouiCOM.ChooseFromListCreationParams)SBOApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
            oCFLCRParam.MultiSelection = false;
            oCFLCRParam.ObjectType = oObjType;
            oCFLCRParam.UniqueID = oCFLName;
            try
            {
                oCFL = oCFLS.Add(oCFLCRParam);
            }
            catch ( Exception ex)
            {
                throw ex;
            }
            

        }
        public static void AddCFLCond3(this IForm oForm, SAPbouiCOM.Application SBOApp, string oObjType, string oCFLName, string oCFLAlias, SAPbouiCOM.EditText oTextBox, SAPbouiCOM.Condition oCondition)
        {
            //AGREGAR UN CFL MULTI CONDICION (MAS DE UNA CONDICION)
            
            SAPbouiCOM.Conditions oConditions;
            SAPbouiCOM.ChooseFromListCollection oCFLS;
            oCFLS = oForm.ChooseFromLists;
            SAPbouiCOM.ChooseFromList oCFL;
            SAPbouiCOM.ChooseFromListCreationParams oCflParams;
            oCflParams = (SAPbouiCOM.ChooseFromListCreationParams)SBOApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);
            oCflParams.MultiSelection = false;
            oCflParams.ObjectType = oObjType;
            oCflParams.UniqueID = oCFLName;
            try
            {
                oCFL = oCFLS.Add(oCflParams);
                oConditions = oCFL.GetConditions();
                oCondition = oConditions.Add();//--
                oCFL.SetConditions(oConditions);
            }
            catch
            { }

            oTextBox.ChooseFromListUID = oCFLName;
            oTextBox.ChooseFromListAlias = oCFLAlias;

        }


       

        public static void  ScreenCenter(this IForm oForm)
        {
            oForm.Left = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - oForm.Width) / 2;
            oForm.Top = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - oForm.Height) / 2;
        }

   
        public static void GetSupplier(this IForm oForm, string itemId)
        {

            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");
        
            
        
            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "CardType";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = "S";



                oCfl.SetConditions(oConditions);

              //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }


        public static void GetCustomer(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("No puede ser nulo o vacio.");
        
            

            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "CardType";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = "C";



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }

        public static void GetDepartamento(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("ItemId, No puede ser nulo o vacio.");



            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "Country";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = Sb1Admin.GetBankCountry();



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }


        public static void GetProvincia(this IForm oForm, string itemId, string departamento)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("ItemId, No puede ser nulo o vacio.");



            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "U_Depart";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = departamento;



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }


        public static void GetDistrito(this IForm oForm, string itemId, string provincia)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("ItemId, No puede ser nulo o vacio.");



            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "U_Depart";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = provincia;



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }

        public static SAPbouiCOM.Form GetForm (this IForm oForm,string uniqueID)
        {
            
            return SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(uniqueID);
        }
        public static void GetPeriod(this IForm oForm, string itemId, string category)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("itemId No puede ser nulo o vacio.");

            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException("categoría No puede ser nulo o vacio.");


            SAPbouiCOM.ChooseFromList oCfl = null;
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            
            oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            try
            {




                oConditions = new Conditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "Category";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = category;



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }

        public static void GetBanks(this IForm oForm, string itemId)
        {
            if (oForm == null)
                throw new ArgumentNullException("oForm no puede ser nulo");

            if (string.IsNullOrEmpty(itemId))
                throw new ArgumentNullException("ItemId, No puede ser nulo o vacio.");



            SAPbouiCOM.ChooseFromList oCfl = (SAPbouiCOM.ChooseFromList)oForm.ChooseFromLists.Item(itemId);
            SAPbouiCOM.Condition oCondition = null;
            SAPbouiCOM.Conditions oConditions = null;
            try
            {




                oConditions = oCfl.GetConditions();
                oCondition = oConditions.Add();
                oCondition.Alias = "CountryCod";

                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                oCondition.CondVal = Sb1Admin.GetBankCountry();



                oCfl.SetConditions(oConditions);

                //  return oForm.Items.Item(itemId).Specific as ChooseFromList;

            }

            finally
            {
                if (oCfl != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCfl);
                    oCfl = null;
                    GC.Collect();
                }

                if (oCondition != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCondition);
                    oCondition = null;
                    GC.Collect();
                }

                if (oConditions != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oConditions);
                    oConditions = null;
                    GC.Collect();
                }

            }

        }


        public static void Cerrar(this IForm oForm, string itemId)
        {
            if (itemId == "200")
            oForm.Close();

        }
    }// fin de la clase

}// fin del namespace
