#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewAwards : ImagePage
{
    protected bool FilterFunc1(AwardViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private AwardsViewModel _viewModel = new();

    protected bool FilterFunc(AwardViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(AwardType awardType)
    {
        _viewModel = await QueryRouter.Send(new GetAwards(awardType));
    }
}
