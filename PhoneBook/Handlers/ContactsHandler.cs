using PhoneBook.Enums;
using PhoneBook.Extensions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Handlers;

internal class ContactsHandler : IHandler<Contact>
{
    private readonly IRepository<Contact> _contactRepository;
    private readonly IDynamicEntriesHandler _dynamicEntriesHandler;
    private readonly IMenuEntries _menuEntries;

    public ContactsHandler(IRepository<Contact> contactRepository,
        IDynamicEntriesHandler dynamicEntriesHandler,
        IMenuEntries menuEntries)
    {
        _contactRepository = contactRepository;
        _dynamicEntriesHandler = dynamicEntriesHandler;
        _menuEntries = menuEntries;
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

    public void UpdateContact(Contact contact, out string? message)
    {
        bool update = ConfirmAction(UpdatePrompt);

        if (!update)
        {
            message = default;
            return;
        }

        var requestedChanges = 
            AnsiConsole.Prompt(GetContactEditPrompt())
                .Select(EnumExtensions.GetEnumValueFromDescription<ContactEditOptions>)
                .ToArray();

        UpdateContact(contact, requestedChanges);
        
        var result = _contactRepository.UpdateContact(contact);

        message = result switch
        {
            > 0 => ContactUpdated,
            0 => ContactWasNotUpdated,
            _ => default
        };
    }
    
    public void DeleteContact(Contact contact, out string? message)
    {
        bool delete = ConfirmAction(DeletePrompt);

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
    
    private static bool ConfirmAction(string prompt) => AnsiConsole.Confirm(prompt);
    
    private static string AskUser(string message) => 
        AnsiConsole.Ask<string>(message);
    
    private MultiSelectionPrompt<string> GetContactEditPrompt()
    {
        const string message = "Please select what would you like to edit.\n" +
                               "Do not choose anything and press enter, if do not want to edit the contact.";

        var prompt = _menuEntries.GetSelectableMenuEntries<ContactEditOptions>(message);
        
        return prompt;
    }

    private static void UpdateContact(Contact contact, params ContactEditOptions[] createParams)
    {
        foreach (var param in createParams)
        {
            switch (param)
            {
                case ContactEditOptions.FirstName:
                    contact.FirstName = AskUser(AskName);
                    break;
                case ContactEditOptions.LastName:
                    contact.LastName = AskUser(AskLastName);
                    break;
                case ContactEditOptions.Phone:
                    contact.PhoneNumber = AskUser(AskPhone);
                    break;
                case ContactEditOptions.Email:
                    contact.Email = AskUser(AskEmail);
                    break;
                default:
                    AnsiConsole.MarkupLine(UnknownOption);
                    break;
            }
        }
    }

    private static Contact CreateContact()
    {
        var contact = new Contact();
        var createOptions = 
            Enum.GetValues(typeof(ContactEditOptions))
                .Cast<ContactEditOptions>()
                .ToArray();
        
        UpdateContact(contact, createOptions);

        return contact;
    }
}