namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonOccupationsModel(Entity.Person person)
{
    public RecentPersonOccupationModel[] Occupations { get; }
        = person.Occupations
                .Select(personOccupation => new RecentPersonOccupationModel(personOccupation))
                .ToArray();

    public string OccupationsDisplayText
        => string.Join(", ", Occupations.Select(occupation => occupation.DisplayText));

    public RecentPersonPositionModel[] Positions { get; }
        = person.Positions
                .Select(personPosition => new RecentPersonPositionModel(personPosition))
                .ToArray();

    public string PositionsDisplayText
        => string.Join(", ", Positions.Select(position => position.DisplayText));

    public RecentPersonSportModel[] Sports { get; }
        = person.Sports
                .Select(personSport => new RecentPersonSportModel(personSport))
                .ToArray();

    public string SportsDisplayText
        => string.Join(", ", Sports.Select(sport => sport.DisplayText));
}
