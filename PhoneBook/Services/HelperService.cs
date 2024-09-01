using PhoneBook.Enums;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Services;

internal static class HelperService
{
    public static void PressAnyKey()
    {
        AnsiConsole.MarkupLine(PressAnyKeyOption);
        Console.ReadKey();
    }
    
    public static bool ConfirmAction(string prompt) => AnsiConsole.Confirm(prompt);
    
    public static void AskPromptResolver(Contact contact, params ContactEditOptions[] createParams)
    {
        foreach (var param in createParams)
        {
            switch (param)
            {
                case ContactEditOptions.FirstName:
                    contact.FirstName = AskUser(AskName);
                    break;
                case ContactEditOptions.LastName:
                    contact.LastName = AskUser(AskLastName);
                    break;
                case ContactEditOptions.Phone:
                    contact.PhoneNumber = 
                        AskSpecialInput(ContactEditOptions.Phone);
                    break;
                case ContactEditOptions.Email:
                    contact.Email = 
                        AskSpecialInput(ContactEditOptions.Email);
                    break;
                default:
                    AnsiConsole.MarkupLine(UnknownOption);
                    break;
            }
        }
    }
    
    private static string AskUser(string message) => 
        AnsiConsole.Ask<string>(message);
    
    private static string AskSpecialInput(ContactEditOptions validationType)
    {
        var invalidInputMessage = validationType switch
        {
            ContactEditOptions.Phone => InvalidPhoneNumber,
            ContactEditOptions.Email => InvalidEmailAddress,
            _ => throw new ArgumentException($"Message is not found for: {validationType}")
        };

        var message = validationType switch
        {
            ContactEditOptions.Phone => AskPhone,
            ContactEditOptions.Email => AskEmail,
            _ => throw new ArgumentException($"Message is not found for: {validationType}")
        };
        
        while (true)
        {
            AnsiConsole.MarkupLine(message);
            var input = Console.ReadLine();

            if (EnsureValidity(input, validationType))
            {
                return input;
            }
            
            AnsiConsole.MarkupLine(invalidInputMessage);
        }
    }
    
    private static bool EnsureValidity(string? input, ContactEditOptions validationType)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return AnsiConsole.Confirm(LeaveEmpty);
        }
        
        Func<string, bool> validator = validationType switch
        {
            ContactEditOptions.Phone => ValidationService.IsValidPhoneNumber,
            ContactEditOptions.Email => ValidationService.IsValidEmail,
            _ => throw new ArgumentException($"Validator is not found for: {validationType}")
        };

        return validator(input);
    }
}