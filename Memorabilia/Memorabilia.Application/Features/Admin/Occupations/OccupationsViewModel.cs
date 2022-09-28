using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations
{
    public class OccupationsViewModel : DomainsViewModel
    {
        public OccupationsViewModel() { }

        public OccupationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Occupation";

        public override string PageTitle => "Occupations";

        public override string RoutePrefix => "Occupations";
    }
}
