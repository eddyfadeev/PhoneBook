using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Menu.Commands.ManageMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class ManageMenuEntries : IMenuEntriesInitializer<ManageMenu>
{
    private readonly IRepository<Contact> _contactRepository;
    
    public ManageMenuEntries(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public Dictionary<ManageMenu, Func<ICommand>> InitializeEntries() =>
        new()
        {
            { ManageMenu.Add, () => new AddContactCommand(_contactRepository) },
            { ManageMenu.Edit, () => new EditContactCommand() },
            { ManageMenu.Delete, () => new DeleteContactCommand() },
            { ManageMenu.Back, () => throw new ReturnToMainMenu() }
        };
}