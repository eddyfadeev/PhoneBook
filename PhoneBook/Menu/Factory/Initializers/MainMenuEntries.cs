using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Interfaces.Services;
using PhoneBook.Menu.Commands.MainMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class MainMenuEntries : IMenuEntriesInitializer<MainMenu>
{
    private readonly IMenuHandler _menuHandler;
    private readonly IDynamicEntriesHandler _dynamicEntriesHandler;
    private readonly IRepository<Contact> _contactRepository;
    private readonly IContactTableConstructor _contactTableConstructor;

    public MainMenuEntries(
        IMenuHandler menuHandler, 
        IDynamicEntriesHandler dynamicEntriesHandler, 
        IRepository<Contact> contactRepository,
        IContactTableConstructor contactTableConstructor
        )
    {
        _menuHandler = menuHandler;
        _dynamicEntriesHandler = dynamicEntriesHandler;
        _contactRepository = contactRepository;
        _contactTableConstructor = contactTableConstructor;
    }
    
    public Dictionary<MainMenu, Func<ICommand>> InitializeEntries() => 
        new()
        {
            { MainMenu.SearchInContacts, () => new SearchInContactsCommand(_menuHandler) },
            { MainMenu.ViewAllContacts, () => new ViewAllContactsCommand(_contactRepository, _dynamicEntriesHandler, _contactTableConstructor ) },
            { MainMenu.ManageContacts, () => new ManageContactsCommand(_menuHandler) },
            { MainMenu.Exit, () => throw new ExitApplication()}
        };
}