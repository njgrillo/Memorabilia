﻿using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Forum;

public partial class TrendingForumTopics
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected TrendingForumTopicsModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.ForumTopic[] trendingTopics
            = await Mediator.Send(new GetTrendingForumTopics());

        if (trendingTopics.IsNullOrEmpty())
            return;

        Model = new(trendingTopics);
    }
}
