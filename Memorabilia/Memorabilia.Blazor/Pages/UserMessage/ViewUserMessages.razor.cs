namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class ViewUserMessages
{
    protected string SearchText { get; set; }

    private string _searchText;

    protected void Compose()
    {

    }

    protected void Search()
    {
        SearchText = _searchText;
    }
}
