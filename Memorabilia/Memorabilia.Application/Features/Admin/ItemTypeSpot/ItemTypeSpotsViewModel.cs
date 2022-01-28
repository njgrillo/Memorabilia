using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class ItemTypeSpotsViewModel : ViewModel
    {
        public ItemTypeSpotsViewModel() { }

        public ItemTypeSpotsViewModel(IEnumerable<Domain.Entities.ItemTypeSpot> itemTypeSpots)
        {
            ItemTypeSpots = itemTypeSpots.Select(ItemTypeSpot => new ItemTypeSpotViewModel(ItemTypeSpot));
        }

        public IEnumerable<ItemTypeSpotViewModel> ItemTypeSpots { get; set; } = Enumerable.Empty<ItemTypeSpotViewModel>();

        public override string PageTitle => "Item Type Spots";        
    }
}
