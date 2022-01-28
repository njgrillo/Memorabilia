using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.JerseyLevelType
{
    public class JerseyLevelTypesViewModel : DomainsViewModel
    {
        public JerseyLevelTypesViewModel() { }

        public JerseyLevelTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Jersey Level Types";
    }
}
