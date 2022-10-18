#nullable disable

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaItemGalleryCard : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public MemorabiliaGalleryItemViewModel MemorabiliaItem { get; set; }

    [Parameter]
    public string PrimaryImageNavigationPath { get; set; }

    [Parameter]
    public string PrimaryImagePath { get; set; }

    [Parameter]
    public string Subtitle { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected void OnPrimaryImageClick()
    {
        NavigationManager.NavigateTo(PrimaryImageNavigationPath);
    }
}
