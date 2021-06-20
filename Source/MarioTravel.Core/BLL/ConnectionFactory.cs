using Microsoft.Extensions.Options;
using Npgsql;
using System.Data.Common;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL
{
    public class ConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(IOptions<ConnectionOptions> connectionOpts)
        {
            connectionString = connectionOpts.Value.ConnectionString;
        }

        public DbConnection Create()
        {
            return new NpgsqlConnection(connectionString);
        }

        public DbConnection CreateOpen()
        {
            var connection = Create();
            connection.Open();

            return connection;
        }

        public async Task<DbConnection> CreateOpenAsync()
        {
            var connection = Create();
            await connection.OpenAsync();

            return connection;
        }
    }
}