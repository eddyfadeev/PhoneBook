using Spectre.Console;

namespace PhoneBook.Interfaces.View;

internal interface IMenuEntries
{
    SelectionPrompt<string> GetMenuEntries<TEnum>(string title) 
        where TEnum : struct, Enum;
}