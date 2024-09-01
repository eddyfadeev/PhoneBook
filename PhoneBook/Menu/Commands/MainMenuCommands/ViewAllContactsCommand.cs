using PhoneBook.Interfaces.Handlers.ContactHandlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Services;

namespace PhoneBook.Menu.Commands.MainMenuCommands;

internal sealed class ViewAllContactsCommand : DisplayingContactsCommand
{
    private readonly IContactSelector _contactSelector;
    
    public ViewAllContactsCommand(
        IContactSelector contactSelector,
        IContactTableConstructor contactTableConstructor
        ) : base(contactTableConstructor)
    {
        _contactSelector = contactSelector;
    }
    
    public override void Execute()
    {
        _contactSelector.SelectContact(out var contact, out var message);

        if (ContactIsNull(contact, message))
        {
            return;
        }
        
        DisplayContact(contact);

        HelperService.PressAnyKey();
    }
}