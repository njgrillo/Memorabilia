namespace Memorabilia.Blazor.Pages.Forum;

public partial class ForumCategoryBrowseDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string Title { get; set; }

    private bool FilterFunc1(ForumCategory item)
        => FilterFunc(item, _search);

    private string _search;

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    private static bool FilterFunc(ForumCategory item, string search)
        => search.IsNullOrEmpty() ||
           item.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!item.Abbreviation.IsNullOrEmpty() && item.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));

    protected void Select(int id)
    {
        MudDialog.Close(DialogResult.Ok(id));
    }
}
