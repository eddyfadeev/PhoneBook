using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Interfaces.Services;
using PhoneBook.Menu.Commands.ManageMenuCommands;
using PhoneBook.Model;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class ManageMenuEntries : IMenuEntriesInitializer<ManageMenu>
{
    private readonly IContactTableConstructor _contactTableConstructor;
    private readonly IHandler<Contact> _handler;
    
    public ManageMenuEntries(IContactTableConstructor contactTableConstructor, IHandler<Contact> handler)
    {
        _contactTableConstructor = contactTableConstructor;
        _handler = handler;
    }
    
    public Dictionary<ManageMenu, Func<ICommand>> InitializeEntries() =>
        new()
        {
            { ManageMenu.Add, () => new AddContactCommand(_handler) },
            { ManageMenu.Edit, () => new EditContactCommand(_handler, _contactTableConstructor) },
            { ManageMenu.Delete, () => new DeleteContactCommand(_handler, _contactTableConstructor) },
            { ManageMenu.Back, () => throw new ReturnToMainMenu() }
        };
}