namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class BasketballProfile : ImagePage
{
    [Parameter]
    public int PersonId { get; set; }

    public bool DisplayAccomplishments => _selectedAccomplishment?.Text == "Accomplishment";

    public bool DisplayAllStars => _selectedAccomplishment?.Text == "AllStar";

    public bool DisplayAwards => _selectedAccomplishment?.Text == "Award";

    public bool DisplayChampionships => _selectedAccomplishment?.Text == "Championship";

    public bool DisplayLeaders => _selectedAccomplishment?.Text == "Leader";

    private MudChip _selectedAccomplishment;
    private BasketballProfileViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetBasketballProfile.Query(PersonId));
    }
}
