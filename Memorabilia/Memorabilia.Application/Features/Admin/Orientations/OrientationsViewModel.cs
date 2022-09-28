using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations
{
    public class OrientationsViewModel : DomainsViewModel
    {
        public OrientationsViewModel() { }

        public OrientationsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Orientation";

        public override string PageTitle => "Orientations";

        public override string RoutePrefix => "Orientations";
    }
}
