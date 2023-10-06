namespace Memorabilia.Blazor.Pages.Forum;

public partial class AddForumEntry : ReroutePage
{
    [Parameter]
    public ForumEntryEditModel ForumEntry { get; set; }

    private bool _canInteract;

    protected override void OnInitialized()
    {
        _canInteract
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.EditForum);
    }

    protected async Task AddImages()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        //TODO: Finish implementation
    }
}
