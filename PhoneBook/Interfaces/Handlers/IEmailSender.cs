using PhoneBook.Model;

namespace PhoneBook.Interfaces.Handlers;

internal interface IEmailSender
{
    void SendEmail(Contact contact);
}