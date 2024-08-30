using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

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