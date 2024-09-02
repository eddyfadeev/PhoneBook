using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace PhoneBook.Email;

internal class EmailManager : IEmailManager
{
    private const string CredentialsSection = "EmailCredentials";
    private const string Server = "Server";
    private const string Port = "Port";
    private const string Login = "Login";
    private const string Password = "Password";
    private const int DefaultPort = 587;
    
    private readonly IConfiguration _connectionConfiguration;
    
    private readonly string _serverAddress;
    private readonly int _port;
    private readonly string _login;
    private readonly string _password;

    public EmailManager(IConfiguration configuration)
    {
        _connectionConfiguration = configuration;

        _serverAddress = ConfigureServerAddress();
        _port = ConfigurePort();
        _login = ConfigureLogin();
        _password = ConfigurePassword();
    }

    public SmtpClient GetSmtpClient() =>
        new ()
        {
            Host = _serverAddress,
            Port = _port,
            Credentials = new NetworkCredential(userName: _login, password: _password),
            EnableSsl = true
        };

    private string ConfigureServerAddress() => 
        _connectionConfiguration.GetSection(CredentialsSection)[Server];

    private int ConfigurePort()
    {
        int configuredPort;
        
        try
        {
            string? port = _connectionConfiguration.GetSection(CredentialsSection)[Port];
            configuredPort = Convert.ToInt32(port);
        }
        catch (Exception)
        {
            AnsiConsole.MarkupLine($"[red]Error reading port from configuration. Defaulting to {DefaultPort}.[/]");
            configuredPort = DefaultPort;
        }
        
        return configuredPort;
    }

    private string ConfigureLogin() =>
        _connectionConfiguration.GetSection(CredentialsSection)[Login];
    
    private string ConfigurePassword() =>
        _connectionConfiguration.GetSection(CredentialsSection)[Password];
}

internal interface IEmailManager
{
    SmtpClient GetSmtpClient();
}