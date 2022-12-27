using Memorabilia.Domain.Entities;
using Memorabilia.Domain.Enums;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonPositionViewModel : SaveViewModel
{
    public SavePersonPositionViewModel() { }

    public SavePersonPositionViewModel(PersonPosition position)
    {
        Id = position.Id;
        PersonId = position.PersonId;
        Position = Domain.Constants.Position.Find(position.PositionId);
        PositionType = position.IsPrimary ? PositionType.Primary : PositionType.Secondary;
    }

    public int PersonId { get; set; }

    public Domain.Constants.Position Position { get; set; }

    public string PositionName => Position?.Name;

    public PositionType PositionType { get; set; } = PositionType.Primary;

    public string PositionTypeName => PositionType == PositionType.Primary ? "Primary" : "Secondary";
}
