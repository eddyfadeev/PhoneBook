using System.Text.RegularExpressions;

namespace PhoneBook.Services;

internal static partial class ValidationService
{
    public static bool IsValidEmail(string input) =>
        EmailValidationRegex().IsMatch(input);

    public static bool IsValidPhoneNumber(string input) =>
        PhoneValidationOption().IsMatch(input);
    
    
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{1,}$")]
    private static partial Regex EmailValidationRegex();
    
    [GeneratedRegex(@"^\+?\s*\d{10,12}$")]
    private static partial Regex PhoneValidationOption();
}