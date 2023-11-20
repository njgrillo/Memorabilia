namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumTopicSearchResultsGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string SearchText { get; set; }

    protected ForumTopicsModel Model { get; set; }
        = new();

    private bool _resetPaging;
    private string _searchText;

    private MudTable<ForumTopicModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (_searchText == SearchText)
            return;
        
        _resetPaging = true;
        _searchText = SearchText;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<ForumTopicModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new SearchForumTopics(pageInfo, SearchText));

        return new TableData<ForumTopicModel>()
        {
            Items = Model.ForumTopics,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
