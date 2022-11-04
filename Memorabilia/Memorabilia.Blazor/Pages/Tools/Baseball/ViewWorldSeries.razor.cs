#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewWorldSeries : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string TeamImageRootPath { get; set; }

    protected bool FilterFunc1(ChampionViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private ChampionsViewModel _viewModel = new();

    protected bool FilterFunc(ChampionViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.TeamName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

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
