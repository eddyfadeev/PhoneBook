using System.ComponentModel;

namespace PhoneBook.Enums;

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