using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPbobsCOM;
using SAPbouiCOM;

namespace Forxap.Framework.Extensions
{

    
    public  class UserProceduresMD : Base, IUserTablesMD, IDisposable 
    {
        public string ProcedureName { get; set; }
        public string ProcedureDescription { get; set; }

        public string FileName { get; set; }
        
        
        /// <summary>
        /// agrega un procedimiento almacenado a la bd que se encuentre logeado en SAP
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            int ret = 0;
            SAPbobsCOM.Recordset recordSet = null;
            string strSQL = string.Empty;
            UserProceduresMD oUserProcedureMD = new UserProceduresMD();

            if (System.IO.File.Exists(FileName))
            {
                strSQL = System.IO.File.ReadAllText(FileName);
            
            }

            

            if (!oUserProcedureMD.GetByKey(ProcedureName))
            {
                // si el stored  procedure no existe entonces lo creo

                recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                if (recordSet == null)
                    throw new NullReferenceException("No se pudo obtener el objeto Recordset");

                try
                {

                    
                    recordSet.DoQuery(strSQL);

                    // para saber si lo creo bien debo volver a buscarlo a traves del GetByKey
                    // LO BUSCO P¿CON EL BYKEY PERO APARECE QUE SI EXISTE , SOLO HASTA QUE SE CIERRA EL ADDON NO SE ACTUALIZA
                    // LOS OBJETOS DE LA BASE DE DATOS
                }

                finally
                {
                    if (recordSet != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                        recordSet = null;
                        GC.Collect();
                    }
                }
            }
            else
            {
                throw new Exception("Ya existe");
                //stored procedure ya existe
            }

            return ret;
        }

        public BoYesNoEnum Archivable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ArchiveDateField
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SAPbobsCOM.DataBrowser Browser
        {
            get { throw new NotImplementedException(); }
        }

        public string GetAsXML()
        {
            throw new NotImplementedException();
        }

        public bool GetByKey(string ProcedureName)
        {
            bool ret = false;

            int rowsCount = 0;
            
            SAPbobsCOM.Recordset recordSet = null;


            // con la tabla y el nombre del campo debo obtener el FIELDID con el que se encuentra grabado
            // select FieldId from CUFD where TableId = tableName and AliasID = FieldName

            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {
                string strSQL = string.Format("SELECT  Count(OBJECT_OId) as RowsCount  FROM sys.objects  where Object_type = 'PROCEDURE'  and  object_name =  '{0}' ", ProcedureName);
                recordSet.DoQuery(strSQL);

                rowsCount = Convert.ToInt32(recordSet.Fields.Item("RowsCount").Value);

                if (rowsCount > 0)
                {
                    ret = true;
                }
                
            }
            
            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }

           
            return ret;
        }

        public int Remove()
        {
            int ret = 0;
            int rowsCount = 0;
            SAPbobsCOM.Recordset recordSet = null;


            
            recordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {
                string strSQL = string.Format("DROP PROCEDURE {0}",  ProcedureName);

                
                    recordSet.DoQuery(strSQL);
                    // si no hay error quiere decir que ya esta eliminado 
                    ret = 1;
               
            }

            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }


            return ret;
        }

        public void SaveToFile(string FileName)
        {
            throw new NotImplementedException();
        }

        public void SaveXML(ref string FileName)
        {
            throw new NotImplementedException();
        }

        public string TableDescription
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string TableName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public BoUTBTableType TableType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Update()
        {
            throw new NotImplementedException();
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
        ~UserProceduresMD()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase

}// fin del namespace
