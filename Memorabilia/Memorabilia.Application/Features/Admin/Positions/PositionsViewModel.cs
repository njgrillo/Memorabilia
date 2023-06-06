using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionsViewModel : Model
{
    public PositionsViewModel() { }

    public PositionsViewModel(IEnumerable<Domain.Entities.Position> positions)
    {
        Positions = positions.Select(position => new PositionViewModel(position))
                         .OrderBy(position => position.SportName)
                         .ThenBy(position => position.Name)
                         .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.Positions.Item;

    public List<PositionViewModel> Positions { get; set; } = new();

    public override string PageTitle => AdminDomainItem.Positions.Title;

    public override string RoutePrefix => AdminDomainItem.Positions.Page;
}
