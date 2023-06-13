namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaItemGalleryCard
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Description { get; set; }  

    [Parameter]
    public string EditNavigationPath { get; set; }

    [Parameter]
    public MemorabiliaGalleryItemModel MemorabiliaItem { get; set; }

    [Parameter]
    public string PrimaryImageFileName { get; set; }

    [Parameter]
    public string PrimaryImageNavigationPath { get; set; }    

    [Parameter]
    public string Subtitle { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected void OnPrimaryImageClick()
    {
        NavigationManager.NavigateTo(PrimaryImageNavigationPath);
    }
}
