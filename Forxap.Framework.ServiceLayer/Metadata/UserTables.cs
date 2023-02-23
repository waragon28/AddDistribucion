using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Forxap.Framework.ServiceLayer.Metadata
{

    /// <summary>
    /// Contiene metodos que te e te permite crear tablas de usuarios y crear nuevos registros
    /// </summary>
    public class UserTables
    {

        public void CreateUserTable(string tableName, string tableDescription, SAPbobsCOM.BoUTBTableType tableType, SAPbobsCOM.BoYesNoEnum archivable, string ArchiveDateField = null)
        {
            // PASO 1 VERIFICO QUE LA TABLA NO EXISTA EN LA EMPRESA DONDE DESEO CREARLA
//            POST /UserTablesMD


            //{
            // "TableName": "MYTBL",
            // "TableDescription": "My Table",
            // "TableType": "bott_NoObject"
            //}


   //         Forxap.Framework.ServiceLayer.M
            
       //     dynamic respta2 = Forxap.Framework.ServiceLayer.POST("U_FXP_HR_SU08", JsonConvert.SerializeObject(tblUser));
            

        }
     
        private bool  GetByKey(string tableName)
        {
            bool ret = false;



            return ret;

        }


    }// fin  de la clase

    public class Table
    {

        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TableType  { get; set; }
        public string Archivable { get; set; }

        
    }



}// fin del namespace
