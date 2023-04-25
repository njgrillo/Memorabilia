using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Tools.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRuleFactory _profileRuleFactory;

    public ProfileService(IProfileRuleFactory profileRuleFactory)
    {
        _profileRuleFactory = profileRuleFactory;
    }

    public ProfileType[] GetProfileTypes(Domain.Entities.Person person, Domain.Entities.PersonOccupation occupation)
    {
        var profileTypes = new List<ProfileType>();

        foreach (var rule in _profileRuleFactory.Rules)
        {
            if (rule.Applies(person, occupation))
            {
                profileTypes.Add(rule.GetProfileType());
            }
        }

        return profileTypes.ToArray();
    }
}
