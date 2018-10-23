using Languages.Common.Interfaces;
using Languages.Data.Common.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Languages.Data.Common
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string m_ConnectionString;
        public ConnectionFactory(ILanguagesConfiguration configuration)
        {
            m_ConnectionString = configuration.ConnectionString;
        }

        public IDbConnection CreateConnection()
        {
            var result = new SqlConnection(m_ConnectionString);
            result.Open();
            return result;
        }

        public async Task<IDbConnection> CreateAsyncConnection()
        {
            var result = new SqlConnection(m_ConnectionString);
            await result.OpenAsync();
            return result;
        }
    }
}
