using System.Configuration;

namespace Languages.Common.Configuration
{
    [ConfigurationCollection(typeof(DependencyElement), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DependencyElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DependencyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DependencyElement)element).ObjectType;
        }
    }
}
