using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.ProfileNew;

public class OccupationsProfileViewModel
{
    private readonly Person _person;

    public OccupationsProfileViewModel(Person person)
    {
        _person = person;
    }

    public PersonOccupation[] Occupations 
        => _person.Occupations
                  .OrderBy(occupation => occupation.OccupationTypeId == OccupationType.Primary.Id)
                  .ToArray();
}
