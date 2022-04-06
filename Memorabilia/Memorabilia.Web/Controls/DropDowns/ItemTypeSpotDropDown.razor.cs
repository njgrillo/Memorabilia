using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.ItemTypeSpots;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.DropDowns
{
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
            _itemTypeSpots = (await QueryRouter.Send(new GetItemTypeSpots.Query(ItemType?.Id)).ConfigureAwait(false))
                                        .ItemTypeSpots
                                        .OrderByDescending(spot => spot.SpotName);
        }

        private async Task OnInputChange(int value)
        {
            await ValueChanged.InvokeAsync(value).ConfigureAwait(false);
        }
    }
}
