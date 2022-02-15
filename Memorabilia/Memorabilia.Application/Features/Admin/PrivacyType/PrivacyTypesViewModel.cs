using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.PrivacyType
{
    public class PrivacyTypesViewModel : DomainsViewModel
    {
        public PrivacyTypesViewModel() { }

        public PrivacyTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Privacy Type";

        public override string PageTitle => "Privacy Types";

        public override string RoutePrefix => "PrivacyTypes";
    }
}
