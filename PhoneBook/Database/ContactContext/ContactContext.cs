using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Model;

namespace PhoneBook.Database.ContactContext;

internal class ContactContext : DbContext
{
    private const string DefaultConnection = "DefaultConnection";
    private readonly IConfiguration _configuration;
    
    public DbSet<Contact> Contacts { get; set; }

    public ContactContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(DefaultConnection));
    }
}