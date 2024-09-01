using PhoneBook.Interfaces.Handlers.ContactHandlers;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;
using PhoneBook.Services;

namespace PhoneBook.Handlers.ContactHandlers;

internal class ContactDeleter : IContactDeleter
{
    private readonly IRepository<Contact> _contactRepository;

    public ContactDeleter(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public void DeleteContact(Contact contact, out string? message)
    {
        bool delete = HelperService.ConfirmAction(DeletePrompt);

        if (!delete)
        {
            message = default;
            return;
        }
        
        var result = _contactRepository.DeleteContact(contact);
        
        message = result switch
        {
            > 0 => ContactDeleted,
            0 => ContactWasNotDeleted,
            _ => default
        };
    }
}