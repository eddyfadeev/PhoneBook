using PhoneBook.Extensions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Interfaces.Services;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class ViewAllContactsCommand : ICommand
{
    private readonly IRepository<Contact> _contactRepository;
    private readonly IDynamicEntriesHandler _dynamicEntriesHandler;
    private readonly IContactTableConstructor _contactTableConstructor;
    
    public ViewAllContactsCommand(
        IRepository<Contact> contactRepository, 
        IDynamicEntriesHandler dynamicEntriesHandler,
        IContactTableConstructor contactTableConstructor
        )
    {
        _contactRepository = contactRepository;
        _dynamicEntriesHandler = dynamicEntriesHandler;
        _contactTableConstructor = contactTableConstructor;
    }
    
    public void Execute()
    {
        var contacts = _contactRepository.GetAllContacts();
        
        if (contacts.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No contacts found.[/]");
            return;
        }

        var contactNames = contacts.NamesToArray();
        
        var selectedContact = _dynamicEntriesHandler.HandleDynamicEntries("Select contact to view details:", contactNames);
        
        var contact = contacts.FindContact(selectedContact);
        
        if (contact is null)
        {
            AnsiConsole.MarkupLine("[red]Contact not found.[/]");
            return;
        }
        
        var contactTable = _contactTableConstructor.CreateContactTable(contact);
        
        AnsiConsole.Write(contactTable);
    }
}