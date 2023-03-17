namespace Memorabilia.Domain.Extensions;

public static class PersonExtensions
{
    public static int GetPrimarySportId(this Entities.Person person)
    {
        if (!person.Sports.Any())
            return 0;

        Entities.PersonSport sport = person.Sports.Single(sport => sport.IsPrimary);

        return sport.SportId;
    }
}
