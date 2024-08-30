using System.ComponentModel;

namespace PhoneBook.Enums;

internal enum MainMenu
{
    [Description("Search for a contact")]
    SearchInContacts,
    [Description("View all contacts")]
    ViewAllContacts,
    [Description("Manage contacts")]
    ManageContacts,
    [Description("Exit")]
    Exit
}