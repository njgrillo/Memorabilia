using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class AuthenticationCompaniesViewModel : DomainsViewModel
    {
        public AuthenticationCompaniesViewModel() { }

        public AuthenticationCompaniesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Authentication Companies";
    }
}
