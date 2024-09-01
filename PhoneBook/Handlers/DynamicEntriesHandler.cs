using PhoneBook.Interfaces.Handlers;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Handlers;

internal class DynamicEntriesHandler : IDynamicEntriesHandler
{
    public Contact HandleDynamicEntries(string title, params Contact[] entries) => 
        AnsiConsole.Prompt(GetSelectionPrompt(title, entries));
    
    private static SelectionPrompt<Contact> GetSelectionPrompt(string title, params Contact[] entries)
    {
        const int maxCountPerPage = 4;
        var selectionPrompt = new SelectionPrompt<Contact>()
            .Title(title);
        
        selectionPrompt.AddChoices(entries);

        selectionPrompt.PageSize(maxCountPerPage);
        return selectionPrompt;
    }
}