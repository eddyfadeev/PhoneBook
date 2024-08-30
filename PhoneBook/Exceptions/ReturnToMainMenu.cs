namespace PhoneBook.Exceptions;

public class ReturnToMainMenu : Exception
{
    private const string DefaultMessage = "Returning to the main menu...";
    public ReturnToMainMenu() : base(DefaultMessage)
    {
    }
    
    public ReturnToMainMenu(string message) : base(message)
    {
    }
    
    public ReturnToMainMenu(string message, Exception inner) : base(message, inner)
    {
    }
}