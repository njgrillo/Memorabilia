namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class OccupationsProfileModel
{
    private readonly Entity.Person _person;

    public OccupationsProfileModel(Entity.Person person)
    {
        _person = person;
    }

    public Entity.PersonOccupation[] Occupations
        => _person.Occupations
                  .OrderBy(occupation => occupation.OccupationTypeId)
                  .ToArray();
}
