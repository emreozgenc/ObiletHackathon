using Microsoft.Data.SqlClient;
using System.Data;

namespace ObiletHackathon.Api.Utilities
{
    public class DatabaseConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlServer"));
        }
    }
}
