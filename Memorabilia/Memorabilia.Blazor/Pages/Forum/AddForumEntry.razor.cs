namespace Memorabilia.Blazor.Pages.Forum;

public partial class AddForumEntry
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public ForumEntryEditModel ForumEntry { get; set; }

    protected void AddImages()
    {

    }
}
