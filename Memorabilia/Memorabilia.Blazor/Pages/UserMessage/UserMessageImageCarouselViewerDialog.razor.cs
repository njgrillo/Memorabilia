namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int UserMessageReplyId { get; set; }

    protected UserMessageReplyImageModel[] Images { get; set; }
       = Array.Empty<UserMessageReplyImageModel>();

    protected int UserId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Entity.UserMessageReply userMessageReply
            = await Mediator.Send(new GetUserMessageReply(UserMessageReplyId));

        Images = userMessageReply.Images
                                 .Select(image => new UserMessageReplyImageModel(image))
                                 .ToArray();

        //TODO: Set UserId
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
