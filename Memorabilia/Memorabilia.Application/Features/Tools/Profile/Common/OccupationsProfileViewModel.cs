using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class OccupationsProfileViewModel
{
    private readonly Person _person;

    public OccupationsProfileViewModel(Person person)
    {
        _person = person;
    }

    public PersonOccupation[] Occupations
        => _person.Occupations
                  .OrderBy(occupation => occupation.OccupationTypeId)
                  .ToArray();
}
