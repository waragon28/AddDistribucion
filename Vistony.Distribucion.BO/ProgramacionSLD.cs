using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class ProgramacionSLD
    {
        public string U_DriverCode { get; set; }
        public string U_DriverName { get; set; }
        public string U_AssistantCode { get; set; }
        public string U_AssistantName { get; set; }
        public string U_VehiculeCode { get; set; }
        public string U_VehiculeName { get; set; }
        public string U_VehicleCapacity { get; set; }
        public string U_DocumentsWeight { get; set; }
        public string U_SuccessQuantity { get; set; }
        public string U_FailedQuantity { get; set; }
        public string U_DocumentsQuantity { get; set; }
        public string U_DocDate { get; set; }
        public string U_Type_Route { get; set; }
        public string U_CardCode { get; set; }
        public string U_CardName { get; set; }
        public List<Programacion1> VIS_DIS_DRT1Collection { get; set; }

    }
}
