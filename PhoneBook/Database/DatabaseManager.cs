using Microsoft.Extensions.Configuration;
using PhoneBook.Interfaces.Database;

namespace PhoneBook.Database;

internal class DatabaseManager : IDatabaseManager
{
    private readonly IConfiguration _connectionConfiguration;
    
    public DatabaseManager(IConfiguration configuration)
    {
        _connectionConfiguration = configuration;
        InitializeDatabase();
    }
    
    public ContactContext.ContactContext GetConnection() =>
        new (_connectionConfiguration);
    
    private void InitializeDatabase()
    {
        using var connection = GetConnection();
        
        connection.Database.EnsureCreated();
    }
}