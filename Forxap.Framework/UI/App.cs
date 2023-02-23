using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbouiCOM.Framework;

namespace Forxap.Framework.UI
{
   public class App : Base
    {
 

       public static SAPbouiCOM.Form GetActiveForm()
       {
           SAPbouiCOM.Form activeForm;

           try
           {
               activeForm = oApplication.Forms.ActiveForm;
           }
           catch (Exception )
           {
               throw;
           }

           return activeForm;
       }

       public static string GetActiveFormUniqueID()
       {
           return GetActiveForm().UniqueID;
       }


       public static int GetActiveFormType()
       {

           return GetActiveForm().Type;

       }


       public static void CloseActiveForm()
       {
          
           GetActiveForm().Close();
           
       }


       public static bool IsSystemActiveForm()
       {
           
           return GetActiveForm().IsSystem;
           
          
       }

       public static void OpenForm(string formName)
       {

           try
           {
              
               // Obtenemos una referencia de un objeto Form que 
               // conocemos que se encuentra en el ensamblado actual. 

               //UserFormBase userForm = (UserFormBase)Assembly.CreateInstance(formName);

               //userForm.Show();

           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(string.Format("Error : {1}", ex.Message.ToString()));
               

           }

       }

    }// fin de la clase


}// fin del namespace
