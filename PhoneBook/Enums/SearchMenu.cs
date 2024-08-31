using System.ComponentModel;

namespace PhoneBook.Enums;

[Description("Search Menu")]
internal enum SearchMenu
{
    [Description("Search by name")]
    ByName,
    [Description("Search by phone number")]
    ByPhoneNumber,
    [Description("Search by email")]
    ByEmail,
    [Description("Back")]
    Back
}