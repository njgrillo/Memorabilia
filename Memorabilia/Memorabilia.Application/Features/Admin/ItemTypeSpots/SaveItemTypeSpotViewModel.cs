using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class SaveItemTypeSpotViewModel : SaveViewModel
{
    public SaveItemTypeSpotViewModel() { }

    public SaveItemTypeSpotViewModel(ItemTypeSpotViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId;
        SpotId = viewModel.SpotId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSpots.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeSpots.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeSpots.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
    public int ItemTypeId { get; set; }

    public ItemType[] ItemTypes => ItemType.All;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSpots.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
    public int SpotId { get; set; }        

    public Spot[] Spots => Spot.All;
}
