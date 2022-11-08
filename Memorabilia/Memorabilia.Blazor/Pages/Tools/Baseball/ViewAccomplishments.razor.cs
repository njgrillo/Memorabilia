#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewAccomplishments : ImagePage
{
    protected bool FilterFunc1(AccomplishmentViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private AccomplishmentsViewModel _viewModel = new();

    protected bool FilterFunc(AccomplishmentViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }    

    private async Task OnInputChange(int accomplishmentTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetAccomplishments(accomplishmentTypeId));
    }
}
