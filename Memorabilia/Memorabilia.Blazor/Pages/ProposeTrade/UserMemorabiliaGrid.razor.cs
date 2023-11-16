﻿namespace Memorabilia.Blazor.Pages.ProposeTrade;

public partial class UserMemorabiliaGrid
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public List<ProposeTradeMemorabiliaEditModel> Items { get; set; }
        = [];

    public List<ProposeTradeMemorabiliaEditModel> SelectedMemorabilia { get; set; }
        = [];

    protected string SelectAllButtonText
        => Items.Count == SelectedMemorabilia.Count
           ? "Deselect All"
           : "Select All";

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
            ? []
            : Items.ToList();
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        ProposeTradeMemorabiliaEditModel memorabiliaItem
            = Items.Single(item => item.MemorabiliaId == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
