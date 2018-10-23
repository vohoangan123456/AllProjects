using Languages.Common.Interfaces;
namespace Languages.Common
{
    public class LanguagesConfiguration : ILanguagesConfiguration
    {
        private const string DefaultConnectionStringKey = "DefaultConnectionString";

        private readonly IApplicationConfigurationManager m_ConfigurationManager;
        public LanguagesConfiguration(IApplicationConfigurationManager configurationManager)
        {
            m_ConfigurationManager = configurationManager;
            Initialize();
        }

        private void Initialize()
        {
            ConnectionString = m_ConfigurationManager.GetConnectionStringCore(DefaultConnectionStringKey);
        }

        public string ConnectionString { get; private set; }
    }
}
