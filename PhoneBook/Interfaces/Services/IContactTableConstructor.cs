using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Interfaces.Services;

internal interface IContactTableConstructor
{
    Table CreateContactTable(Contact contact);
}