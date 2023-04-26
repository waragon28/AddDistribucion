using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class RutaOptima
    {
        public double DuracionTotal { get; set; }
        public double DistanciaTotal { get; set; }
        public List<PasoRuta> Pasos { get; set; }
    }
}
