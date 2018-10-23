using Languages.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace Languages.Common
{
    public class ApplicationConfigurationManager : IApplicationConfigurationManager
    {
        private const string LanguagesConfigurationFileName = "Languages.config";

        private Dictionary<string, string> m_AppSettings = new Dictionary<string, string>();
        IConfiguration _configuration;
        public ApplicationConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
            LoadLanguagesConfigurationSetting();
        }

        public string GetConnectionStringCore(string key)
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public string GetString(string key)
        {
            return m_AppSettings[key];
        }

        public bool GetBoolean(string key, bool defaultValue = false)
        {
            string value = m_AppSettings[key];
            if(value != null)
            {
                bool result;
                if(bool.TryParse(value, out result))
                {
                    return result;
                }
            }
            return defaultValue;
        }

        public int GetInteger(string key, int defaultValue = 0)
        {
            string value = m_AppSettings[key];
            if(value != null)
            {
                int result;
                if(int.TryParse(value, out result))
                {
                    return result;
                }
            }
            return defaultValue;
        }

        private void LoadLanguagesConfigurationSetting()
        {
            XDocument configurationFile = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LanguagesConfigurationFileName));
            IEnumerable<XElement> settingElements = configurationFile.Element("LanguagesSettingsConfigurationSection")
                                                                     .Element("LanguagesSettingsConfiguration")
                                                                     .Elements("add");
            foreach(var setting in settingElements)
            {
                m_AppSettings[setting.Attribute("key").Value] = setting.Attribute("value").Value;
            }
        }
    }
}
