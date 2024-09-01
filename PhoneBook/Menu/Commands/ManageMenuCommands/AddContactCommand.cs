using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Model;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class AddContactCommand : ICommand
{
    private readonly IHandler<Contact> _handler;
    
    public AddContactCommand(IHandler<Contact> handler)
    {
        _handler = handler;
    }
    
    public void Execute()
    {
        _handler.AddContact(out var message);
        
        AnsiConsole.MarkupLine(message ?? ProblemWithCommand);
        HelperService.PressAnyKey();
    }
}