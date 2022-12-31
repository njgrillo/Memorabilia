namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewSingleSeasonRecords : ViewSportTools<SingleSeasonRecordViewModel>
{
    private SingleSeasonRecordsViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetSingleSeasonRecords(Sport));
    }
}
