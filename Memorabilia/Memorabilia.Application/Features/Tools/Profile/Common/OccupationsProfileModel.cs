namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class OccupationsProfileModel(Entity.Person person)
{
    public Entity.PersonOccupation[] Occupations
        => person.Occupations
                 .OrderBy(occupation => occupation.OccupationTypeId)
                 .ToArray();
}
