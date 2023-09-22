namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public string SearchText { get; set; }

    protected UserMessagesModel Model { get; set; }
        = new();

    private bool _isInitialLoad 
        = true;

    private bool _resetPaging;
    private string _searchText;

    private MudTable<UserMessageModel> _table
        = new();

    protected override async Task OnInitializedAsync()
    {
        if (!_isInitialLoad)
            return;

        await _table.ReloadServerData();

        _isInitialLoad = false;
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_searchText == SearchText)
            return;

        _resetPaging = true;
        _searchText = SearchText;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<UserMessageModel>> OnRead(TableState state)
    {
        var pageInfo = _isInitialLoad
            ? new PageInfo()
            : new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = _isInitialLoad
            ? await QueryRouter.Send(new GetUserMessages(pageInfo))
            : await QueryRouter.Send(new SearchUserMessages(pageInfo, SearchText));

        return new TableData<UserMessageModel>()
        {
            Items = Model.Messages,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected void ViewMessage(UserMessageModel userMessageModel)
    {
        //Expand child grid
    }
}
