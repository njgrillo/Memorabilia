namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class MonthDropDown : ComponentBase
{
    [Parameter]
    public bool Disabled { get; set; }
        = false;

    [Parameter]
    public bool DisplaySelect { get; set; }
        = true;

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int? SelectedValue { get; set; }

    [Parameter]
    public string SelectItemText { get; set; }
        = "--Select--";

    [Parameter]
    public int? SelectItemValue { get; set; }

    [Parameter]
    public Variant Variant { get; set; }
        = Variant.Outlined;

    public IEnumerable<int?> Items { get; set; }
        = Enumerable.Empty<int?>();

    [Parameter]
    public EventCallback<int?> SelectionChanged { get; set; }

    protected override void OnInitialized()
    {
        var items = new List<int?>
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9, 
            10,
            11,
            12
        };

        Items = items.AsEnumerable();

        Label = "Month";
    }

    protected virtual string GetItemDisplayText(int? item)
        => item.ToMonth();

    protected virtual int? GetItemDisplayValue(int? item)
        => item;
}
