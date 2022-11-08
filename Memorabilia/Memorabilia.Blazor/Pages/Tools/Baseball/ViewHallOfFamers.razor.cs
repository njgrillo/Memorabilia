#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewHallOfFamers : ImagePage
{
    protected bool FilterFunc1(HallOfFameViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private HallOfFamesViewModel _viewModel = new();

    protected bool FilterFunc(HallOfFameViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
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
