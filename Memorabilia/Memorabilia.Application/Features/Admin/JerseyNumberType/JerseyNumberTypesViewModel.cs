using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.JerseyNumberType
{
    public class JerseyNumberTypesViewModel : DomainsViewModel
    {
        public JerseyNumberTypesViewModel() { }

        public JerseyNumberTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Jersey Number Types";
    }
}
