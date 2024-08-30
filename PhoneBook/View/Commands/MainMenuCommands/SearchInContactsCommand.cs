using PhoneBook.Enums;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.View.Command;

namespace PhoneBook.View.Commands.MainMenuCommands;

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