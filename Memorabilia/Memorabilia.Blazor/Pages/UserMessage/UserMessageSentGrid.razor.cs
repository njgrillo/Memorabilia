using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageSentGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

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
            ? await Mediator.Send(new GetUserMessagesSent(pageInfo))
            : await Mediator.Send(new SearchUserMessagesSent(pageInfo, SearchText));

        _isInitialLoad = false;

        return new TableData<UserMessageModel>()
        {
            Items = Model.Messages,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected void ViewMessage(UserMessageModel userMessageModel)
    {
        //TODO
        //Expand child grid
    }
}
