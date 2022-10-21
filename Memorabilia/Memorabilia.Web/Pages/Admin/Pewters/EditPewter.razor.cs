namespace Memorabilia.Web.Pages.Admin.Pewters;

public partial class EditPewter : EditItem
{
    [Inject]
    public IWebHostEnvironment Environment { get; set; }

    private string _imageDirectoryPath { get; set; }

    protected override void OnInitialized()
    {
        _imageDirectoryPath = Environment.ContentRootPath;
    }
}
