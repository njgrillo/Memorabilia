namespace Memorabilia.MauiBlazor;

public abstract class DesktopPage : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public int UserId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (UserId == 0)
        {
            UserId = await GetUserId();

            if (UserId == 0)
                NavigationManager.NavigateTo("Login");

            await SecureStorage.Default.SetAsync("UserId", UserId.ToString());
        }
    }

    private async Task<int> GetUserId()
    {
        var userId = await SecureStorage.Default.GetAsync("UserId");

        return userId.ToInt32();
    }
}
