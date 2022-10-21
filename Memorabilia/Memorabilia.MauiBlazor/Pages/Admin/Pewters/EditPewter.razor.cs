namespace Memorabilia.MauiBlazor.Pages.Admin.Pewters;

public partial class EditPewter : EditItem
{
    private string _imageDirectoryPath { get; set; }

    protected override void OnInitialized()
    {
        _imageDirectoryPath = string.Empty;
    }
}
