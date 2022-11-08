#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewCareerRecords : ImagePage
{
    protected bool FilterFunc1(CareerRecordViewModel viewModel) => FilterFunc(viewModel, Search);
    protected string Search;

    private CareerRecordsViewModel _viewModel = new();

    protected bool FilterFunc(CareerRecordViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.PersonName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.PersonName,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }
    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetCareerRecords(Sport.Baseball.Id));
    }
}