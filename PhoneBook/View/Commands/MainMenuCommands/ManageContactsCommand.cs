using PhoneBook.Enums;
using PhoneBook.Handlers;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.View.Command;

namespace PhoneBook.View.Commands.MainMenuCommands;

internal sealed class ManageContactsCommand : ICommand
{
    private readonly IMenuHandler _menuHandler;
    
    public ManageContactsCommand(IMenuHandler menuHandler)
    {
        _menuHandler = menuHandler;
    }
    
    public void Execute()
    {
        _menuHandler.HandleMenu();
    }
}