using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonOccupationViewModel : RecentPersonEntityViewModel
{
    public int OccupationTypeId { get; private set; }

    public RecentPersonOccupationViewModel(PersonOccupation personOccupation)
	{
        DisplayText = $"{Domain.Constants.Occupation.Find(personOccupation.OccupationId)?.Name} - {Domain.Constants.OccupationType.Find(personOccupation.OccupationTypeId)?.Name}";
        Id = personOccupation.OccupationId;
        OccupationTypeId = personOccupation.OccupationTypeId;
    }    
}
