#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewInternationalHallOfFames : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private InternationalHallOfFamesViewModel _viewModel = new();

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    private async Task OnInputChange(int internationalHallOfFameTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetInternationalHallOfFames(internationalHallOfFameTypeId, _viewModel.SportLeagueLevelId));
    }
}
