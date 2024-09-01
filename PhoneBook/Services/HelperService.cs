using Spectre.Console;

namespace PhoneBook.Services;

internal static class HelperService
{
    public static void PressAnyKey()
    {
        AnsiConsole.MarkupLine(PressAnyKeyOption);
        Console.ReadKey();
    }
}