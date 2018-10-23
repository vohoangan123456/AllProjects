
namespace Languages.Common.Interfaces
{
    public interface IApplicationConfigurationManager
    {
        string GetConnectionString(string key);

        string GetConnectionStringCore(string key);

        string GetString(string key);

        bool GetBoolean(string key, bool defaultValue = false);

        int GetInteger(string key, int defaultValue = 0);
    }
}
