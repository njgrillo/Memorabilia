namespace Memorabilia.Blazor.Pages.Forum;

public partial class AddForumEntry : ReroutePage
{
    [Parameter]
    public ForumEntryEditModel ForumEntry { get; set; }

    protected bool CanAttach { get; set; }
        = true;

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
                                                               [],
                                                               options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var files = (List<ImageEditModel>)result.Data;

        List<ForumEntryImageEditModel> images = [];

        foreach (ImageEditModel image in files)
        {
            images.Add(new ForumEntryImageEditModel(ForumEntry.Id, image.FileName));
        }

        ForumEntry.Images = images;

        CanAttach = ApplicationStateService.CurrentUser != null &&
                    ForumEntry.CreatedByUserId == ApplicationStateService.CurrentUser.Id &&
                    ForumEntry.Images.Count < 3;
    }

    protected void OnImageDeleted()
    {
        CanAttach = ForumEntry.Images.Count < 3;
    }
}
