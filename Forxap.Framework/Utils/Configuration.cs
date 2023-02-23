using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Forxap.Framework.Utils
{
    public class Configuration
    {
        /// <summary>
        ///  lee un valor del setting
        /// </summary>
        /// <param name="key"></param>
        public static string ReadAppSetting(string key)
        {
            string result = string.Empty;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "No Encontrado";
            }
            catch (ConfigurationErrorsException ex)
            {
                LogFile.Error(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// agrega o actualiza una llave dentro del config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void UpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                LogFile.Error(ex.ToString());
            }
        }
    
    }// fin de la clase

}// fin del namespace
