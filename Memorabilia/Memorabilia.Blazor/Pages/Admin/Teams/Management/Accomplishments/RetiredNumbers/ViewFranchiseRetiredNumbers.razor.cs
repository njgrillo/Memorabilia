namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.Accomplishments.RetiredNumbers;

public partial class ViewFranchiseRetiredNumbers
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected FranchiseRetiredNumbersViewModel Model
        = new();

    private string _search;

    private MudTable<FranchiseRetiredNumberViewModel> _table;

    protected async Task<TableData<FranchiseRetiredNumberViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetFranchiseRetiredNumbersPaged(pageInfo, _search));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "franchisename_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.FranchiseName).ToList();
                break;
            case "sportleaguelevelabbreviation_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.SportLeagueLevelAbbreviation).ToList();
                break;
            case "retirednumbercount_field":
                Model.Franchises = Model.Franchises.OrderByDirection(state.SortDirection, o => o.RetiredNumberCount).ToList();
                break;
        }

        return new TableData<FranchiseRetiredNumberViewModel>()
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
