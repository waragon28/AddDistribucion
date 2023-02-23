using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.FrameWork
{
 /// <summary>
 /// Variables Globales
 /// </summary>
    public static class Globals
    {
        public static string CompanyDB { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static string SessionId { get; set; }
        public static string SessionTimeout { get; set; }
        public static string Version { get; set; }

        public static bool IsConnected { get; set; }
        public static void SetCredentials(string companyDB, string userName, string password)
        {
            CompanyDB = companyDB;
            UserName = userName;
            Password = password;
        }

        public static void SetSessionsValues(string sessionId, string sessionTimeout, string version , bool connect)
        {
            SessionId = sessionId;
            SessionTimeout = sessionTimeout;
            Version = version;
            IsConnected = connect;
            
        }


        public static void SetSessionsValues(dynamic json)
        {
            SessionId = json.SessionId.ToString();
            SessionTimeout =  json.SessionTimeout.ToString();
            Version = json.Version.ToString();
            IsConnected = true;
        }

    }// fin de la clase

}// fin del namespace
