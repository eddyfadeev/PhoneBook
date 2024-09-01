using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers.ContactHandlers;

internal interface IContactUpdater
{
    void UpdateContact(Contact contact, out string? message);
}