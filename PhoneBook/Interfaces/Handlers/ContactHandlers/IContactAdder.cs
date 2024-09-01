namespace PhoneBook.Interfaces.Handlers.ContactHandlers;

internal interface IContactAdder
{
    void AddContact(out string? message);
}