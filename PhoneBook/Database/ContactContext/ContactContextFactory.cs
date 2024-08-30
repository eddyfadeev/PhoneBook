using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PhoneBook.Database.ContactContext;

internal class ContactContextFactory : IDesignTimeDbContextFactory<ContactContext>
{
    private const string DefaultConnection = "DefaultConnection";
    public ContactContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<Database.ContactContext.ContactContext>();
        var connectionString = configuration.GetConnectionString(DefaultConnection);
        optionsBuilder.UseSqlServer(connectionString);

        return new ContactContext(configuration);
    }
}