using PhoneBook.Interfaces.View.Command;
using PhoneBook.Interfaces.View.Factory;
using PhoneBook.Interfaces.View.Factory.Initializer;

namespace PhoneBook.View.Factory;

internal class MenuCommandsFactory<TMenu> : IMenuCommandsFactory<TMenu> 
    where TMenu : struct, Enum
{
    private readonly Dictionary<TMenu, Func<ICommand>> _menuCommands;
    
    public MenuCommandsFactory(IMenuEntriesInitializer<TMenu> menuEntriesInitializer)
    {
        _menuCommands = menuEntriesInitializer.InitializeEntries();
    }
    
    public ICommand Create(TMenu menuEntry)
    {
        if (_menuCommands.TryGetValue(menuEntry, out var menuCommand))
        {
            return menuCommand();
        }
        
        throw new InvalidOperationException($"Menu command not found for the { menuCommand }.");
    }
}