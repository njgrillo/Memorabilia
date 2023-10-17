namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumEntryImages
{
    [Parameter]
    public bool CanDelete { get; set; }

    [Parameter]
    public EventCallback ImageDeleted { get; set; }

    [Parameter]
    public List<ForumEntryImageEditModel> Images { get; set; }
        = new();

    public async Task OnImageDeleted(int forumEntryImageId)
    {
        Images.RemoveAll(image => image.Id == forumEntryImageId);

        await ImageDeleted.InvokeAsync();
    }
}
