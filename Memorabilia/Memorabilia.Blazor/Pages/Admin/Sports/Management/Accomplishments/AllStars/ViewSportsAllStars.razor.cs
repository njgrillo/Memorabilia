namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.Accomplishments.AllStars;

public partial class ViewSportsAllStars
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected Sport Sport
        => Sport.Find(SportId);

    protected int SportId { get; set; }

    protected SportAllStarsViewModel ViewModel { get; set; }
        = new();

    private async Task OnSportChanged(int sportId)
    {
        SportId = sportId;

        ViewModel = await Mediator.Send(new GetSportAllStars(SportId));
    }
}
