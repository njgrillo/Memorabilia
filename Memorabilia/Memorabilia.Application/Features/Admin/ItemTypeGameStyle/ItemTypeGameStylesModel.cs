namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class ItemTypeGameStylesModel : Model
{
    public ItemTypeGameStylesModel() { }

    public ItemTypeGameStylesModel(IEnumerable<Entity.ItemTypeGameStyleType> itemTypeGameStyles)
    {
        ItemTypeGameStyles = itemTypeGameStyles.Select(itemTypeGameStyle => new ItemTypeGameStyleModel(itemTypeGameStyle))
                                               .OrderBy(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeName)
                                               .ThenBy(itemTypeGameStyleType => itemTypeGameStyleType.GameStyleTypeName)
                                               .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeGameStyleModel> ItemTypeGameStyles { get; set; } 
        = [];

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeGameStyles.Page;
}