//#define AD_EC
#define AD_PE
//#define AD_CL
//#define AD_PY
//#define AD_ES
//#define AD_MA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  Forxap.Banco.UI.Win;

namespace Vistony.Distribucion.Constans
{
    public class AddonUserFiles 
    {
        public const string UserMenus = "Files/UserMenus.xml";
        public const string UserMenusChile = "Files/UserMenusChile.xml";
        public const string UserMenusEnglisUnitedStates = "Files/UserMenusEnglisUnitedStates.xml";
        public const string UserMenusFrench= "Files/UserMenusFrench.xml";
        public const string UserMenusPeru = "Files/UserMenusPeru.xml";
#if AD_EC
        public const string UserProcedures = "Files/EC/UserProcedureEC.xml";
#else
        public const string UserProcedures = "Files/UserProcedures.xml";
#endif

        //public const string UserTables = "Files/UserTables.xml";
        //public const string UserFields = "Files/UserFields.xml";
        //public const string UserObjects = "Files/UserObjects.xml";
        //public const string UserPermissions = "Files/UserPermissions.xml";
        //public const string UserScripts = "Files/UserScripts.xml";


        public const string Icon = "/Images/AddonIcon.png";
        public const string Wizard = "/Images/Wizard.jpg";



        


    }// fin de la clase


}// fin del namespace
