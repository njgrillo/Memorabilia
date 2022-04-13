using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes
{
    public class FranchiseHallOfFameTypesViewModel : DomainsViewModel
    {
        public FranchiseHallOfFameTypesViewModel() { }

        public FranchiseHallOfFameTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Franchise Hall of Fame Type";

        public override string PageTitle => "Franchise Hall of Fame Types";

        public override string RoutePrefix => "FranchiseHallOfFameTypes";
    }
}
