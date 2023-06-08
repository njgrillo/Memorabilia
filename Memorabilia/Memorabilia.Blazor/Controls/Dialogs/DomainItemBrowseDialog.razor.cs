namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class DomainItemBrowseDialog
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public DomainItemConstant[] DomainItems { get; set; }

    [Parameter]
    public string Title { get; set; }

    private bool FilterFunc1(DomainItemConstant item)
        => FilterFunc(item, _search);

    private string _search;

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    private static bool FilterFunc(DomainItemConstant item, string search)
        => search.IsNullOrEmpty() ||
           item.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!item.Abbreviation.IsNullOrEmpty() && item.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));

    protected void Select(int id)
    {
        MudDialog.Close(DialogResult.Ok(id));
    }
}
