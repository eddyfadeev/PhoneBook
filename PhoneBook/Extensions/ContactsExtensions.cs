using PhoneBook.Model;

namespace PhoneBook.Extensions;

internal static class ContactsExtensions
{
    public static Dictionary<string, string> ToDictionary(this Contact contact)
    {
        const string defaultValue = "";
        const string defaultGroup = "Unspecified";
        
        return new Dictionary<string, string>
        {
            { "Name: ", $"{contact.FirstName} {contact.LastName ?? defaultValue}" },
            { "Phone: ", $"{contact.PhoneNumber ?? defaultValue}" },
            { "Email: ", $"{contact.Email ?? defaultValue}" },
            { "Group: ", $"{contact.Group ?? defaultGroup}" }
        };
    }

    public static string ExtractName(this Contact contact) => 
        $"{contact.FirstName ?? string.Empty} {contact.LastName ?? string.Empty}";
}