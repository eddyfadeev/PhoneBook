using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class SearchInContactsCommand : ICommand
{
    private readonly IMenuHandler _menuHandler;
    
    public SearchInContactsCommand(IMenuHandler menuHandler)
    {
        _menuHandler = menuHandler;
    }
    
    public void Execute()
    {
        _menuHandler.HandleMenu();
    }
}