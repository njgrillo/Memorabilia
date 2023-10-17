namespace Memorabilia.Blazor.Pages.Forum;

public partial class EditForumEntry : ReroutePage
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public ForumEntryEditModel ForumEntry { get; set; }

    [Parameter]
    public EventCallback RankUpdated { get; set; }

    protected bool CanAttach { get; set; }

    protected bool CanEdit { get; set; }

    protected bool EditMode { get; set; }

    private bool _canInteract;
    private string _upvoteButtonText;

    protected override void OnParametersSet()
    {
        _canInteract
           = ApplicationStateService.CurrentUser != null &&
             ApplicationStateService.CurrentUser.HasPermission(Permission.EditForum);

        CanAttach = ApplicationStateService.CurrentUser != null &&
                    ForumEntry.CreatedByUserId == ApplicationStateService.CurrentUser.Id &&
                    ForumEntry.Images.Count < 3;       

        CanEdit = ApplicationStateService.CurrentUser != null &&
                  ForumEntry.CreatedByUserId == ApplicationStateService.CurrentUser.Id;

        if (!_canInteract)
            return;

        _upvoteButtonText
            = ForumEntry.RankedUsers.Any(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id)
                ? "Remove Upvote"
                : "Upvote";
    }

    protected async Task AddImages()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        var parameters = new DialogParameters
        {
            ["MaximumImagesAllowed"] = 3 - ForumEntry.Images.Count
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ForumEntryImageDialog>(string.Empty,
                                                               new DialogParameters(),
                                                               options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var files = (List<ImageEditModel>)result.Data;

        List<ForumEntryImageEditModel> images = new();

        foreach (ImageEditModel image in files)
        {
            string imageData = ImageService.GetUserImageData(image.FileName);

            byte[] bytes = Encoding.ASCII.GetBytes(imageData);

            ImageService.DeleteImage(Enum.ImageRootType.User, image.FileName);

            images.Add(new ForumEntryImageEditModel(ForumEntry.Id, bytes));
        }

        var command = new AddForumEntryImages(ForumEntry.Id, images.ToArray());

        await Mediator.Send(command);

        Entity.ForumEntry forumEntry = await Mediator.Send(new GetForumEntry(ForumEntry.Id));

        ForumEntry = new(forumEntry);

        CanAttach = ApplicationStateService.CurrentUser != null &&
                    ForumEntry.CreatedByUserId == ApplicationStateService.CurrentUser.Id &&
                    ForumEntry.Images.Count < 3;

        Snackbar.Add("Forum Entry Image(s) saved successfully!", Severity.Success);
    }

    protected async Task Confirm()
    {
        if (ForumEntry.Message.IsNullOrEmpty())
            return;

        var command = new SaveForumEntry(ForumEntry.Id, ForumEntry.Message);

        await Mediator.Send(command);

        Snackbar.Add("Forum Entry saved successfully!", Severity.Success);

        EditMode = false;
    }

    protected void Edit()
    {
        EditMode = true;
    }    

    protected void OnImageDeleted()
    {
        CanAttach = ForumEntry.Images.Count < 3;
    }

    protected async Task UpdateRank()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        bool isUpvote
            = !ForumEntry.RankedUsers.Any(rankedUser => rankedUser.UserId == ApplicationStateService.CurrentUser.Id);

        await Mediator.Send(new UpdateForumEntryRank(ForumEntry.Id, 
                                                          ApplicationStateService.CurrentUser.Id, 
                                                          isUpvote));

        if (isUpvote)
            ForumEntry.RankedUsers.Add(new ForumEntryUserRankEditModel(ForumEntry.Id, ApplicationStateService.CurrentUser.Id));
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
