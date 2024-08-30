namespace PhoneBook.Interfaces.Handlers;

internal interface IDynamicEntriesHandler
{
    string HandleDynamicEntries(string title, params string[] entries);
}