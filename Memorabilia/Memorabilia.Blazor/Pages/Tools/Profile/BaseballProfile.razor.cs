#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class BaseballProfile : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    public bool DisplayAccomplishments => _selectedAccomplishment?.Text == "Accomplishment";

    public bool DisplayAllStars => _selectedAccomplishment?.Text == "AllStar";

    public bool DisplayAwards => _selectedAccomplishment?.Text == "Award";

    public bool DisplayChampionships => _selectedAccomplishment?.Text == "Championship";

    public bool DisplayLeaders => _selectedAccomplishment?.Text == "Leader";

    private MudChip _selectedAccomplishment;
    private BaseballProfileViewModel _viewModel = new();

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetBaseballProfile.Query(PersonId));
    }
}
