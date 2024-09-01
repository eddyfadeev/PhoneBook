using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class EditContactCommand : DisplayingContactsCommand
{
    private readonly IContactsHandler _contactsHandler;
    
    public EditContactCommand(IContactsHandler contactsHandler, IContactTableConstructor contactTableConstructor
    ) : base(contactsHandler, contactTableConstructor)
    {
        _contactsHandler = contactsHandler;
    }

    public override void Execute()
    {
        _contactsHandler.SelectContact(out var contact, out var message);

        if (ContactIsNull(contact, message))
        {
            return;
        }
        
        DisplayContact(contact);

        _contactsHandler.UpdateContact(contact, out var updateMessage);
        
        AnsiConsole.MarkupLine(updateMessage ?? UpdateCancelled);
        HelperService.PressAnyKey();
    }

    
}