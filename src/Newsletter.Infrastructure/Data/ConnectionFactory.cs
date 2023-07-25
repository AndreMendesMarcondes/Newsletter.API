using System.Data;
using MySql.Data.MySqlClient;

namespace Newsletter.Infrastructure.Data;

public class ConnectionFactory
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    
    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration["MyConnectionString"];
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
