namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class FootballProfile : ImagePage
{
    [Parameter]
    public int PersonId { get; set; }

    public bool DisplayAccomplishments => _selectedAccomplishment?.Text == "Accomplishment";    

    public bool DisplayAwards => _selectedAccomplishment?.Text == "Award";

    public bool DisplayChampionships => _selectedAccomplishment?.Text == "Championship";

    public bool DisplayLeaders => _selectedAccomplishment?.Text == "Leader";

    public bool DisplayProBowls => _selectedAccomplishment?.Text == "ProBowls";

    private MudChip _selectedAccomplishment;
    private FootballProfileViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetFootballProfile.Query(PersonId));
    }
}
