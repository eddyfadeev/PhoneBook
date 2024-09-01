using PhoneBook.Enums;
using PhoneBook.Handlers;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class SearchInContactsCommand : BaseMainMenuCommand
{

    public SearchInContactsCommand(MenuHandler<SearchMenu> menuHandler) : base(menuHandler)
    {
    }
}