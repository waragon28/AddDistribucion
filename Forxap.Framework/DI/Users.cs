using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forxap.Framework.Utils;
using Forxap.Framework.Extensions;
using SAPbobsCOM;

namespace Forxap.Framework.DI
{
   public  class Sb1Users : Base, IDisposable
    {
       SAPbobsCOM.Users oUser = null;
       /// <summary>
       /// Cargo un listado de usuarios en el combobox
       /// </summary>
       /// <param name="oComboBox"></param>
       public static Dictionary<string, string> GetListUser()
       {
           Dictionary<string, string> listObject = new Dictionary<string, string>();

           SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
           string strSQL = string.Empty;

           strSQL = string.Format(" SELECT \"USERID\" as \"Code\",\"U_NAME\" as \"Name\"   FROM \"OUSR\" ");

           oRecordSet.DoQuery(strSQL);


           listObject.Add("", "");

           while (!oRecordSet.EoF)
           {

               listObject.Add(oRecordSet.Fields.Item("Code").Value.ToString().Trim(), oRecordSet.Fields.Item("Name").Value.ToString().Trim());
               oRecordSet.MoveNext();
           }

           listObject.Add("*", "Todos");


           return listObject;
       }

       /// <summary>
       /// trae los datos de una UDT , trae los campos Code y Name, el parametro es el nombre de la tabla incluido el @
       /// </summary>
       /// <param name="tableName">Aqui debe ir el nombre de la UDT incluido el @</param>
       /// <returns>retorna un listado</returns>
       public static Dictionary<string, string> GetListFromUDT(string tableName)
       {


           Dictionary<string, string> listObject = new Dictionary<string, string>();

           SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
           string strSQL = string.Empty;

          

           strSQL = string.Format("select \"Code\",\"Name\" From \"{0}\" WHERE \"U_VIS_Trasvase\"='Y' ", tableName);

           oRecordSet.DoQuery(strSQL);
           listObject.Add("", "");

           while (!oRecordSet.EoF)
           {

               listObject.Add(oRecordSet.Fields.Item("Code").Value.ToString().Trim(), oRecordSet.Fields.Item("Name").Value.ToString().Trim());
               oRecordSet.MoveNext();
           }

           return listObject;

       }

       public static Dictionary<string, string> GetListFromSQL(string sqlString)
       {
           Dictionary<string, string> listObject = new Dictionary<string, string>();

           SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
          
           oRecordSet.DoQuery(sqlString);
           listObject.Add("", "");

           while (!oRecordSet.EoF)
           {
               if (oRecordSet.Fields.Item(0).Value.ToString().Trim().Length > 0)
                   listObject.Add(oRecordSet.Fields.Item(0).Value.ToString().Trim(), oRecordSet.Fields.Item(1).Value.ToString().Trim());
               oRecordSet.MoveNext();
           }

           return listObject;


           
       }

        
        public static Dictionary<string, string> GetListFromUDTEx( string tableName,string[]  fields)
       {


           Dictionary<string, string> listObject = new Dictionary<string, string>();

           SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
           string strSQL = string.Empty;



           strSQL = string.Format("select \"{0}\",\"{1}\" From \"{2}\" ", fields[0].Trim(), fields[1].Trim(), tableName);

           oRecordSet.DoQuery(strSQL);
           listObject.Add("", "");

           while (!oRecordSet.EoF)
           {
               if (oRecordSet.Fields.Item(fields[0].Trim()).Value.ToString().Trim().Length > 0)
               listObject.Add(oRecordSet.Fields.Item(fields[0].Trim()).Value.ToString().Trim(), oRecordSet.Fields.Item(fields[1].Trim()).Value.ToString().Trim());
               oRecordSet.MoveNext();
           }

           return listObject;

       }
           
            
        #region Disposable
        
        


        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~Sb1Users()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase


}// fin del namespace
