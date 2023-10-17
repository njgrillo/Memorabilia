namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class DropDown<TItem, TType> 
    : CommandQuery where TItem : class, IWithName, IWithValue<TType> 
{

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool Disabled { get; set; } 
        = false;

    [Parameter]
    public bool DisplaySelect { get; set; } 
        = true;

    [Parameter]
    public bool DisplaySkeleton { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public bool MultiSelect { get; set; }

    [Parameter]
    public bool SelectAll { get; set; } 
        = true;

    [Parameter]
    public IEnumerable<TType> SelectedItems { get; set; } 
        = Enumerable.Empty<TType>();

    [Parameter]
    public EventCallback<IEnumerable<TType>> SelectedItemsChanged { get; set; }

    [Parameter]
    public TType SelectedValue { get; set; }

    [Parameter]
    public EventCallback<TType> SelectionChanged { get; set; }

    [Parameter]
    public string SelectItemText { get; set; }
        = "--Select--";

    [Parameter]
    public TType SelectItemValue { get; set; }

    [Parameter]
    public TType Value { get; set; }    

    [Parameter]
    public Variant Variant { get; set; } 
        = Variant.Outlined;

    public IEnumerable<TItem> Items { get; set; } 
        = Enumerable.Empty<TItem>();

    protected virtual string GetItemDisplayText(TItem item)
        => item.Name;

    protected virtual TType GetItemDisplayValue(TItem item)
        => item.Value;

    protected virtual string GetMultiSelectionText(List<string> selectedValues)
        => $"{selectedValues.Count} items have been selected";
}
