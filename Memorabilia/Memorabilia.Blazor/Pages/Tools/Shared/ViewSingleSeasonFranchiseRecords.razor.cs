namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewSingleSeasonFranchiseRecords
    : ViewSportTools<SingleSeasonFranchiseRecordModel>
{
    protected SingleSeasonFranchiseRecordsModel Model
        = new();

    private async Task OnInputChange(Franchise franchise)
    {
        Model = new(await Mediator.Send(new GetSingleSeasonFranchiseRecords(franchise)), Sport)
        {
            Franchise = franchise
        };
    }
}
