#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewDrafts : ImagePage
{
    protected bool FilterFunc1(DraftViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private DraftsViewModel _viewModel = new();

    protected bool FilterFunc(DraftViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetDrafts(franchiseId));
    }
}
