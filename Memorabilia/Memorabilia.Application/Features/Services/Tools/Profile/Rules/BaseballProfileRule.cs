using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class BaseballProfileRule : IProfileRule
{
    public bool Applies(Person person)
    {
        return person.Sports.Any(sport => sport.SportId == Domain.Constants.Sport.Baseball.Id);
    }

    public ProfileType GetProfileType()
    {
        return ProfileType.Baseball;
    }
}
