using PhoneBook.Extensions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;

namespace PhoneBook.Handlers;

internal class ContactsHandler : IContactsHandler
{
    private const string MenuTitle = "Select contact from the list:";
    
    private readonly IRepository<Contact> _contactRepository;
    private readonly IDynamicEntriesHandler _dynamicEntriesHandler;

    public ContactsHandler(IRepository<Contact> contactRepository,
        IDynamicEntriesHandler dynamicEntriesHandler)
    {
        _contactRepository = contactRepository;
        _dynamicEntriesHandler = dynamicEntriesHandler;
    }

    public void SelectContact(out Contact? contact, out string message)
    {
        var contacts = _contactRepository.GetAllContacts();
        if (contacts.Count == 0)
        {
            message = NoContactsInTheDatabase;
            contact = default;
            return;
        }
        
        var contactNames = contacts.NamesToArray();
        var selectedContact = 
            _dynamicEntriesHandler.HandleDynamicEntries(MenuTitle, contactNames);

        if (selectedContact.Equals(BackOption))
        {
            message = ReturningToPreviousMenu;
            contact = default;
            return;
        }
        
        contact = contacts.FindContact(selectedContact);

        message = contact is null ? ContactNotFound : ContactRetrieved;
    }

    public void DeleteContact(Contact contact, out string message)
    {
        var result = _contactRepository.DeleteContact(contact);

        message = result switch
        {
            > 0 => ContactDeleted,
            < 0 => ProblemWithCommand,
            _ => ContactWasNotDeleted
        };
    }

    public void EditContact(Contact contact, out string message)
    {
        var result = _contactRepository.UpdateContact(contact);

        message = result switch
        {
            > 0 => ContactUpdated,
            < 0 => ProblemWithCommand,
            _ => ContactWasNotUpdated
        };
    }
}