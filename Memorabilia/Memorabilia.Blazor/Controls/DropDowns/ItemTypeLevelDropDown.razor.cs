#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class ItemTypeLevelDropDown : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public int SelectedValue { get; set; }

    [Parameter]
    public int Value { get; set; }

    [Parameter]
    public EventCallback<int> ValueChanged { get; set; }

    private IEnumerable<ItemTypeLevelViewModel> _itemTypeLevels = Enumerable.Empty<ItemTypeLevelViewModel>();

    protected override async Task OnInitializedAsync()
    {
        _itemTypeLevels = (await QueryRouter.Send(new GetItemTypeLevels.Query(ItemType.Id))).ItemTypeLevels;
    }

    private async Task OnInputChange(int value)
    {
        await ValueChanged.InvokeAsync(value);
    }
}
