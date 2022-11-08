namespace Memorabilia.Web;

public abstract class WebPage : ComponentBase
{
    [Inject]
    public IConfiguration Configuration { get; set; }   

    [Inject]
    public ProtectedLocalStorage LocalStorage { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public int UserId { get; set; }

    protected string DomainImageRootPath => Configuration["DomainImageRootPath"];

    protected string MemorabiliaImageRootPath => Configuration["MemorabiliaImageRootPath"];

    protected string PersonImageRootPath => Configuration["PersonImageRootPath"];

    protected string PewterImageRootPath => Configuration["PewterImageRootPath"];

    protected async Task DeleteUserId()
    {
        await LocalStorage.DeleteAsync("UserId");
    }

    protected async Task<int> GetUserId()
    {
        var userId = await LocalStorage.GetAsync<int>("UserId");

        return userId.Value;
    }

    protected override async Task OnInitializedAsync()
    {
        if (UserId == 0)
        {
            UserId = await GetUserId();

            if (UserId == 0)
                NavigationManager.NavigateTo("Login");

            await LocalStorage.SetAsync("UserId", UserId);
        }
    }    
}
