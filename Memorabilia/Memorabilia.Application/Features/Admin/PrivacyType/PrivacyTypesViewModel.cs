using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.PrivacyType
{
    public class PrivacyTypesViewModel : DomainsViewModel
    {
        public PrivacyTypesViewModel() { }

        public PrivacyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Privacy Types";
    }
}
