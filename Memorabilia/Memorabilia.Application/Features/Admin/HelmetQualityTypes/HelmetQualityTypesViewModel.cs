using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes
{
    public class HelmetQualityTypesViewModel : DomainsViewModel
    {
        public HelmetQualityTypesViewModel() { }

        public HelmetQualityTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Helmet Quality Type";

        public override string PageTitle => "Helmet Quality Types";

        public override string RoutePrefix => "HelmetQualityTypes";
    }
}