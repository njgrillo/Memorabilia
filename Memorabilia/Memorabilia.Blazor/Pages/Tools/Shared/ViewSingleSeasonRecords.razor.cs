namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewSingleSeasonRecords 
    : ViewSportTools<SingleSeasonRecordModel>
{
    private SingleSeasonRecordsModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = new(await QueryRouter.Send(new GetSingleSeasonRecords(Sport)), Sport);
    }
}
