namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class UserMemorabiliaGrid
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public List<ProposeTradeMemorabiliaEditModel> Items { get; set; }
        = new();

    public List<ProposeTradeMemorabiliaEditModel> SelectedMemorabilia { get; set; }
        = new();

    protected string SelectAllButtonText
        => Items.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

    private MudTable<ProposeTradeMemorabiliaEditModel> _table
        = new();

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected void OnMemorabiliaSelected(ProposeTradeMemorabiliaEditModel item)
    {
        if (!SelectedMemorabilia.Contains(item))
        {
            SelectedMemorabilia.Add(item);

            return;
        }

        SelectedMemorabilia.Remove(item);
    }

    protected void OnRemoveSelected()
    {
        SelectedMemorabilia.RemoveAll(item => item.IsDeleted);
    }

    protected void OnSelectAll()
    {
        SelectedMemorabilia = Items.Count == SelectedMemorabilia.Count
            ? new()
            : Items.ToList();
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        ProposeTradeMemorabiliaEditModel memorabiliaItem
            = Items.Single(item => item.MemorabiliaId == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;

        memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
