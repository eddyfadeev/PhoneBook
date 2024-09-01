using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers.ContactHandlers;

internal interface IContactDeleter
{
    void DeleteContact(Contact contact, out string? message);
}