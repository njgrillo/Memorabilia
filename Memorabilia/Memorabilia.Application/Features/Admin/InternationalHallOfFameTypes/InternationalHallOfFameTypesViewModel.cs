using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes
{
    public class InternationalHallOfFameTypesViewModel : DomainsViewModel
    {
        public InternationalHallOfFameTypesViewModel() { }

        public InternationalHallOfFameTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "International Hall of Fame Type";

        public override string PageTitle => "International Hall of Fame Types";

        public override string RoutePrefix => "InternationalHallOfFameTypes";
    }
}
