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
    public const string PressAnyKeyOption = "[white]Press any key to continue...[/]";
    public const string ReturningToPreviousMenu = "[white]Returning to previous menu.[/]";

    #endregion
}