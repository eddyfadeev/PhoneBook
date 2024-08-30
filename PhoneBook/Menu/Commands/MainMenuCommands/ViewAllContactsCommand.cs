using PhoneBook.Interfaces.Menu.Command;
using PhoneBook.Interfaces.Repository;
using PhoneBook.Model;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class ViewAllContactsCommand : ICommand
{
    private readonly IRepository<Contact> _contactRepository;
    
    public ViewAllContactsCommand(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    public void Execute()
    {
        var contacts = _contactRepository.GetAllContacts();
        foreach (var contact in contacts)
        {
            System.Console.WriteLine(contact);
        }
    }
}