using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.BasketballTypes
{
    public class BasketballTypesViewModel : DomainsViewModel
    {
        public BasketballTypesViewModel() { }

        public BasketballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Basketball Type";

        public override string PageTitle => "Basketball Types";

        public override string RoutePrefix => "BasketballTypes";
    }
}
