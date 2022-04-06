using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.DropDowns
{
    public partial class ItemTypeBrandDropDown : ComponentBase
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

        private IEnumerable<ItemTypeBrandViewModel> _itemTypeBrands = Enumerable.Empty<ItemTypeBrandViewModel>();

        protected override async Task OnInitializedAsync()
        {
            _itemTypeBrands = (await QueryRouter.Send(new GetItemTypeBrands.Query(ItemType.Id)).ConfigureAwait(false)).ItemTypeBrands;
        }

        private async Task OnInputChange(int value)
        {
            await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
        }
    }
}
