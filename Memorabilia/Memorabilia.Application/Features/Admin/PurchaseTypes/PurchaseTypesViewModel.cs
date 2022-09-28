using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes
{
    public class PurchaseTypesViewModel : DomainsViewModel
    {
        public PurchaseTypesViewModel() { }

        public PurchaseTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Purchase Type";

        public override string PageTitle => "Purchase Types";

        public override string RoutePrefix => "PurchaseTypes";
    }
}
