using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class SaveItemTypeSpotViewModel : EditModel
{
    public SaveItemTypeSpotViewModel() { }

    public SaveItemTypeSpotViewModel(ItemTypeSpotViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        Spot = Spot.Find(viewModel.SpotId);
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSpots.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeSpots.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeSpots.Item;

    public ItemType ItemType { get; set; }

    public override string RoutePrefix => AdminDomainItem.ItemTypeSpots.Page;

    public Spot Spot { get; set; }    
}
