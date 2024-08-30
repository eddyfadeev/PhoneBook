using PhoneBook.Interfaces.Database;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;

namespace PhoneBook.Repository;

internal class ContactRepository : IRepository<Contact>
{
    private readonly IDatabaseManager _databaseManager;
    
    public ContactRepository(IDatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }
    
    public int AddContact(Contact entity)
    {
        using var connection = _databaseManager.GetConnection();
        connection.Add(entity);

        return connection.SaveChanges();
    }

    public int UpdateContact(Contact entity)
    {
        using var connection = _databaseManager.GetConnection();
        connection.Update(entity);
        
        return connection.SaveChanges();
    }

    public int DeleteContact(Contact entity)
    {
        using var connection = _databaseManager.GetConnection();
        connection.Remove(entity);
        
        return connection.SaveChanges();
    }

    public Contact? GetContact(int id)
    {
        using var connection = _databaseManager.GetConnection();
        
        return connection.Contacts.Find(id);
    }

    public List<Contact> GetAllContacts()
    {
        using var connection = _databaseManager.GetConnection();
        
        return connection.Contacts.ToList();
    }
}