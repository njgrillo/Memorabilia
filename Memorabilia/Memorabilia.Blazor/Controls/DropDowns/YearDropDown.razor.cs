#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class YearDropDown : ComponentBase
{
    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool DisplaySelect { get; set; } = true;

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int MaxYear { get; set; }

    [Parameter]
    public int MinYear { get; set; }

    [Parameter]
    public int SelectedValue { get; set; }

    [Parameter]
    public string SelectItemText { get; set; } = "--Select--";

    [Parameter]
    public int SelectItemValue { get; set; }

    [Parameter]
    public Variant Variant { get; set; } = Variant.Outlined;

    public IEnumerable<int> Items { get; set; } = Enumerable.Empty<int>();

    [Parameter]
    public EventCallback<int> SelectionChanged { get; set; }

    protected override void OnInitialized()
    {
        var start = Math.Max(MinYear, 1900);
        var end = DateTime.Now.Year - start + 1;

        Items = Enumerable.Range(start, end).OrderByDescending(year => year);
        Label = "Year";
    }

    protected virtual string GetItemDisplayText(int item)
    {
        return item.ToString();
    }

    protected virtual int GetItemDisplayValue(int item)
    {
        return item;
    }
}
