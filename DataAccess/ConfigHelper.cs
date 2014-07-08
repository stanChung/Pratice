using System;
using System.Configuration;

namespace DataAccess
{
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 取得連線字串
        /// </summary>
        /// <param name="keyName">連線字串key name</param>
        /// <returns></returns>
        public static string GetConnectionString(string keyName)
        {
            if (ConfigurationManager.ConnectionStrings[keyName] == null ||
    ConfigurationManager.ConnectionStrings[keyName].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named '" + keyName + "' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            return ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
        }

        /// <summary>
        /// 取得程式設定字串
        /// </summary>
        /// <param name="keyName">設定字串key name</param>
        /// <returns></returns>
        public static string GetAppSettingString(string keyName)
        {
            if (ConfigurationManager.AppSettings[keyName] == null ||
    ConfigurationManager.AppSettings[keyName].ToString().Trim() == "")
            {
                throw new Exception("A AppSettings string named '" + keyName + "' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            return ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
        }
    }
}
