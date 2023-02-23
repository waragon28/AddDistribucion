using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Banco.BO
{
    public class transferDocumentDetalls
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public string WarehouseCode { get; set; }
        public string FromWarehouseCode { get; set; }
    }
}
