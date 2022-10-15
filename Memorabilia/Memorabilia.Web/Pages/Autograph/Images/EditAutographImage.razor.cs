namespace Memorabilia.Web.Pages.Autograph.Images;

public partial class EditAutographImage : AutographItem
{
    [Inject]
    public IWebHostEnvironment Environment { get; set; }

    protected string UploadPath { get; set; }

    protected override void OnInitialized()
    {
        UploadPath = Environment.ContentRootPath;
    }
}
