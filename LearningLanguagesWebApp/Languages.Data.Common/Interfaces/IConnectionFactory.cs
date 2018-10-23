using System.Data;
using System.Threading.Tasks;

namespace Languages.Data.Common.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
        Task<IDbConnection> CreateAsyncConnection();
    }
}
