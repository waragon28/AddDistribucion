using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forxap.Framework.Extensions;


namespace Forxap.Framework.DI.Inventory
{
    public class oInventoryGenExit : Base
    {


        /// <summary>
        ///  Salida por transvase
        /// </summary>
        /// <param name="document"></param>
        /// <param name="document_line"></param>
        public void Add(SAPbouiCOM.DBDataSource document, SAPbouiCOM.DBDataSource document_line)
        {
            SAPbobsCOM.Documents oInventoryExit;

            double nAddResult;


            oInventoryExit = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

            oInventoryExit = (SAPbobsCOM.Documents)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);
            oInventoryExit.Series = 22;
            oInventoryExit.DocCurrency = "USD";
            oInventoryExit.Reference2 = "Ref2";
            
            
            oInventoryExit.JournalMemo = "comentarios de asiento";
            oInventoryExit.Comments = "comentarios";
            
            oInventoryExit.GroupNumber = -1; // lista de precios.

            //documentos de referencia
            //oInventoryExit.DocumentReferences

            // registra el detalle de la salida
            for (int recordNumber = 0; recordNumber < document_line.Size; recordNumber++)
            {

                oInventoryExit.Lines.ItemCode = document_line.GetString("", recordNumber);
                oInventoryExit.Lines.Quantity = 1;
                oInventoryExit.Lines.UnitPrice = 100.0;
                oInventoryExit.Lines.AccountCode = "_SYS00000000239";
                oInventoryExit.Lines.WarehouseCode = "01";
                oInventoryExit.Lines.CostingCode = "VG";


                
                oInventoryExit.Lines.Add(); 

            }



            nAddResult = oInventoryExit.Add();



        }




    }// fin de la clase


}// fin del namespace
