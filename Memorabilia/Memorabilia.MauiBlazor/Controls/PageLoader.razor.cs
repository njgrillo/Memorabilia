namespace Memorabilia.MauiBlazor.Controls;

public partial class PageLoader : DesktopPage
{
    [Parameter]
    public RenderFragment Content { get; set; }

    private bool PageLoaded;

    protected override async Task OnInitializedAsync()
    {
        var userId = await SecureStorage.Default.GetAsync("UserId");

        if (userId.ToInt32() == 0)
            NavigationManager.NavigateTo("Login");

        PageLoaded = true;
    }
}
