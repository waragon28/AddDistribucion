using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class RutaTransportista1
    {
        public string U_CardCode { get; set; }
        public string U_CardName { get; set; }
        public string U_DeliveryDate { get; set; }
        public string U_DocEntry { get; set; }
        public string U_DocNum { get; set; }
        public string U_FullAddress { get; set; }
        public string U_Comments { get; set; }
        public string U_EstimatedTime { get; set; }
        public string U_CheckInTime { get; set; }
        public string U_CheckOutTime { get; set; }
        public object U_PhotoDocument { get; set; }
        public string U_PhotoStore { get; set; }
        public object U_PersonContact { get; set; }
        public object U_PaymentCondition { get; set; }
        public object U_ReturnReason { get; set; }
        public object U_UserCode { get; set; }
        public object U_UserName { get; set; }
        public string U_Delivered { get; set; }
    }

    public class RutaTransportista1Estado
    {
        public string LineId { get; set; }
        public string U_Delivered { get; set; }
        public string U_ReturnReason { get; set; }
    }

}
