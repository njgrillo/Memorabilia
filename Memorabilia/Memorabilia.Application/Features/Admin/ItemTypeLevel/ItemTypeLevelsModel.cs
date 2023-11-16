namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class ItemTypeLevelsModel : Model
{
    public ItemTypeLevelsModel() { }

    public ItemTypeLevelsModel(IEnumerable<Entity.ItemTypeLevel> itemTypeLevels)
    {
        ItemTypeLevels = itemTypeLevels.Select(itemTypeLevel => new ItemTypeLevelModel(itemTypeLevel))
                                       .OrderBy(itemTypeLevel => itemTypeLevel.ItemTypeName)
                                       .ThenBy(itemTypeLevel => itemTypeLevel.LevelTypeName)
                                       .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeLevelModel> ItemTypeLevels { get; set; } 
        = [];

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeLevels.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeLevels.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeLevels.Page;
}
