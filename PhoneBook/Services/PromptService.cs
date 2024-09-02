using PhoneBook.Enums;
using PhoneBook.Interfaces.Strategies;
using PhoneBook.Model;
using PhoneBook.Strategies.EditStrategies;
using Spectre.Console;

namespace PhoneBook.Services;

internal static class PromptService
{
    private static readonly Dictionary<ContactEditOptions, IContactEditStrategy> EditStrategies =
        new()
        {
            { ContactEditOptions.FirstName, new FirstNameEditStrategy() },
            { ContactEditOptions.LastName, new LastNameEditStrategy() },
            { ContactEditOptions.Phone, new PhoneEditStrategy() },
            { ContactEditOptions.Email, new EmailEditStrategy() },
            { ContactEditOptions.Group, new GroupNameEditStrategy() }
        };

    public static void PromptStrategyResolver(Contact contact, params ContactEditOptions[] options)
    {
        foreach (var option in options)
        {
            if (EditStrategies.TryGetValue(option, out var strategy))
            {
                strategy.Edit(contact);
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]No strategy found for {option}[/]");
            }
        }
    }
    
    public static bool ConfirmAction(string prompt) => AnsiConsole.Confirm(prompt);
}