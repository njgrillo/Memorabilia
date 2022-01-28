using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class ConditionsViewModel : DomainsViewModel
    {
        public ConditionsViewModel() { }

        public ConditionsViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Conditions";
    }
}
