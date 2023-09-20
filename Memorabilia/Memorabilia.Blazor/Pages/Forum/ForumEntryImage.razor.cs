﻿namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumEntryImage
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public ForumEntryImageEditModel Image { get; set; }

    [Parameter]
    public EventCallback<int> ImageDeleted { get; set; }

    protected async Task OnImageClick()
    {
        var parameters = new DialogParameters
        {
            ["ForumEntryId"] = Image.ForumEntryId,
            ["ForumEntryImageId"] = Image.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ForumEntryImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected async Task ShowDeleteConfirm()
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Image");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete();
    }

    private async Task Delete()
    {
        await CommandRouter.Send(new DeleteForumEntryImage(Image.Id));

        await ImageDeleted.InvokeAsync(Image.Id);

        Snackbar.Add("Image was deleted successfully!", Severity.Success);
    }
}
