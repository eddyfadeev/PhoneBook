using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Services;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class ViewAllContactsCommand : DisplayingContactsCommand
{
    private readonly IContactsHandler _contactsHandler;
    
    public ViewAllContactsCommand(
        IContactsHandler contactsHandler,
        IContactTableConstructor contactTableConstructor
        ) : base(contactsHandler, contactTableConstructor)
    {
        _contactsHandler = contactsHandler;
    }
    
    public override void Execute()
    {
        _contactsHandler.SelectContact(out var contact, out var message);

        if (ContactIsNull(contact, message))
        {
            return;
        }
        
        DisplayContact(contact);

        HelperService.PressAnyKey();
    }
}