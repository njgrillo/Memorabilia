namespace Memorabilia.Application.Features.Services.Tools.Profile;

public class ProfileService(IProfileRuleFactory profileRuleFactory) 
    : IProfileService
{
    public Constant.ProfileType[] GetProfileTypes(Entity.Person person, Entity.PersonOccupation occupation)
    {
        var profileTypes = new List<Constant.ProfileType>();

        foreach (var rule in profileRuleFactory.Rules)
        {
            if (rule.Applies(person, occupation))
            {
                profileTypes.Add(rule.GetProfileType());
            }
        }

        return profileTypes.ToArray();
    }
}
