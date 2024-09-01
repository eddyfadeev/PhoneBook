using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers.ContactHandlers;

internal interface IContactSelector
{
    void SelectContact(out Contact? contact, out string message);
}