namespace Memorabilia.Blazor.Pages.Forum;

public partial class EditForumTopic : ReroutePage
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }    

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public ForumValidator Validator { get; set; }

    [Parameter]
    public string EncryptForumTopicId { get; set; }

    protected bool CanEditSubject { get; set; }

    protected ForumTopicEditModel EditModel { get; set; }
        = new();

    protected int ForumTopicId { get; set; }

    private string _bookmarkText;
    private bool _canInteract;

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        _canInteract
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.EditForum);

        ForumTopicId = DataProtectorService.DecryptId(EncryptForumTopicId);

        await Load();
    }

    protected async Task AddReply()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        var command = new SaveForumTopic.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Forum Entry saved successfully!", Severity.Success);

        await OnInitializedAsync();
    }

    protected async Task OnRankUpdated()
    {
        await Load();
    }

    protected async Task UpdateBookmark()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        bool shouldBookmark
            = !EditModel.Bookmarks.Any(bookmark => bookmark.UserId == ApplicationStateService.CurrentUser.Id);

        await CommandRouter.Send(new UpdateForumTopicBookmark(EditModel.Id,
                                                              ApplicationStateService.CurrentUser.Id));

        if (shouldBookmark)
            EditModel.Bookmarks.Add(new Entity.ForumTopicUserBookmark(EditModel.Id, ApplicationStateService.CurrentUser.Id));
        else
            EditModel.Bookmarks.RemoveAll(bookmark => bookmark.UserId == ApplicationStateService.CurrentUser.Id);

        Snackbar.Add("Bookmark saved successfully!", Severity.Success);

        _bookmarkText
            = EditModel.Bookmarks.Any(bookmark => bookmark.UserId == ApplicationStateService.CurrentUser.Id)
                ? "Remove Bookmark"
                : "Bookmark";
    }

    private async Task Load()
    {
        Entity.ForumTopic forumTopic
            = await QueryRouter.Send(new GetForumTopic(ForumTopicId));

        EditModel = new(forumTopic);

        if (!_canInteract)
            return;

        CanEditSubject
            = EditModel.CreatedByUser.Id == ApplicationStateService.CurrentUser.Id;

        EditModel.Entry = new(ApplicationStateService.CurrentUser.Id);

        _bookmarkText
            = EditModel.Bookmarks.Any(bookmark => bookmark.UserId == ApplicationStateService.CurrentUser.Id)
                ? "Remove Bookmark"
                : "Bookmark";
    }
}
