namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportModel
{
    private readonly Entity.ItemTypeSport _itemTypeSport;

    public ItemTypeSportModel() { }

    public ItemTypeSportModel(Entity.ItemTypeSport itemTypeSport)
    {
        _itemTypeSport = itemTypeSport;
    }

    public string DeleteText 
        => $"Delete {Constant.AdminDomainItem.ItemTypeSports.Item}";

    public int Id 
        => _itemTypeSport.Id;

    public int ItemTypeId 
        => _itemTypeSport.ItemTypeId;

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId).Name;

    public int SportId 
        => _itemTypeSport.SportId;

    public string SportName 
        => Constant.Sport.Find(SportId).Name;
}
