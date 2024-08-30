namespace PhoneBook.Exceptions;

public class ExitApplication : Exception
{
    private const string DefaultMessage = "Exiting the application...";
    public ExitApplication() : base(DefaultMessage)
    {
    }
    
    public ExitApplication(string message) : base(message)
    {
    }
    
    public ExitApplication(string message, Exception inner) : base(message, inner)
    {
    }
}