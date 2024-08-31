using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Interfaces.Services;
using PhoneBook.Menu.Commands.ManageMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class ManageMenuEntries : IMenuEntriesInitializer<ManageMenu>
{
    private readonly IRepository<Contact> _contactRepository;
    private readonly IContactTableConstructor _contactTableConstructor;
    private readonly IContactsHandler _contactsHandler;
    
    public ManageMenuEntries(IRepository<Contact> contactRepository, IContactTableConstructor contactTableConstructor, IContactsHandler contactsHandler)
    {
        _contactRepository = contactRepository;
        _contactTableConstructor = contactTableConstructor;
        _contactsHandler = contactsHandler;
    }
    
    public Dictionary<ManageMenu, Func<ICommand>> InitializeEntries() =>
        new()
        {
            { ManageMenu.Add, () => new AddContactCommand(_contactRepository) },
            { ManageMenu.Edit, () => new EditContactCommand(_contactsHandler, _contactTableConstructor) },
            { ManageMenu.Delete, () => new DeleteContactCommand(_contactsHandler, _contactTableConstructor) },
            { ManageMenu.Back, () => throw new ReturnToMainMenu() }
        };
}