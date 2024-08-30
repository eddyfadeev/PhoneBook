using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Menu.Factory.Initializer;
using PhoneBook.Menu.Commands.SearchMenuCommands;

namespace PhoneBook.Menu.Factory.Initializers;

internal sealed class SearchMenuEntries : IMenuEntriesInitializer<SearchMenu>
{
    public Dictionary<SearchMenu, Func<ICommand>> InitializeEntries() =>
        new()
        {
            { SearchMenu.ByName, () => new SearchByNameCommand() },
            { SearchMenu.ByPhoneNumber, () => new SearchByPhoneNumberCommand() },
            { SearchMenu.ByEmail, () => new SearchByEmailCommand() },
            { SearchMenu.Back, () => throw new ReturnToMainMenu() }
        };
}