
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class Programacion1
    {
        public string U_NumAtCard { get; set; }
        public string U_Delivered { get; set; }

        public string U_CardCode { get; set; }
        public string U_CardName { get; set; }
        public object U_DocEntry { get; set; }
        public object U_DocNum { get; set; }
        public object U_FullAddress { get; set; }

        public string U_DocEntryRef { get; set; }
        public string U_DocNumRef { get; set; }
         public string U_TaxDate { get; set; }

        public  string U_SlpCode { get; set; }
        public  string U_SlpName { get; set; }

        public string U_PymntGroup { get; set; }
        


        // saldo
        public string U_DocBalance { get; set; }

    }
}
