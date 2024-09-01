using System.ComponentModel;

namespace PhoneBook.Enums;

internal enum ContactEditOptions
{
    [Description("First Name")]
    FirstName,
    [Description("Last Name")]
    LastName,
    [Description("Phone Number")]
    Phone,
    [Description("Email Address")]
    Email
}