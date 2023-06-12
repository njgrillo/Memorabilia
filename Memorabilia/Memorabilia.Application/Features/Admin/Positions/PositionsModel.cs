namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionsModel : Model
{
    public PositionsModel() { }

    public PositionsModel(IEnumerable<Entity.Position> positions)
    {
        Positions = positions.Select(position => new PositionModel(position))
                             .OrderBy(position => position.SportName)
                             .ThenBy(position => position.Name)
                             .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.Positions.Item;

    public List<PositionModel> Positions { get; set; } 
        = new();

    public override string PageTitle 
        => Constant.AdminDomainItem.Positions.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Positions.Page;
}
