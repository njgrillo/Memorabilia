namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportsModel : Model
{
    public ItemTypeSportsModel() { }

    public ItemTypeSportsModel(IEnumerable<Entity.ItemTypeSport> itemTypeSports)
    {
        ItemTypeSports = itemTypeSports.Select(itemTypeSport => new ItemTypeSportModel(itemTypeSport))
                                       .OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                                       .ThenBy(itemTypeSport => itemTypeSport.SportName)
                                       .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSportModel> ItemTypeSports { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.ItemTypeSports.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.ItemTypeSports.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.ItemTypeSports.Page;
}
