namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewSingleSeasonRecords : ViewSportTools<SingleSeasonRecordModel>
{
    private SingleSeasonRecordsModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetSingleSeasonRecords(Sport));
    }
}
