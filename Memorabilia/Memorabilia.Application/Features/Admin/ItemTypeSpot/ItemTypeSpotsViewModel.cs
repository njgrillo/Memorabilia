using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class ItemTypeSpotsViewModel : ViewModel
    {
        public ItemTypeSpotsViewModel() { }

        public ItemTypeSpotsViewModel(IEnumerable<Domain.Entities.ItemTypeSpot> itemTypeSpots)
        {
            ItemTypeSpots = itemTypeSpots.Select(ItemTypeSpot => new ItemTypeSpotViewModel(ItemTypeSpot)).ToList();
        }

        public List<ItemTypeSpotViewModel> ItemTypeSpots { get; set; } = new();

        public override string ItemTitle => "Item Type Spot";

        public override string PageTitle => "Item Type Spots";

        public override string RoutePrefix => "ItemTypeSpots";
    }
}
