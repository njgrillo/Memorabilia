using Memorabilia.Domain.Entities;
using Memorabilia.Domain.Enums;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonPositionViewModel : EditModel
{
    public SavePersonPositionViewModel() { }

    public SavePersonPositionViewModel(PersonPosition position)
    {
        Id = position.Id;
        PersonId = position.PersonId;
        Position = Constant.Position.Find(position.PositionId);
        PositionType = position.IsPrimary ? PositionType.Primary : PositionType.Secondary;
    }

    public int PersonId { get; set; }

    public Constant.Position Position { get; set; }

    public string PositionName => Position?.Name;

    public PositionType PositionType { get; set; } = PositionType.Primary;

    public string PositionTypeName => PositionType == PositionType.Primary ? "Primary" : "Secondary";
}
