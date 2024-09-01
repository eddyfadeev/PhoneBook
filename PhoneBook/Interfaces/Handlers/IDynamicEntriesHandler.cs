using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers;

internal interface IDynamicEntriesHandler
{
    Contact HandleDynamicEntries(string title, params Contact[] entries);
}