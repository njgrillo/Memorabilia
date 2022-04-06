using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.HelmetTypes
{
    public class HelmetTypesViewModel : DomainsViewModel
    {
        public HelmetTypesViewModel() { }

        public HelmetTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Helmet Type";

        public override string PageTitle => "Helmet Types";

        public override string RoutePrefix => "HelmetTypes";
    }
}
