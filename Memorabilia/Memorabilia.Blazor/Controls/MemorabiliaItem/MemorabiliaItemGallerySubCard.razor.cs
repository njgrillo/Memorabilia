

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaItemGallerySubCard : ImagePage
{
    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public string ImageNavigationPath { get; set; }    

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected void OnImageClick()
    {
        NavigationManager.NavigateTo(ImageNavigationPath);
    }
}
