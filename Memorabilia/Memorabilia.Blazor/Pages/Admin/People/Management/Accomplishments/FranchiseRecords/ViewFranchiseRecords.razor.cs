namespace Memorabilia.Blazor.Pages.Admin.People.Management.Accomplishments.FranchiseRecords;

public partial class ViewFranchiseRecords
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected FranchiseRecordsViewModel Model
        = new();

    private string _search;

    protected async Task<TableData<FranchiseRecordViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetFranchiseRecordsPaged(pageInfo));

        StateHasChanged();

        return new TableData<FranchiseRecordViewModel>()
        {
            Items = Model.Franchises,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private bool Filter(FranchiseRecordViewModel franchiseRecord)
        => franchiseRecord.Search(_search);
}
