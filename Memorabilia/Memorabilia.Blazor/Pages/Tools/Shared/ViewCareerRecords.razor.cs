namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCareerRecords 
    : ViewSportTools<CareerRecordModel>
{
    protected CareerRecordsModel Model = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetCareerRecords(Sport));
    }
}