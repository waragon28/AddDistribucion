using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
   public  class Cabecera_Mensaje
    {
        public List<Data> Data { get; set; }
    }
    public class Data
    {
        public string Mensaje { get; set; }
        public string NumeroTelf { get; set; }
    }
}
