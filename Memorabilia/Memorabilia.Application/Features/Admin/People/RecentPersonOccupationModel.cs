namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonOccupationModel : RecentPersonModel
{
    public int OccupationTypeId { get; private set; }

    public RecentPersonOccupationModel(Entity.PersonOccupation personOccupation)
	{
        DisplayText = $"{Constant.Occupation.Find(personOccupation.OccupationId)?.Name} - {Constant.OccupationType.Find(personOccupation.OccupationTypeId)?.Name}";
        Id = personOccupation.OccupationId;
        OccupationTypeId = personOccupation.OccupationTypeId;
    }    
}
