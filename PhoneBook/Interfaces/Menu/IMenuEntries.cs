using Spectre.Console;

namespace PhoneBook.Interfaces.Menu;

internal interface IMenuEntries
{
    SelectionPrompt<string> GetMenuEntries<TEnum>(string title)
        where TEnum : struct, Enum;
    
    public MultiSelectionPrompt<string> GetSelectableMenuEntries<TEnum>(string title)
        where TEnum : struct, Enum;
}