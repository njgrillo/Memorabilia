namespace Memorabilia.Blazor.Pages.Home;

public partial class Home
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected HomeModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetHome());
    }
}
