namespace Memorabilia.Blazor.Pages.Forum;

public partial class EditForumEntry
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public ForumEntryEditModel ForumEntry { get; set; }

    [Parameter]
    public EventCallback RankUpdated { get; set; }

    protected bool CanEdit { get; set; }

    protected bool EditMode { get; set; }

    private string _upvoteButtonText;

    protected override void OnParametersSet()
    {
        CanEdit = ForumEntry.CreatedByUserId == ApplicationStateService.CurrentUser.Id;

        _upvoteButtonText
            = ForumEntry.RankedUsers.Any(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id)
                ? "Remove Upvote"
                : "Upvote";
    }

    protected async Task Confirm()
    {
        if (ForumEntry.Message.IsNullOrEmpty())
            return;

        var command = new SaveForumEntry(ForumEntry.Id, ForumEntry.Message);

        await CommandRouter.Send(command);

        Snackbar.Add("Forum Entry saved successfully!", Severity.Success);

        EditMode = false;
    }

    protected void Edit()
    {
        EditMode = true;
    }

    protected void EditImages()
    {

    }    

    protected async Task UpdateRank()
    {
        bool isUpvote
            = !ForumEntry.RankedUsers.Any(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id);

        await CommandRouter.Send(new UpdateForumEntryRank(ForumEntry.Id, 
                                                          ApplicationStateService.CurrentUser.Id, 
                                                          isUpvote));

        if (isUpvote)
            ForumEntry.RankedUsers.Add(new Entity.ForumEntryUserRank(ForumEntry.Id, ApplicationStateService.CurrentUser.Id));
        else
            ForumEntry.RankedUsers.RemoveAll(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id);

        _upvoteButtonText 
            = ForumEntry.RankedUsers.Any(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id)
                ? "Remove Upvote"
                : "Upvote";

        Snackbar.Add("Rank saved successfully!", Severity.Success);

        await RankUpdated.InvokeAsync();
    }
}
