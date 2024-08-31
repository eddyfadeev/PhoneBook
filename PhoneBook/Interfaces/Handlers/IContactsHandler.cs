using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers;

internal interface IContactsHandler
{
    public void SelectContact(out Contact? contact, out string message);
    public void DeleteContact(Contact contact, out string message);
}