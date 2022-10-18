#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class ItemTypeSpotDropDown : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public int SelectedValue { get; set; }

    [Parameter]
    public int Value { get; set; }

    private IEnumerable<ItemTypeSpotViewModel> _itemTypeSpots = Enumerable.Empty<ItemTypeSpotViewModel>();

    [Parameter]
    public EventCallback<int> ValueChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _itemTypeSpots = (await QueryRouter.Send(new GetItemTypeSpots(ItemType.Id)))
                                    .ItemTypeSpots
                                    .OrderByDescending(spot => spot.SpotName);
    }

    private async Task OnInputChange(int value)
    {
        await ValueChanged.InvokeAsync(value);
    }
}
