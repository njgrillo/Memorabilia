#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewInternationalHallOfFames : ImagePage
{
    protected bool FilterFunc1(InternationalHallOfFameViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private InternationalHallOfFamesViewModel _viewModel = new();

    protected bool FilterFunc(InternationalHallOfFameViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(int internationalHallOfFameTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetInternationalHallOfFames(internationalHallOfFameTypeId, _viewModel.SportLeagueLevelId));
    }
}
