using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageReplyControl
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public bool ShowReply { get; set; }

    [Parameter]
    public UserMessageReplyModel UserMessageReply { get; set; }
        = new();

    protected void Reply(UserMessageReplyModel userMessageReply)
    {
        NavigationManager.NavigateTo($"{NavigationPath.ReplyMessage}/{DataProtectorService.EncryptId(userMessageReply.Id)}");
    }
}
