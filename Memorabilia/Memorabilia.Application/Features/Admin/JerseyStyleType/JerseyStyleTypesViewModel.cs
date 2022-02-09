using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.JerseyStyleType
{
    public class JerseyStyleTypesViewModel : DomainsViewModel
    {
        public JerseyStyleTypesViewModel() { }

        public JerseyStyleTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Jersey Style Types";
    }
}
