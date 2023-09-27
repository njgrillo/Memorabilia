namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class ViewUserMessages
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected string InboxSearchText { get; set; }

    protected string SentSearchText { get; set; }

    private string _inboxSearchText;
    private string _sentSearchText;

    protected void Compose()
    {
        NavigationManager.NavigateTo(NavigationPath.ComposeMessage);
    }

    protected void SearchInbox()
    {
        InboxSearchText = _inboxSearchText;
    }

    protected void SearchSent()
    {
        SentSearchText = _sentSearchText;
    }
}
