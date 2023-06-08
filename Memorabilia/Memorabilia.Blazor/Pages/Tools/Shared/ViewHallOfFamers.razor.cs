namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewHallOfFamers 
    : ViewSportTools<HallOfFameModel>
{
    [Parameter]
    public bool DisplayBallot { get; set; }

    [Parameter]
    public bool DisplayVotePercentage { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected HallOfFamesModel Model = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel));
    }

    private async Task OnInputChange(int inductionYear)
    {
        Model = await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel, inductionYear > 0 ? inductionYear : null));
    }
}
