namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.Accomplishments.FranchiseRecords;

public partial class ViewFranchiseRecords
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected FranchiseRecordsViewModel Model
        = new();

    private string _search;

    private MudTable<FranchiseRecordViewModel> _table;

    protected async Task<TableData<FranchiseRecordViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetFranchiseRecordsPaged(pageInfo, _search));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "franchisename_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.FranchiseName).ToList();
                break;
            case "sportleaguelevelabbreviation_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.SportLeagueLevelAbbreviation).ToList();
                break;
            case "careerrecordcount_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.CareerRecordCount).ToList();
                break;
            case "singleseasonrecordcount_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.SingleSeasonRecordCount).ToList();
                break;
        }

        return new TableData<FranchiseRecordViewModel>()
        {
            Items = Model.Franchises,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void Filter(string search)
    {
        _search = search;

        _table.ReloadServerData();
    }
}
