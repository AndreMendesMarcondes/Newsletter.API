using System.Data;
using Dapper;
using Newsletter.Domain.Entities;
using Newsletter.Domain.Interfaces;

namespace Newsletter.Infrastructure.Repositories;
public class SubscriberRepository : ISubscriberRepository
{
    private readonly IDbConnection _connection;

    public SubscriberRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<int> Add(Subscriber subscriber)
    {
        subscriber.DateCreated = DateTime.UtcNow;
        string query = "INSERT INTO Subscribers (Email, DateCreated) VALUES (@Email, @DateCreated); SELECT LAST_INSERT_ID();";
        return await _connection.ExecuteScalarAsync<int>(query, subscriber);
    }

    public async Task<Subscriber> GetByEmail(string email)
    {
        string query = "SELECT * FROM Subscribers WHERE Email = @Email;";
        return await _connection.QueryFirstOrDefaultAsync<Subscriber>(query, new { Email = email });
    }
}
