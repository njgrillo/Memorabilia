namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewHallOfFamers : ViewSportTools<HallOfFameViewModel>
{
    [Parameter]
    public bool DisplayBallot { get; set; }

    [Parameter]
    public bool DisplayVotePercentage { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private HallOfFamesViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel));
    }

    private async Task OnInputChange(int inductionYear)
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(SportLeagueLevel, inductionYear > 0 ? inductionYear : null));
    }
}
