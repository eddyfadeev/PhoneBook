using PhoneBook.Interfaces.View.Command;

namespace PhoneBook.Interfaces.View.Factory;

internal interface IMenuCommandsFactory<in TMenu>
{
    ICommand Create(TMenu menuEntry);
}