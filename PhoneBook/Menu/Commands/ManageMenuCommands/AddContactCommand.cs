using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class AddContactCommand : ICommand
{
    private readonly IRepository<Contact> _contactRepository;
    
    public AddContactCommand(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public void Execute()
    {
        var name = AskUser("Enter name:");
        var surname = AskUser("Enter surname:");
        var phone = AskUser("Enter phone:");
        var email = AskUser("Enter email:");
        
        var contact = new Contact()
        {
            FirstName = name,
            LastName = surname,
            PhoneNumber = phone,
            Email = email
        };
        _contactRepository.AddContact(contact);
    }
    
    private string AskUser(string message) => 
        AnsiConsole.Ask<string>(message);
}