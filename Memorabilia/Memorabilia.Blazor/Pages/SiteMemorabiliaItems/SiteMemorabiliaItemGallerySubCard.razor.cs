namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaItemGallerySubCard
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }
}
