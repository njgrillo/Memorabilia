#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewBaseballColleges : ImagePage
{
    protected bool FilterFunc1(PersonCollegeViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private PersonCollegesViewModel _viewModel = new();

    protected bool FilterFunc(PersonCollegeViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task OnInputChange(College college)
    {
        _viewModel = await QueryRouter.Send(new GetPersonColleges(college, _viewModel.SportLeagueLevelId));
    }
}
