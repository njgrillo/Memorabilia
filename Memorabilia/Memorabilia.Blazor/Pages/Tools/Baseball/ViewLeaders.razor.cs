#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewLeaders : ImagePage
{
    protected bool FilterFunc1(LeaderViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private LeadersViewModel _viewModel = new();

    protected bool FilterFunc(LeaderViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(LeaderType leaderType)
    {
        _viewModel = await QueryRouter.Send(new GetLeaders(leaderType));
    }
}
