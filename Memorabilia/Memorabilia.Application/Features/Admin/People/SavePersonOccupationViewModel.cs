using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonOccupationViewModel : SaveViewModel
{
    public SavePersonOccupationViewModel() { }

    public SavePersonOccupationViewModel(PersonOccupation occupation)
    {
        Id = occupation.Id;
        Occupation = Domain.Constants.Occupation.Find(occupation.OccupationId);
        OccupationType = Domain.Constants.OccupationType.Find(occupation.OccupationTypeId);
    }

    public Domain.Constants.Occupation Occupation { get; set; }

    public string OccupationName => Occupation?.Name;

    public Domain.Constants.OccupationType OccupationType { get; set; } = Domain.Constants.OccupationType.Primary;

    public string OccupationTypeName => OccupationType?.Name;
}
