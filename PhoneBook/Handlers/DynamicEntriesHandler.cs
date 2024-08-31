using PhoneBook.Interfaces.Handlers;
using Spectre.Console;

namespace PhoneBook.Handlers;

public class DynamicEntriesHandler : IDynamicEntriesHandler
{
    public string HandleDynamicEntries(string title, params string[] entries) => 
        AnsiConsole.Prompt(GetSelectionPrompt(title, entries));
    
    private static SelectionPrompt<string> GetSelectionPrompt(string title, params string[] entries)
    {
        var selectionPrompt = new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(entries);
        
        selectionPrompt.AddChoice(BackOption);

        return selectionPrompt;
    }
}