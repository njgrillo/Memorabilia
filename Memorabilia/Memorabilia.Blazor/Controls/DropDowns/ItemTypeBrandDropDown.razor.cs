#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class ItemTypeBrandDropDown : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public int Value { get; set; }

    [Parameter]
    public int SelectedValue { get; set; }

    [Parameter]
    public EventCallback<int> ValueChanged { get; set; }

    private IEnumerable<ItemTypeBrandViewModel> _itemTypeBrands = Enumerable.Empty<ItemTypeBrandViewModel>();

    protected override async Task OnInitializedAsync()
    {
        _itemTypeBrands = (await QueryRouter.Send(new GetItemTypeBrands(ItemType.Id))).ItemTypeBrands;
    }

    private async Task OnInputChange(int value)
    {
        await ValueChanged.InvokeAsync(value);
    }
}
