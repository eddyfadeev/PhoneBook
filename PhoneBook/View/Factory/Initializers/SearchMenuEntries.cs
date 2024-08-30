using PhoneBook.Enums;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces.View.Command;
using PhoneBook.Interfaces.View.Factory.Initializer;
using PhoneBook.View.Commands.SearchMenuCommands;

namespace PhoneBook.View.Factory.Initializers;

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