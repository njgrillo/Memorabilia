#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class ItemTypeGameStyleDropDown : ComponentBase
{
    [Inject]
    public QueryRouter QueryRounter { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public string Label { get; set; } = "Game Style";

    [Parameter]
    public int SelectedValue { get; set; }

    [Parameter]
    public int Value { get; set; }

    [Parameter]
    public EventCallback<int> ValueChanged { get; set; }

    private IEnumerable<ItemTypeGameStyleViewModel> _itemTypeGameStyles = Enumerable.Empty<ItemTypeGameStyleViewModel>();

    protected override async Task OnInitializedAsync()
    {
        _itemTypeGameStyles = (await QueryRounter.Send(new GetItemTypeGameStyles.Query(ItemType.Id)).ConfigureAwait(false))
                                            .ItemTypeGameStyles;
    }

    private async Task OnInputChange(int value)
    {
        await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
    }
}
