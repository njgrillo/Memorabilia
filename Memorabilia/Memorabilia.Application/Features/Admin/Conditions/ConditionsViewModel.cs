using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.Conditions
{
    public class ConditionsViewModel : DomainsViewModel
    {
        public ConditionsViewModel() { }

        public ConditionsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Condition";

        public override string PageTitle => "Conditions";

        public override string RoutePrefix => "Conditions";
    }
}
