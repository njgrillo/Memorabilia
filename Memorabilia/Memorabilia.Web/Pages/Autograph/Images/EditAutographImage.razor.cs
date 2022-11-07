namespace Memorabilia.Web.Pages.Autograph.Images;

public partial class EditAutographImage : AutographItem
{
    [Inject]
    public IConfiguration Configuration { get; set; }

    protected string UploadPath { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var userId = await LocalStorage.GetAsync<int>("UserId");

        UploadPath = Path.Combine(Configuration["MemorabiliaImageRootPath"], userId.Value.ToString());
    }
}
