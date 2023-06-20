using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class DocumentSUNAT
    {
        public string Code { get; set; }
        public List<SYPNUMDOCCollection> SYP_NUMDOCCollection { get; set; }
    }

    public class SYPNUMDOCCollection
    {
        public string Code { get; set; }
        public int LineId { get; set; }
        public string U_SYP_NDSD { get; set; }
        public string U_SYP_NDCD { get; set; }
    }
}
