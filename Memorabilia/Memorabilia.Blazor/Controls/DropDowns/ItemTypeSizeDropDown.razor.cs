#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns
{
    public partial class ItemTypeSizeDropDown : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public ItemType ItemType { get; set; }

        [Parameter]
        public int SelectedValue { get; set; }

        [Parameter]
        public int Value { get; set; }

        private IEnumerable<ItemTypeSizeViewModel> _itemTypeSizes = Enumerable.Empty<ItemTypeSizeViewModel>();

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _itemTypeSizes = (await QueryRouter.Send(new GetItemTypeSizes.Query(ItemType.Id)).ConfigureAwait(false))
                                            .ItemTypeSizes
                                            .OrderByDescending(size => size.SizeName);
        }

        private async Task OnInputChange(int value)
        {
            await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
        }
    }
}
