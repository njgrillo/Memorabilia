using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Spot
{
    public class SpotsViewModel : DomainsViewModel
    {
        public SpotsViewModel() { }

        public SpotsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Spots";
    }
}
