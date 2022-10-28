using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotsViewModel : ViewModel
{
    public ItemTypeSpotsViewModel() { }

    public ItemTypeSpotsViewModel(IEnumerable<ItemTypeSpot> itemTypeSpots)
    {
        ItemTypeSpots = itemTypeSpots.Select(ItemTypeSpot => new ItemTypeSpotViewModel(ItemTypeSpot))
                                     .OrderBy(itemTypeSpot => itemTypeSpot.ItemTypeName)
                                     .ThenBy(itemTypeSpot => itemTypeSpot.SpotName)
                                     .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSpotViewModel> ItemTypeSpots { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeSpots.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeSpots.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSpots.Page;
}
