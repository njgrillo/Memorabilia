namespace Memorabilia.Blazor.Pages.Home;

public partial class Home
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected HomeModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await Mediator.Send(new GetHome());
    }
}
