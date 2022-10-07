using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public class AuthenticationCompaniesViewModel : DomainsViewModel
{
    public AuthenticationCompaniesViewModel() { }

    public AuthenticationCompaniesViewModel(IEnumerable<DomainEntity> domainEntities) : base(domainEntities) { }

    public override string ItemTitle => AdminDomainItem.AuthenticationCompanies.Item;

    public override string PageTitle => AdminDomainItem.AuthenticationCompanies.Title;

    public override string RoutePrefix => AdminDomainItem.AuthenticationCompanies.Page;
}
