using PhoneBook.Enums;
using PhoneBook.Interfaces.View.Command;

namespace PhoneBook.Interfaces.View.Factory.Initializer;

internal interface IMenuEntriesInitializer<TEnum> 
    where TEnum : Enum
{
    Dictionary<TEnum, Func<ICommand>> InitializeEntries();
}