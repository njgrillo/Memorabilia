using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes
{
    public class JerseyStyleTypesViewModel : DomainsViewModel
    {
        public JerseyStyleTypesViewModel() { }

        public JerseyStyleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Jersey Style Type";

        public override string PageTitle => "Jersey Style Types";

        public override string RoutePrefix => "JerseyStyleTypes";
    }
}
