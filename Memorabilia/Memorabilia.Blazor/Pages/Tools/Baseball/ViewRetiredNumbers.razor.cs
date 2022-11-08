#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewRetiredNumbers : ImagePage
{
    protected bool FilterFunc1(RetiredNumberViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private RetiredNumbersViewModel _viewModel = new();

    protected bool FilterFunc(RetiredNumberViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetRetiredNumbers(franchiseId));
    }
}
