using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.HelmetType
{
    public class HelmetTypesViewModel : DomainsViewModel
    {
        public HelmetTypesViewModel() { }

        public HelmetTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Helmet Types";
    }
}
