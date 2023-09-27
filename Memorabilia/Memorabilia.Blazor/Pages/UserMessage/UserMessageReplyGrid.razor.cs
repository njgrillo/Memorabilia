namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageReplyGrid
{
    [Parameter]
    public UserMessageModel UserMessage { get; set; }

    private void ToggleChildContent(int userMessageReplyId)
    {
        UserMessageReplyModel reply = UserMessage.Replies.Single(item => item.Id == userMessageReplyId);

        reply.DisplayDetails = !reply.DisplayDetails;
        reply.ToggleIcon = reply.DisplayDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
