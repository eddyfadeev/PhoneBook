namespace PhoneBook.Messages;

internal static class Messages
{
    #region Problems with contact
    public const string ContactWasNotDeleted = "[red]Contact wasn't deleted.[/]";
    public const string ContactWasNotUpdated = "[red]Contact wasn't updated.[/]";
    public const string ContactWasNotAdded = "[red]Contact wasn't added.[/]";
    #endregion

    #region Success with contacts
    public const string ContactRetrieved = "[green]Contact retrieved.[/]";
    public const string ContactAdded = "[green]Contact added[/]";
    public const string ContactDeleted = "[green]Contact deleted[/]";
    public const string ContactUpdated = "[green]Contact updated[/]";
    #endregion

    #region Database and other problems
    public const string ContactNotFound = "[red]Contact not found.[/]";
    public const string NoContactsInTheDatabase = "[red]No contacts found.[/]";
    public const string ProblemWithCommand = "[red]Problem executing command.[/]";
    #endregion
    
    #region General messages and options

    public const string BackOption = "Back";
    public const string UpdateCancelled = "[red]Update cancelled.[/]";
    public const string DeleteCancelled = "[red]Delete cancelled.[/]";
    public const string UnknownOption = "[red]Unknown option[/]";
    public const string PressAnyKeyOption = "[white]Press any key to continue...[/]";
    public const string ReturningToPreviousMenu = "[white]Returning to previous menu.[/]";

    #endregion
    
    #region Prompts

    public const string AskName = "[white]Enter a name:[/]";
    public const string AskLastName = "[white]Enter a last name:[/]";
    public const string AskPhone = "[white]Enter a phone number:[/]";
    public const string AskEmail = "[white]Enter an email:[/]";
    public const string ContactsHandlerTitle = "Select contact from the list:";
    
    #endregion
}