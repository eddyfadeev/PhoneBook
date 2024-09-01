using PhoneBook.Enums;
using PhoneBook.Interfaces.Handlers.ContactHandlers;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;
using PhoneBook.Services;

namespace PhoneBook.Handlers.ContactHandlers;

internal class ContactAdder : IContactAdder
{
    private readonly IRepository<Contact> _contactRepository;

    public ContactAdder(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public void AddContact(out string? message)
    {
        var contact = CreateContact();
        
        var result = _contactRepository.AddContact(contact);

        message = result switch
        {
            > 0 => ContactAdded,
            0 => ContactWasNotAdded,
            _ => default
        };
    }
    
    private static Contact CreateContact()
    {
        var contact = new Contact();
        var createOptions = 
            Enum.GetValues(typeof(ContactEditOptions))
                .Cast<ContactEditOptions>()
                .ToArray();
        
        PromptService.PromptStrategyResolver(contact, createOptions);

        return contact;
    }
}