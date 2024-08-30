using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Handlers;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.View.Command;
using PhoneBook.Interfaces.View.Factory.Initializer;
using PhoneBook.View.Commands.MainMenuCommands;

namespace PhoneBook.View.Factory.Initializers;

internal sealed class MainMenuEntries : IMenuEntriesInitializer<MainMenu>
{
    private readonly IMenuHandler _menuHandler;

    public MainMenuEntries(IMenuHandler menuHandler)
    {
        _menuHandler = menuHandler;
    }
    
    public Dictionary<MainMenu, Func<ICommand>> InitializeEntries() => 
        new()
        {
            { MainMenu.SearchInContacts, () => new SearchInContactsCommand(_menuHandler) },
            { MainMenu.ViewAllContacts, () => new ViewAllContactsCommand() },
            { MainMenu.ManageContacts, () => new ManageContactsCommand(_menuHandler) },
            { MainMenu.Exit, () => throw new ExitApplication()}
        };
}