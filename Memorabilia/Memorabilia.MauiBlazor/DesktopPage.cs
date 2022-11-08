namespace Memorabilia.MauiBlazor;

public abstract class DesktopPage : ComponentBase
{
    [Inject]
    public IConfiguration Configuration { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public int UserId { get; set; }

    protected string DomainImageRootPath => Configuration["DomainImageRootPath"];

    protected string MemorabiliaImageRootPath => Configuration["MemorabiliaImageRootPath"];

    protected string PersonImageRootPath => Configuration["PersonImageRootPath"];

    protected string PewterImageRootPath => Configuration["PewterImageRootPath"];

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
