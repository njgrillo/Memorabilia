using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class JerseyTypesViewModel : DomainsViewModel
    {
        public JerseyTypesViewModel() { }

        public JerseyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Jersey Types";
    }
}
