using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.LeaderTypes
{
    public class LeaderTypesViewModel : DomainsViewModel
    {
        public LeaderTypesViewModel() { }

        public LeaderTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Leader Type";

        public override string PageTitle => "Leader Types";

        public override string RoutePrefix => "LeaderTypes";
    }
}
