namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumEntryImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int ForumEntryId { get; set; }

    [Parameter]
    public int ForumEntryImageId { get; set; }

    protected ForumEntryImageModel[] Images { get; set; }
        = Array.Empty<ForumEntryImageModel>();

    protected override async Task OnInitializedAsync()
    {
        if (ForumEntryId == 0)
            return;

        Entity.ForumEntry forumEntry 
            = await Mediator.Send(new GetForumEntry(ForumEntryId));

        Images = forumEntry.Images
                           .Select(image => new ForumEntryImageModel(image))
                           .ToArray();
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
