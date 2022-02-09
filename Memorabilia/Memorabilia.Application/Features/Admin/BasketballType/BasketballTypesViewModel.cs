using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.BasketballType
{
    public class BasketballTypesViewModel : DomainsViewModel
    {
        public BasketballTypesViewModel() { }

        public BasketballTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Basketball Types";
    }
}
