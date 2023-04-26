//#define AD_BO
#define AD_PE
//#define AD_ES
//#define AD_PY
//#define AD_EC

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{


    public class EntregaConsolidado
    {
        public string U_SYP_DT_CONSOL { get; set; }
        public string U_SYP_DT_FCONSOL { get; set; }
        public string U_SYP_DT_HCONSOL { get; set; }

    }
#if AD_PE
    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; }
        public string U_SYP_DT_CORRDES { get; set; }
        public string U_SYP_DT_FCDES { get; set; } // fecha 
        public string U_SYP_MDFN { get; set; }
        public string U_SYP_MDVC { get; set; }
        public string U_SYP_MDVN { get; set; }
        public string U_SYP_DT_AYUDANTE { get; set; }
        public string U_SYP_DT_ESTDES { get; set; }

        /*FACTURA CION ELECTRONICA*/
        public string U_SYP_FEEST { get; set; }
        public string U_SYP_FEESUNAT { get; set; }
        public string U_SYP_FEMEX { get; set; }
        public string U_SYP_FEGFI { get; set; }
        public string U_SYP_FEGFE { get; set; }

    }

#elif AD_BO
    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; } //SI
        public string U_SYP_DT_CORRDES { get; set; }//SI
        public string U_SYP_DT_FCDES { get; set; }//SI
        public string U_SYP_MDFN { get; set; }//SI
        public string U_SYP_MDVC { get; set; }//SI
        public string U_SYP_MDVN { get; set; }//SI
        public string U_SYP_DT_AYUDANTE { get; set; }//SI
        public string U_SYP_DT_ESTDES { get; set; }
    }

#elif AD_ES
    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; } //SI
        public string U_SYP_DT_CORRDES { get; set; }//SI
        public string U_SYP_DT_FCDES { get; set; }//SI
        public string U_SYP_MDFN { get; set; }//SI
        public string U_SYP_MDVC { get; set; }//SI
        public string U_SYP_MDVN { get; set; }//SI
        public string U_SYP_DT_AYUDANTE { get; set; }//SI
        public string U_SYP_DT_ESTDES { get; set; }//SI
    }
#else
    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; } //SI
        public string U_SYP_DT_CORRDES { get; set; }//SI
        public string U_SYP_DT_FCDES { get; set; }//SI
        public string U_SYP_MDFN { get; set; }//SI
        public string U_SYP_MDVC { get; set; }//SI
        public string U_SYP_MDVN { get; set; }//SI
        public string U_SYP_DT_AYUDANTE { get; set; }//SI
        public string U_SYP_DT_ESTDES { get; set; }//SI
    }
#endif

    public class UpdateEntregaDespacho
    {
        public string U_SYP_MDVC { get; set; }
        public string U_SYP_MDVN { get; set; }
        public string U_SYP_MDFC { get; set; } 
        public string U_SYP_MDFN { get; set; }
        public string U_SYP_DT_FCDES { get; set; }
        public string U_SYP_DT_AYUDANTE { get; set; }

    }

    public class UpdateEstadoDespacho
    {
        public string U_SYP_DT_ESTDES { get; set; }
    }
    public class EstadoDespacho
    {
        public string U_SYP_DT_ESTDES { get; set; }
        public string U_SYP_DT_OCUR { get; set; }
    }

    public class EstadoDespachoVolverProgramar
    {
        public string U_SYP_DT_ESTDES { get; set; }
        public string U_SYP_DT_OCUR { get; set; }

    }

    public class EntregaDespachoSLD
    {
        public string U_SYP_MDFC { get; set; } //SI
        public string U_SYP_DT_CORRDES { get; set; }//SI
        public string U_SYP_DT_FCDES { get; set; }//SI
        public string U_SYP_MDFN { get; set; }//SI
        public string U_SYP_MDVC { get; set; }//SI
        public string U_SYP_MDVN { get; set; }//SI
        public string U_SYP_DT_AYUDANTE { get; set; }//SI
        public string U_SYP_DT_ESTDES { get; set; }//SI
        public string U_SYP_MDTD { get; set; }//SI
        public string U_SYP_MDSD { get; set; }//SI  
        public string U_SYP_MDCD { get; set; }//SI  
        public string U_SYP_FEGMT { get; set; }//SI
        public string U_SYP_MDCT { get; set; }//SI
        public string U_SYP_MDRT { get; set; }//SI
        public string U_SYP_MDNT { get; set; }//SI
        public string U_SYP_MDDT { get; set; }//SI
        public string U_SYP_MDTS { get; set; }//SI
       
        public string U_VIS_AgencyCode { get; set; }//SI
        public string U_VIS_AgencyRUC { get; set; }//SI
        public string U_VIS_AgencyName { get; set; }//SI
        public string U_VIS_AgencyDir { get; set; }//SI
        public string U_SYP_FEGFI { get; set; }//SI
        public string U_SYP_FEGNB { get; set; }//SI

    }
}
