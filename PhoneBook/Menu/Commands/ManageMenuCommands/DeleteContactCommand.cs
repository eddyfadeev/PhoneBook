﻿using PhoneBook.Interfaces.Handlers;
using PhoneBook.Interfaces.Services;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Menu.Commands.ManageMenuCommands;

internal class DeleteContactCommand : DisplayingContactsCommand
{
    private readonly IContactsHandler _contactsHandler;
    
    public DeleteContactCommand(IContactsHandler contactsHandler, IContactTableConstructor contactTableConstructor) : 
        base(contactsHandler, contactTableConstructor)
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
        
        bool delete = AnsiConsole.Confirm("Are you sure you want to delete this contact?");

        if (!delete)
        {
            return;
        }
        
        _contactsHandler.DeleteContact(contact, out var resultMessage);
        
        AnsiConsole.MarkupLine(resultMessage);
        HelperService.PressAnyKey();
    }
}