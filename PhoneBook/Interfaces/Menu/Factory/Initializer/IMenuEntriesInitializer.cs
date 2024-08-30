using PhoneBook.Interfaces.Menu.Command;

namespace PhoneBook.Interfaces.Menu.Factory.Initializer;

internal interface IMenuEntriesInitializer<TEnum> 
    where TEnum : Enum
{
    Dictionary<TEnum, Func<ICommand>> InitializeEntries();
}