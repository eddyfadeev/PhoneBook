using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Services;
using PhoneBook.Menu.Commands.ManageMenuCommands;
using PhoneBook.Model;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Menu.Commands;

internal abstract class DisplayingContactsCommand : ICommand
{
    private readonly IContactsHandler _contactsHandler;
    private readonly IContactTableConstructor _contactTableConstructor;

    protected DisplayingContactsCommand(IContactsHandler contactsHandler,
        IContactTableConstructor contactTableConstructor)
    {
        _contactsHandler = contactsHandler;
        _contactTableConstructor = contactTableConstructor;
    }

    public abstract void Execute();
    
    private protected void DisplayContact(Contact contact)
    {
        var contactTable = _contactTableConstructor.CreateContactTable(contact);
        
        AnsiConsole.Write(contactTable);
    }

    private protected static bool ContactIsNull(Contact? contact, string message)
    {
        if (contact is null)
        {
            AnsiConsole.MarkupLine(message);
            HelperService.PressAnyKey();
            return true;
        }

        return false;
    }
}