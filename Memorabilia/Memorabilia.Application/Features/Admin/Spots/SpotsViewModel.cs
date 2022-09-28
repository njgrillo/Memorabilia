using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots
{
    public class SpotsViewModel : DomainsViewModel
    {
        public SpotsViewModel() { }

        public SpotsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Spot";

        public override string PageTitle => "Spots";

        public override string RoutePrefix => "Spots";
    }
}
