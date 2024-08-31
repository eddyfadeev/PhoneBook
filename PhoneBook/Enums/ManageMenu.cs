using System.ComponentModel;

namespace PhoneBook.Enums;

[Description("Manage Phone Book")]
internal enum ManageMenu
{
    [Description("Add a new contact")]
    Add,
    [Description("Edit a contact")]
    Edit,
    [Description("Delete a contact")]
    Delete,
    [Description("Back")]
    Back
}