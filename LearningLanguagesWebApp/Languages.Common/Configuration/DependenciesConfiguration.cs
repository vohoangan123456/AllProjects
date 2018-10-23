using System.Configuration;

namespace Languages.Common.Configuration
{
    public class DependenciesConfiguration : ConfigurationSection
    {
        private static DependenciesConfiguration m_Instance = null;

        public static DependenciesConfiguration Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = (DependenciesConfiguration)ConfigurationManager.GetSection("dependenciesConfigurationSection");
                }
                return m_Instance;
            }
        }

        [ConfigurationProperty("dependenciesConfiguration", IsDefaultCollection = true)]
        public DependencyElementCollection DependenciesConfigurations
        {
            get
            {
                return (DependencyElementCollection)this["dependenciesConfiguration"];
            }
        }

        public string GetObjectType(string key)
        {
            foreach(DependencyElement item in DependenciesConfigurations)
            {
                if (item.Key.Equals(key))
                {
                    return item.ObjectType;
                }
            }
            return string.Empty;
        }
    }
}
