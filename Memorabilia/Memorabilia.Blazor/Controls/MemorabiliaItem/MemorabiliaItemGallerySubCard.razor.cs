#nullable disable

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaItemGallerySubCard : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public string ImageNavigationPath { get; set; }

    [Parameter]
    public string ImagePath { get; set; }

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
