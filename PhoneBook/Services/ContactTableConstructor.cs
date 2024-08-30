using PhoneBook.Interfaces.Services;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Services;

internal class ContactTableConstructor : IContactTableConstructor
{
    public Table CreateContactTable(Contact contact)
    {
        var table = CreateTable();
        var title = DefineHeader(contact);
        
        InitializeTable(table, title);
        AddName(table, contact);
        AddPhoneNumber(table, contact);
        AddEmail(table, contact);

        return table;
    }
    
    private static Table CreateTable() => new ();

    private static void InitializeTable(Table table, string title)
    {
        table.Border(TableBorder.Rounded);
        table.Title(title);
        table.AddColumns("Info type", "Info");
        table.HideHeaders();
        table.HideFooters();
    }

    private static string DefineHeader(Contact contact)
    {
        const string header = "Contact card";
        var contactName = CreateFullName(contact);
        
        var fullHeader = $"{header}\n{contactName}";

        return fullHeader;
    }

    private static string CreateFullName(Contact contact)
    {
        var name = contact.FirstName ?? string.Empty;
        var surname = contact.LastName ?? string.Empty;
        
        var contactName = $"{name} {surname}";

        return contactName;
    }
    
    private static void AddName(Table table, Contact contact)
    {
        const string namePlaceholder = "Name:";
        var contactName = CreateFullName(contact);
        
        table.AddRow(namePlaceholder, contactName);
    }

    private static void AddPhoneNumber(Table table, Contact contact)
    {
        const string phoneNumberPlaceholder = "Phone Number:";
        var phoneNumber = contact.PhoneNumber ?? string.Empty;
        
        table.AddRow(phoneNumberPlaceholder, phoneNumber);
    }

    private static void AddEmail(Table table, Contact contact)
    {
        const string emailPlaceholder = "Email:";
        var email = contact.Email ?? string.Empty;
        
        table.AddRow(emailPlaceholder, email);
    }
}