using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.View.Command;
using PhoneBook.Interfaces.View.Factory.Initializer;
using PhoneBook.View.Commands.ManageMenuCommands;

namespace PhoneBook.View.Factory.Initializers;

internal sealed class ManageMenuEntries : IMenuEntriesInitializer<ManageMenu>
{
    public Dictionary<ManageMenu, Func<ICommand>> InitializeEntries() =>
        new()
        {
            { ManageMenu.Add, () => new AddContactCommand() },
            { ManageMenu.Edit, () => new EditContactCommand() },
            { ManageMenu.Delete, () => new DeleteContactCommand() },
            { ManageMenu.Back, () => throw new ReturnToMainMenu() }
        };
}