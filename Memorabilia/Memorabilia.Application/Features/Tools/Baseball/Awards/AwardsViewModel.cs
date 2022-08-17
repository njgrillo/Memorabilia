using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Tools.Baseball.Awards
{
    public class AwardsViewModel
    {
        public AwardsViewModel() { }

        public AwardsViewModel(IEnumerable<PersonAward> personAwards)
        {
            PersonAwards = personAwards.Select(award => new AwardViewModel(award));
        }

        public int AwardTypeId { get; set; }

        public Domain.Constants.AwardType[] AwardTypes => Domain.Constants.AwardType.GetAll(Domain.Constants.Sport.Baseball.Id);

        public IEnumerable<AwardViewModel> PersonAwards { get; set; } = Enumerable.Empty<AwardViewModel>();
    }
}
