using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Handlers;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Handlers.ContactHandlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Interfaces.Services;
using PhoneBook.Menu.Commands.MainMenuCommands;
using PhoneBook.Menu.Commands.ManageMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class MainMenuEntries : IMenuEntriesInitializer<MainMenu>
{
    private readonly MenuHandler<ManageMenu> _manageMenuHandler;
    private readonly MenuHandler<SearchMenu> _searchMenuHandler;
    private readonly IContactSelector _contactSelector;
    private readonly IContactTableConstructor _contactTableConstructor;

    public MainMenuEntries(
        MenuHandler<ManageMenu> manageMenuHandler, 
        MenuHandler<SearchMenu> searchMenuHandler,
        IContactSelector contactSelector,
        IContactTableConstructor contactTableConstructor
        )
    {
        _manageMenuHandler = manageMenuHandler;
        _searchMenuHandler = searchMenuHandler;
        _contactSelector = contactSelector;
        _contactTableConstructor = contactTableConstructor;
    }
    
    public Dictionary<MainMenu, Func<ICommand>> InitializeEntries() => 
        new()
        {
            { MainMenu.SearchInContacts, () => new SearchInContactsCommand(_searchMenuHandler) },
            { MainMenu.ViewAllContacts, () => new ViewAllContactsCommand(_contactSelector, _contactTableConstructor) },
            { MainMenu.ManageContacts, () => new ManageContactsCommand(_manageMenuHandler) },
            { MainMenu.Exit, () => throw new ExitApplication()}
        };
}