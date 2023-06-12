namespace Memorabilia.Application.Features.Admin.Divisions;

public class DivisionsModel : Model
{
    public DivisionsModel() { }

    public DivisionsModel(IEnumerable<Entity.Division> divisions)
    {
        Divisions = divisions.Select(division => new DivisionModel(division))
                             .OrderBy(division => division.ConferenceName)
                             .ThenBy(division => division.LeagueName)
                             .ThenBy(division => division.Name)
                             .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<DivisionModel> Divisions { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.Divisions.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Divisions.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Divisions.Page;
}
