using PhoneBook.Model;

namespace PhoneBook.Extensions;

internal static class ContactsExtensions
{
    public static string[] NamesToArray(this List<Contact> list) => 
        list.Select(c => $"{c.FirstName} {c.LastName}").ToArray();
    
    public static Contact? FindContact(this List<Contact> list, string fullName) => 
        list.Find(
            c => 
                c.FirstName == fullName.Split(" ")[0] && 
                c.LastName == fullName.Split(" ")[1]
                );
}