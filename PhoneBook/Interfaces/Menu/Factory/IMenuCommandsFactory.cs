using PhoneBook.Interfaces.Menu.Command;

namespace PhoneBook.Interfaces.Menu.Factory;

internal interface IMenuCommandsFactory<in TMenu>
{
    ICommand Create(TMenu menuEntry);
}