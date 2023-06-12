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

    protected HallOfFamesModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = new(await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel)), Sport);
    }

    private async Task OnInputChange(int inductionYear)
    {
        Model = new(await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel, inductionYear)), Sport)
                {
                    InductionYear = inductionYear
                };
    }
}
