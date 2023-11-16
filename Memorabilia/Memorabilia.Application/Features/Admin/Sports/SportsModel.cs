namespace Memorabilia.Application.Features.Admin.Sports;

public class SportsModel : Model
{
    public SportsModel() { }

    public SportsModel(IEnumerable<Entity.Sport> sports) 
    {
        Sports = sports.Select(sport => new SportModel(sport))
                       .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.Sports.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Sports.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Sports.Page;

    public List<SportModel> Sports { get; set; } 
        = [];
}
