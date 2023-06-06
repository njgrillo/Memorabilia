using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonPositionViewModel : RecentPersonEntityViewModel
{
    public Domain.Enums.PositionType PositionType { get; private set; }

    public RecentPersonPositionViewModel(PersonPosition personPosition)
	{
        DisplayText = $"{Constant.Position.Find(personPosition.PositionId)?.Name} - {(personPosition.IsPrimary ? "Primary" : "Secondary")}";
        Id = personPosition.PositionId;
        PositionType = personPosition.IsPrimary 
            ? Domain.Enums.PositionType.Primary 
            : Domain.Enums.PositionType.Secondary;
    }
}
