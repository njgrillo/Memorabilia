#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class BaseballProfile : ImagePage
{
    [Parameter]
    public int PersonId { get; set; }

    public bool DisplayAccomplishments => _selectedAccomplishment?.Text == "Accomplishment";

    public bool DisplayAllStars => _selectedAccomplishment?.Text == "AllStar";

    public bool DisplayAwards => _selectedAccomplishment?.Text == "Award";

    public bool DisplayChampionships => _selectedAccomplishment?.Text == "Championship";

    public bool DisplayLeaders => _selectedAccomplishment?.Text == "Leader";

    private MudChip _selectedAccomplishment;
    private BaseballProfileViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetBaseballProfile.Query(PersonId));
    }
}
