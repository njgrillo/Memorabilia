namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCareerRecords 
    : ViewSportTools<CareerRecordModel>
{
    protected CareerRecordsModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = new(await Mediator.Send(new GetCareerRecords(Sport)), Sport);
    }
}