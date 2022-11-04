#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewWorldSeries : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string TeamImageRootPath { get; set; }

    private ChampionsViewModel _viewModel = new();

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(TeamImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetChampions(ChampionType.WorldSeries.Id));
    }
}
