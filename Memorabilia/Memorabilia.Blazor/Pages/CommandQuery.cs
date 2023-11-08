namespace Memorabilia.Blazor.Pages;

public abstract class CommandQuery : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
}
