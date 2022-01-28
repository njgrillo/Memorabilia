using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Occupation
{
    public class OccupationsViewModel : DomainsViewModel
    {
        public OccupationsViewModel() { }

        public OccupationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Occupations";
    }
}
