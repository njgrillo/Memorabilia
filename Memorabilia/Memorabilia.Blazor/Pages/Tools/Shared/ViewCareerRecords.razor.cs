namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCareerRecords : ViewSportTools<CareerRecordViewModel>
{
    private CareerRecordsViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetCareerRecords(Sport));
    }
}