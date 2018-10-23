using System.Configuration;

namespace Languages.Common.Configuration
{
    public class DependencyElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired =true, IsKey = true)]
        public string Key { get { return base["name"] as string; } }

        [ConfigurationProperty("type", IsRequired = true)]
        public string ObjectType { get { return base["type"] as string; } }
    }
}
