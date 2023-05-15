//#define AD_EC
//#define AD_PE
#define AD_CL
//#define AD_PY
//#define AD_ES
//#define AD_MA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Framework.Constants
{
    public class UserFiles
    {


        #if AD_EC
        public const string FolderHana = "/Scripts/Hana/Ecuador/";
        #else
           public const string FolderHana = "/Scripts/Hana/";
        #endif

        public const string FolderSQL = "/Scripts/SQL/";
        
    }
}
