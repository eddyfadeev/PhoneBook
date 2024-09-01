using System.Text.RegularExpressions;

namespace PhoneBook.Services;

internal static partial class ValidationService
{
    public static bool IsValidEmail(string input) =>
        EmailValidationRegex().IsMatch(input);
    
    public static bool IsValidPhoneNumber(string input) =>
        PhoneValidationOptionOne().IsMatch(input) ||
        PhoneValidationOptionTwo().IsMatch(input);
    
    
    [GeneratedRegex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$")]
    private static partial Regex EmailValidationRegex();
    
    [GeneratedRegex(@"^\+\d{11,12}$")]
    private static partial Regex PhoneValidationOptionOne();
    
    [GeneratedRegex(@"^\+\d{10,11}$")]
    private static partial Regex PhoneValidationOptionTwo();
}