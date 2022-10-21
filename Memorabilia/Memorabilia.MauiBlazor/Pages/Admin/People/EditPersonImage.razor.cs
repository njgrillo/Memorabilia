namespace Memorabilia.MauiBlazor.Pages.Admin.People;

public partial class EditPersonImage : EditPersonItem
{
    public string _imageDirectorypath;

    protected override void OnInitialized()
    {
        _imageDirectorypath = string.Empty;
    }
}
