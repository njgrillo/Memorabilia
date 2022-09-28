using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes
{
    public class JerseyQualityTypesViewModel : DomainsViewModel
    {
        public JerseyQualityTypesViewModel() { }

        public JerseyQualityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Jersey Quality Type";

        public override string PageTitle => "Jersey Quality Types";

        public override string RoutePrefix => "JerseyQualityTypes";
    }
}
