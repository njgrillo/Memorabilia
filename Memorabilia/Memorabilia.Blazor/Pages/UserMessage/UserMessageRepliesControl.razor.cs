namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageRepliesControl
{
    [Parameter]
    public UserMessageModel UserMessage { get; set; }

    private int _index;
}
