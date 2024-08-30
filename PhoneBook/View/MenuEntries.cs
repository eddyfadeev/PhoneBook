using PhoneBook.Extensions;
using PhoneBook.Interfaces.View;
using Spectre.Console;

namespace PhoneBook.View;

internal class MenuEntries : IMenuEntries
{
    public SelectionPrompt<string> GetMenuEntries<TEnum>(string title) 
        where TEnum : struct, Enum =>
        new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(GetDescriptions<TEnum>());

    private static string[] GetDescriptions<TEnum>()
        where TEnum : struct, Enum =>
        Enum.GetValues<TEnum>()
            .Select(EnumExtensions.GetDescription)
            .ToArray();
}