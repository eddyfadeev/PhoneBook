using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using PhoneBook.Email;
using PhoneBook.Interfaces.Handlers;
using PhoneBook.Model;
using PhoneBook.Services;
using Spectre.Console;

namespace PhoneBook.Handlers;

internal class EmailSender : IEmailSender
{
    private readonly IEmailManager _emailManager;
    private readonly string _email;

    public EmailSender(IEmailManager emailManager, IConfiguration configuration)
    {
        const string section = "EmailCredentials";
        const string emailSubsection = "Login";
        
        _emailManager = emailManager;
        _email = configuration.GetSection(section)[emailSubsection]!;
    }

    public void SendEmail(Contact contact)
    {
        AskForText(out string subject, out string body);
        var email = ComposeEmail(contact, subject, body);

        try
        {
            using var client = _emailManager.GetSmtpClient();
            client.Send(email);
            AnsiConsole.MarkupLine(MessageWasSuccessfullySent);
        }
        catch (SmtpException e)
        {
            AnsiConsole.WriteException(e);
            AnsiConsole.WriteLine(
                "If it is a authentication problem and you are using google email, follow this link:");
            AnsiConsole.WriteLine("https://support.google.com/accounts/answer/185833");
        }
        catch (Exception e)
        {
            AnsiConsole.WriteException(e);
        }
    }
    
    private static void AskForText(out string subject, out string body)
    {
        subject = PromptService.PromptForMessage(EnterSubject);
        body = PromptService.PromptForMessage(EnterMessage);
    }

    private MailMessage ComposeEmail(Contact contact, string subject, string body) =>
        new ()
        {
            From = new MailAddress(_email),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
            To = { new MailAddress(contact.Email) }
        };
}