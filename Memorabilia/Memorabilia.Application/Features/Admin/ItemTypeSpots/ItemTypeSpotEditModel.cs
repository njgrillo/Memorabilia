namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class ItemTypeSpotEditModel : EditModel
{
    public ItemTypeSpotEditModel() { }

    public ItemTypeSpotEditModel(ItemTypeSpotModel model)
    {
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        Spot = Constant.Spot.Find(model.SpotId);
    }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.ItemTypeSpots.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.ItemTypeSpots.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSpots.Item;

    public Constant.ItemType ItemType { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSpots.Page;

    public Constant.Spot Spot { get; set; }    
}
