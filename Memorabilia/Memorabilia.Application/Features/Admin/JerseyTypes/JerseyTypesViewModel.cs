using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes
{
    public class JerseyTypesViewModel : DomainsViewModel
    {
        public JerseyTypesViewModel() { }

        public JerseyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Jersey Type";

        public override string PageTitle => "Jersey Types";

        public override string RoutePrefix => "JerseyTypes";
    }
}
