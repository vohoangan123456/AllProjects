using Languages.Data.Common.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Languages.Data.Common
{
    public abstract class ConnectionBase
    {
        private readonly IConnectionFactory m_ConnectionFactory;

        protected ConnectionBase(IConnectionFactory connectionFactory)
        {
            m_ConnectionFactory = connectionFactory;
        }

        protected T Execute<T>(Func<IDbConnection, T> action)
        {
            using (IDbConnection connection = m_ConnectionFactory.CreateConnection())
            {
                return action(connection);
            }
        }

        protected void Execute(Action<IDbConnection> action)
        {
            using(IDbConnection connection = m_ConnectionFactory.CreateConnection())
            {
                action(connection);
            }
        }

        protected async Task<T> ExecuteAsync<T>(Func<IDbConnection, T> action)
        {
            using(var connection = await m_ConnectionFactory.CreateAsyncConnection())
            {
                return action(connection);
            }
        }

        protected async Task ExecuteAsync(Action<IDbConnection> action){
            using (var connection = await m_ConnectionFactory.CreateAsyncConnection())
            {
                action(connection);
            }
        }
    }
}
