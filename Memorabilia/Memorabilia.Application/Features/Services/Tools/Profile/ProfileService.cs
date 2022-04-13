using Memorabilia.Application.Features.Services.Tools.Profile.Rules;
using Memorabilia.Domain.Constants;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Services.Tools.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IProfileRuleFactory _profileRuleFactory;

        public ProfileService(IPersonRepository personRepository, IProfileRuleFactory profileRuleFactory)
        {
            _personRepository = personRepository;
            _profileRuleFactory = profileRuleFactory;
        }

        public async Task<List<ProfileType>> GetProfileTypes(int personId)
        {
            var person = await _personRepository.Get(personId).ConfigureAwait(false);
            var profileTypes = new List<ProfileType>();

            foreach (var rule in _profileRuleFactory.Rules)
            {
                if (rule.Applies(person))
                {
                    profileTypes.Add(rule.GetProfileType());
                }
            }

            return profileTypes;
        }
    }
}
