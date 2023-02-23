using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Banco.BO
{
    public class transferDocument
    {
        public DateTime DocDate{ get; set; }
        public DateTime DueDate { get; set; }
        public string Comments { get; set; }
        public List<transferDocumentDetalls> DocumentDetalls { get; set; }

    }
}
