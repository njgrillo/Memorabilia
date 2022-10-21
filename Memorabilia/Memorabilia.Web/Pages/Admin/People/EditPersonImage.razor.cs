namespace Memorabilia.Web.Pages.Admin.People;

public partial class EditPersonImage : EditPersonItem
{
    [Inject]
    public IWebHostEnvironment Environment { get; set; }

    public string _imageDirectoryPath;

    protected override void OnInitialized()
    {
        _imageDirectoryPath = Environment.ContentRootPath;
    }
}
