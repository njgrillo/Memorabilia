#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewHallOfFamers : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private HallOfFamesViewModel _viewModel = new();

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(_viewModel.SportLeagueLevelId));
    }

    private async Task OnInputChange(int inductionYear)
    {
        _viewModel = await QueryRouter.Send(new GetHallOfFames(_viewModel.SportLeagueLevelId, inductionYear > 0 ? inductionYear : null));
    }
}
