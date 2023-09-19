namespace Memorabilia.Blazor.Pages.Forum;

public partial class TrendingForumTopics
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected TrendingForumTopicsModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.ForumTopic[] trendingTopics
            = await QueryRouter.Send(new GetTrendingForumTopics());

        if (!trendingTopics.Any())
            return;

        Model = new(trendingTopics);
    }
}
