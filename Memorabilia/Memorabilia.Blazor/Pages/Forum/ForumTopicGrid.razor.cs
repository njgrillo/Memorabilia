using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumTopicGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public ForumCategory ForumCategory { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    protected ForumTopicsModel Model { get; set; }
        = new();

    private int _forumCategoryId;

    private bool _resetPaging;

    private int? _sportId;

    private MudTable<ForumTopicModel> _table
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (_forumCategoryId == ForumCategory?.Id && _sportId == Sport?.Id)
            return;

        _forumCategoryId = ForumCategory.Id;
        _sportId = Sport?.Id;
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<ForumTopicModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetForumTopics(pageInfo, _forumCategoryId, _sportId));

        return new TableData<ForumTopicModel>()
        {
            Items = Model.ForumTopics,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
