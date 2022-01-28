using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spot
{
    public class SpotsViewModel : DomainsViewModel
    {
        public SpotsViewModel() { }

        public SpotsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Spots";
    }
}
