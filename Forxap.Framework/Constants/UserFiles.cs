#define AD_EC

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
