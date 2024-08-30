using PhoneBook.Extensions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.View;
using PhoneBook.Interfaces.View.Factory;
using Spectre.Console;

namespace PhoneBook.Handlers;

internal class MenuHandler<TMenu> : IMenuHandler
    where TMenu : struct, Enum
{
    private readonly IMenuCommandsFactory<TMenu> _menuCommandsFactory;
    private readonly SelectionPrompt<string> _menuEntries;
    
    public MenuHandler(IMenuCommandsFactory<TMenu> menuCommandsFactory, IMenuEntries menuEntries)
    {
        _menuCommandsFactory = menuCommandsFactory;
        _menuEntries = menuEntries.GetMenuEntries<TMenu>(string.Empty);
    }
    
    public void HandleMenu()
    {
        var userChoice = HandleUserChoice(_menuEntries);
        _menuCommandsFactory.Create(userChoice).Execute();
    }

    private static TMenu HandleUserChoice(SelectionPrompt<string> menuEntries)
    {
        var userChoice = AnsiConsole.Prompt(menuEntries);
        
        return EnumExtensions.GetEnumValueFromDescription<TMenu>(userChoice);
    }
}