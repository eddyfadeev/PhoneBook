using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers;

internal interface IHandler<TEntity>
{
    void SelectContact(out TEntity? contact, out string message);
    void AddContact(out string? message);
    void DeleteContact(TEntity contact, out string? message);
    void UpdateContact(TEntity contact, out string? message);
}