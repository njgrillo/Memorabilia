﻿using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class BasketballProfileRule : IProfileRule
{
    public bool Applies(Person person)
    {
        return person.Occupations.Any(occupation => occupation.OccupationId == Domain.Constants.Occupation.Athlete.Id) &&
               person.Sports.Any(sport => sport.SportId == Domain.Constants.Sport.Basketball.Id);
    }

    public ProfileType GetProfileType()
    {
        return ProfileType.Basketball;
    }
}
