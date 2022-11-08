#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewWorldSeries : CommandQuery
{
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

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetChampions(ChampionType.WorldSeries.Id));
    }
}
