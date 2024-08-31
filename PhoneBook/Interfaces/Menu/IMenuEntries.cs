using Spectre.Console;

namespace PhoneBook.Interfaces.Menu;

internal interface IMenuEntries
{
    SelectionPrompt<string> GetMenuEntries<TEnum>(string title)
        where TEnum : struct, Enum;
}