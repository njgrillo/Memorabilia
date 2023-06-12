namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaItemGallerySubCard
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

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

    [Parameter]
    public int UserId { get; set; }

    protected void OnEditClick()
    {
        NavigationManager.NavigateTo(EditNavigationPath);
    }

    protected void OnImageClick()
    {
        NavigationManager.NavigateTo(ImageNavigationPath);
    }
}
