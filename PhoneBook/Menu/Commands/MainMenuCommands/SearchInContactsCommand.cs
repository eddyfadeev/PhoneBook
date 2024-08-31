using PhoneBook.Enums;
using PhoneBook.Handlers;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu.Command;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class SearchInContactsCommand : BaseMainMenuCommand
{

    public SearchInContactsCommand(MenuHandler<SearchMenu> menuHandler) : base(menuHandler)
    {
    }
}