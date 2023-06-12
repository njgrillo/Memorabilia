namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonOccupationsModel
{
    public RecentPersonOccupationsModel(Entity.Person person)
    {
        Occupations = person.Occupations
                            .Select(personOccupation => new RecentPersonOccupationModel(personOccupation))
                            .ToArray();

        Positions = person.Positions
                          .Select(personPosition => new RecentPersonPositionModel(personPosition))
                          .ToArray();

        Sports = person.Sports
                       .Select(personSport => new RecentPersonSportModel(personSport))
                       .ToArray();
    }

    public RecentPersonOccupationModel[] Occupations { get; } 
        = Array.Empty<RecentPersonOccupationModel>();

    public string OccupationsDisplayText
        => string.Join(", ", Occupations.Select(occupation => occupation.DisplayText));

    public RecentPersonPositionModel[] Positions { get; } 
        = Array.Empty<RecentPersonPositionModel>();

    public string PositionsDisplayText
        => string.Join(", ", Positions.Select(position => position.DisplayText));

    public RecentPersonSportModel[] Sports { get; } 
        = Array.Empty<RecentPersonSportModel>();

    public string SportsDisplayText
        => string.Join(", ", Sports.Select(sport => sport.DisplayText));
}
