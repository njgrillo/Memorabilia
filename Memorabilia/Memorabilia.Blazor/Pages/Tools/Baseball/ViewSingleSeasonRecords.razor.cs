#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewSingleSeasonRecords : ImagePage
{
    protected bool FilterFunc1(SingleSeasonRecordViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private SingleSeasonRecordsViewModel _viewModel = new();

    protected bool FilterFunc(SingleSeasonRecordViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetSingleSeasonRecords(Sport.Baseball.Id));
    }
}
