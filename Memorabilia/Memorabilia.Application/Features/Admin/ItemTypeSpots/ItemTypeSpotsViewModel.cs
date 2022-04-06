using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots
{
    public class ItemTypeSpotsViewModel : ViewModel
    {
        public ItemTypeSpotsViewModel() { }

        public ItemTypeSpotsViewModel(IEnumerable<ItemTypeSpot> itemTypeSpots)
        {
            ItemTypeSpots = itemTypeSpots.Select(ItemTypeSpot => new ItemTypeSpotViewModel(ItemTypeSpot)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeSpotViewModel> ItemTypeSpots { get; set; } = new();

        public override string ItemTitle => "Item Type Spot";

        public override string PageTitle => "Item Type Spots";

        public override string RoutePrefix => "ItemTypeSpots";
    }
}
