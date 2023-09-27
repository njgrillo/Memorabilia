namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageImage
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public UserMessageReplyImageEditModel Image { get; set; }

    [Parameter]
    public EventCallback<string> ImageRemoved { get; set; }

    protected string ImageClass 
        => Image.UserMessageReplyId > 0
        ? "rounded-lg can-click"
        : "rounded-lg cant-click";

    protected async Task OnImageClick()
    {
        if (Image.UserMessageReplyId == 0)
            return;

        var parameters = new DialogParameters
        {
            ["UserMessageReplyId"] = Image.UserMessageReplyId,
            ["UserId"] = ApplicationStateService.CurrentUser.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<UserMessageImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    private async Task RemoveImage()
    {
        await ImageRemoved.InvokeAsync(Image.ImageFileName);
    }
}
