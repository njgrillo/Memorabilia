namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class SiteMemorabiliaItemGalleryCard
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public SiteMemorabiliaGalleryItemModel MemorabiliaItem { get; set; }

    [Parameter]
    public string PrimaryImageFileName { get; set; }

    [Parameter]
    public string Subtitle { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public int UserId { get; set; }
}
