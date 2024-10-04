namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCareerFranchiseRecords
    : ViewSportTools<CareerFranchiseRecordModel>
{
    protected CareerFranchiseRecordsModel Model
        = new();

    private async Task OnInputChange(Franchise franchise)
    {
        Model = new(await Mediator.Send(new GetCareerFranchiseRecords(franchise)), Sport)
        {
            Franchise = franchise
        };
    }
}
