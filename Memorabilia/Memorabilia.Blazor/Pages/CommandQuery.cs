namespace Memorabilia.Blazor.Pages;

public abstract class CommandQuery : NavigationItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }
}
