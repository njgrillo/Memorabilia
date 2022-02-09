using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AuthenticType
{
    public class AuthenticTypesViewModel : DomainsViewModel
    {
        public AuthenticTypesViewModel() { }

        public AuthenticTypesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Authentic Types";
    }
}
