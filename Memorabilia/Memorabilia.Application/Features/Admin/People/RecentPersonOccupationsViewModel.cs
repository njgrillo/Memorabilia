using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonOccupationsViewModel
{
    public RecentPersonOccupationsViewModel(Person person)
    {
        Occupations = person.Occupations
                            .Select(personOccupation => new RecentPersonOccupationViewModel(personOccupation))
                            .ToArray();
        Positions = person.Positions
                          .Select(personPosition => new RecentPersonPositionViewModel(personPosition))
                          .ToArray();
        Sports = person.Sports
                       .Select(personSport => new RecentPersonSportViewModel(personSport))
                       .ToArray();
    }

    public RecentPersonOccupationViewModel[] Occupations { get; } = Array.Empty<RecentPersonOccupationViewModel>();

    public string OccupationsDisplayText
        => string.Join(", ", Occupations.Select(occupation => occupation.DisplayText));

    public RecentPersonPositionViewModel[] Positions { get; } = Array.Empty<RecentPersonPositionViewModel>();

    public string PositionsDisplayText
        => string.Join(", ", Positions.Select(position => position.DisplayText));

    public RecentPersonSportViewModel[] Sports { get; } = Array.Empty<RecentPersonSportViewModel>();

    public string SportsDisplayText
        => string.Join(", ", Sports.Select(sport => sport.DisplayText));
}
