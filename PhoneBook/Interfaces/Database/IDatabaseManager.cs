using PhoneBook.Database.ContactContext;

namespace PhoneBook.Interfaces.Database;

internal interface IDatabaseManager
{
    ContactContext GetConnection();
}