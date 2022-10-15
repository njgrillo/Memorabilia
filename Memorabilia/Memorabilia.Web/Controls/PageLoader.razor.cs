namespace Memorabilia.Web.Controls;

public partial class PageLoader : WebPage
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    private bool PageLoaded;

    protected override async Task OnInitializedAsync()
    {
        var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

        if (userId.Value == 0)
            NavigationManager.NavigateTo("Login");

        await OnLoad.InvokeAsync();

        PageLoaded = true;
    }
}
