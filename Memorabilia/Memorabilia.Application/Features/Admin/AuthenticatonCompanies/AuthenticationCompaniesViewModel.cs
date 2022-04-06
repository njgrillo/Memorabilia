using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies
{
    public class AuthenticationCompaniesViewModel : DomainsViewModel
    {
        public AuthenticationCompaniesViewModel() { }

        public AuthenticationCompaniesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string ItemTitle => "Authentication Company";

        public override string PageTitle => "Authentication Companies";

        public override string RoutePrefix => "AuthenticationCompanies";
    }
}
