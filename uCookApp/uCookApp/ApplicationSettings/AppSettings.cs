using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using uCookApp.Constants;
using uCookApp.Interfaces;

namespace uCookApp.ApplicationSettings
{
    public static class AppSettings
    {
        public static string GetDBConnectionString()
        {
            return ReadSetting(SettingKeyNames.DBConnectionStringKey);
        }

        private static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "Error reading app settings";
            }
        }

    }
}