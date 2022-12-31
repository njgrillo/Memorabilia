﻿using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class FootballProfileRule : IProfileRule
{
    public bool Applies(Person person)
    {
        return person.Occupations.Any(occupation => occupation.OccupationId == Domain.Constants.Occupation.Athlete.Id) &&
               person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.SportId == Domain.Constants.Sport.Football.Id);
    }

    public ProfileType GetProfileType()
    {
        return ProfileType.Football;
    }
}
