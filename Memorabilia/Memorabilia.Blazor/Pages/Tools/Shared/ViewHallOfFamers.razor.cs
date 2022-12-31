namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewHallOfFamers : ViewSportTools<HallOfFameViewModel>
{
    [Parameter]
    public bool DisplayBallot { get; set; }

    [Parameter]
    public bool DisplayVotePercentage { get; set; }

    private HallOfFamesViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(Sport));
    }

    private async Task OnInputChange(int inductionYear)
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(Sport, inductionYear > 0 ? inductionYear : null));
    }
}
