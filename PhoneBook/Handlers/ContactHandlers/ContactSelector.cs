using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Handlers.ContactHandlers;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;

namespace PhoneBook.Handlers.ContactHandlers;

internal class ContactSelector : IContactSelector
{
    private readonly IRepository<Contact> _contactRepository;
    private readonly IDynamicEntriesHandler _dynamicEntriesHandler;

    public ContactSelector(IRepository<Contact> contactRepository, IDynamicEntriesHandler dynamicEntriesHandler)
    {
        _contactRepository = contactRepository;
        _dynamicEntriesHandler = dynamicEntriesHandler;
    }
    
    public void SelectContact(out Contact? contact, out string message)
    {
        var contacts = _contactRepository.GetAllContacts();
        if (contacts.Length == 0)
        {
            message = NoContactsInTheDatabase;
            contact = default;
            return;
        }
        
        var selectedContact = 
            _dynamicEntriesHandler.HandleDynamicEntries(ContactsHandlerTitle, contacts);

        contact = selectedContact;

        message = ContactRetrieved;
    }
}