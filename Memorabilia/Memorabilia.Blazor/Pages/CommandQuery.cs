namespace Memorabilia.Blazor.Pages;

public abstract class CommandQuery : NavigationItem
{
    [Inject]
    public IMediator Mediator { get; set; }
}
