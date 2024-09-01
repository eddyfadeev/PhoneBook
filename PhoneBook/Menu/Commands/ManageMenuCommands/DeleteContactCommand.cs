using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Model;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class DeleteContactCommand : DisplayingContactsCommand
{
    private readonly IHandler<Contact> _handler;
    
    public DeleteContactCommand(IHandler<Contact> handler, IContactTableConstructor contactTableConstructor) : 
        base(contactTableConstructor)
    {
        _handler = handler;
    }

    public override void Execute()
    {
        _handler.SelectContact(out var contact, out var message);

        if (ContactIsNull(contact, message))
        {
            return;
        }
        
        DisplayContact(contact);
        
        _handler.DeleteContact(contact, out var resultMessage);
        
        AnsiConsole.MarkupLine(resultMessage ?? DeleteCancelled);
        HelperService.PressAnyKey();
    }
}