using PhoneBook.Extensions;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Menu;
using PhoneBook.Interfaces.Menu.Factory;
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
        var title = GetMenuTitle();
        _menuEntries = menuEntries.GetMenuEntries<TMenu>(title);
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

    private static string GetMenuTitle() => 
        EnumTypeExtensions.GetEnumDescription<TMenu>();
}