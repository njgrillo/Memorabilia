﻿namespace Memorabilia.Web.Controls;

public partial class PageLoader : WebPage
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    protected bool PageLoaded;

    protected override async Task OnInitializedAsync()
    {
        if (UserId > 0)
            return;

        var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

        if (userId.Value == 0)
            NavigationManager.NavigateTo("Login");

        UserId = userId.Value;

        await OnLoad.InvokeAsync();

        PageLoaded = true;
    }
}
