using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class AuthenticationCompaniesViewModel : DomainsViewModel
    {
        public AuthenticationCompaniesViewModel() { }

        public AuthenticationCompaniesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

        public override string PageTitle => "Authentication Companies";
    }
}
