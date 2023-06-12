namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonPositionModel : RecentPersonViewModel
{
    public Enum.PositionType PositionType { get; private set; }

    public RecentPersonPositionModel(Entity.PersonPosition personPosition)
	{
        DisplayText = $"{Constant.Position.Find(personPosition.PositionId)?.Name} - {(personPosition.IsPrimary ? "Primary" : "Secondary")}";
        Id = personPosition.PositionId;
        PositionType = personPosition.IsPrimary 
            ? Enum.PositionType.Primary 
            : Enum.PositionType.Secondary;
    }
}
