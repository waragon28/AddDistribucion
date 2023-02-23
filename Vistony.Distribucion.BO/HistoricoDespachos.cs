using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class HistoricoDespachos
    {
        public string Code { get; set; }
        public string U_OrderNum { get; set; }
        public string U_Status { get; set; }
        public string U_NumLine { get; set; }
        public string U_DateProgram { get; set; }
        public string U_DriverCode { get; set; }
        public string U_DriverName { get; set; }
        public string U_VehicleCode { get; set; }
        public string U_Assistent { get; set; }
        public string U_Comments { get; set; }
        public string U_User { get; set; }
    }

    public class HistoricoDespachosCabecera
    {
        public string Code { get; set; }
        public string U_VIS_CodDriver { get; set; }
        public string U_VIS_NameDriver { get; set; }
        public string U_VIS_Date { get; set; }
        public string U_VehicleCode { get; set; }
    }
}
