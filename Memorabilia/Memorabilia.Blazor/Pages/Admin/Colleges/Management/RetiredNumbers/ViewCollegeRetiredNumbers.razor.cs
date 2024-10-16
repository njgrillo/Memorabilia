namespace Memorabilia.Blazor.Pages.Admin.Colleges.Management.RetiredNumbers;

public partial class ViewCollegeRetiredNumbers
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected CollegeRetiredNumbersViewModel Model
        = new();

    private string _search;

    private MudTable<CollegeRetiredNumberViewModel> _table;

    protected async Task<TableData<CollegeRetiredNumberViewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetCollegeRetiredNumbersPaged(pageInfo, _search));

        StateHasChanged();

        switch (state.SortLabel)
        {
            case "collegename_field":
                Model.Colleges = Model.Colleges.OrderByDirection(state.SortDirection, o => o.CollegeName).ToList();
                break;
            case "collegeabbreviation_field":
                Model.Colleges = Model.Colleges.OrderByDirection(state.SortDirection, o => o.CollegeAbbreviation).ToList();
                break;
            case "retirednumbercount_field":
                Model.Colleges = Model.Colleges.OrderByDirection(state.SortDirection, o => o.RetiredNumberCount).ToList();
                break;
        }

        return new TableData<CollegeRetiredNumberViewModel>()
        {
            Items = Model.Colleges,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void Filter(string search)
    {
        _search = search;

        _table.ReloadServerData();
    }
}
