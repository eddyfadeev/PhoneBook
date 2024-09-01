using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Model;
using PhoneBook.Services;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class ViewAllContactsCommand : DisplayingContactsCommand
{
    private readonly IHandler<Contact> _handler;
    
    public ViewAllContactsCommand(
        IHandler<Contact> handler,
        IContactTableConstructor contactTableConstructor
        ) : base(contactTableConstructor)
    {
        _handler = handler;
    }
    
    public override void Execute()
    {
        _handler.SelectContact(out var contact, out var message);

        if (ContactIsNull(contact, message))
        {
            return;
        }
        
        DisplayContact(contact);

        HelperService.PressAnyKey();
    }
}