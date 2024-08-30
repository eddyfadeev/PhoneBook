using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Menu.Commands.MainMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class MainMenuEntries : IMenuEntriesInitializer<MainMenu>
{
    private readonly IMenuHandler _menuHandler;
    private readonly IRepository<Contact> _contactRepository;

    public MainMenuEntries(IMenuHandler menuHandler, IRepository<Contact> contactRepository)
    {
        _menuHandler = menuHandler;
        _contactRepository = contactRepository;
    }
    
    public Dictionary<MainMenu, Func<ICommand>> InitializeEntries() => 
        new()
        {
            { MainMenu.SearchInContacts, () => new SearchInContactsCommand(_menuHandler) },
            { MainMenu.ViewAllContacts, () => new ViewAllContactsCommand(_contactRepository) },
            { MainMenu.ManageContacts, () => new ManageContactsCommand(_menuHandler) },
            { MainMenu.Exit, () => throw new ExitApplication()}
        };
}