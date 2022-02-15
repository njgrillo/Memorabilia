using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.PurchaseType
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
