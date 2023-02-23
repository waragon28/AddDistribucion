using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class RutaTransportista
    {
        public string U_DriverCode { get; set; }
        public string U_DriverName { get; set; }
        public string U_VehiculeCode { get; set; }
        public string U_VehicleCapacity { get; set; }
        public string U_CountDocuments { get; set; }
        public string U_DocumentsCapacity { get; set; }
        public string U_AssistantCode { get; set; }
        public string U_AssistantName { get; set; }
        public List<RutaTransportista1> VIS_DIS_DRT1Collection { get; set; }


    }
    public class RutaTransportista1EstadoCabecera
    {
        public string DocEntry { get; set; }
        public List<RutaTransportista1Estado> VIS_DIS_DRT1Collection { get; set; }
    }

}
