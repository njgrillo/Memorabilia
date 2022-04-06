using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.ItemTypeSizes;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.DropDowns
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
