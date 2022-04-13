using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AwardTypes
{
    public class AwardTypesViewModel : DomainsViewModel
    {
        public AwardTypesViewModel() { }

        public AwardTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Award Type";

        public override string PageTitle => "Award Types";

        public override string RoutePrefix => "AwardTypes";
    }
}
