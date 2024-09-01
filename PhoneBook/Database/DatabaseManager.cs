using Microsoft.Extensions.Configuration;
using PhoneBook.Interfaces.Database;

namespace PhoneBook.Database;

internal class DatabaseManager : IDatabaseManager
{
    private readonly IConfiguration _connectConfiguration;
    
    public DatabaseManager(IConfiguration configuration)
    {
        _connectConfiguration = configuration;
        InitializeDatabase();
    }
    
    public ContactContext.ContactContext GetConnection() =>
        new (_connectConfiguration);
    
    // TODO: Move to initializer class + interface. Initialize database on startup in DI service to adhere to SOLID
    private void InitializeDatabase()
    {
        using var connection = GetConnection();
        
        // TODO: You might don't need a bool, just catch the exception if any problem arise
        connection.Database.EnsureCreated();
    }
}