using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class EditContactCommand : DisplayingContactsCommand
{
    private readonly IContactsHandler _contactsHandler;
    
    public EditContactCommand(IContactsHandler contactsHandler, IContactTableConstructor contactTableConstructor) : base(contactsHandler, contactTableConstructor)
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
        
        
    }
}