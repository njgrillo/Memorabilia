namespace Memorabilia.Application.Features.Admin.People;

public class PersonPositionEditModel : EditModel
{
    public PersonPositionEditModel() { }

    public PersonPositionEditModel(Entity.PersonPosition position)
    {
        Id = position.Id;
        PersonId = position.PersonId;
        Position = Constant.Position.Find(position.PositionId);

        PositionType = position.IsPrimary 
            ? Enum.PositionType.Primary 
            : Enum.PositionType.Secondary;
    }

    public int PersonId { get; set; }

    public Constant.Position Position { get; set; }

    public string PositionName 
        => Position?.Name;

    public Enum.PositionType PositionType { get; set; } 
        = Enum.PositionType.Primary;

    public string PositionTypeName 
        => PositionType == Enum.PositionType.Primary 
            ? "Primary" 
            : "Secondary";
}
