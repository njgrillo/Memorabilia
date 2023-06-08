namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public class AuthenticationCompaniesModel : DomainsModel
{
    public AuthenticationCompaniesModel() { }

    public AuthenticationCompaniesModel(IEnumerable<Entity.DomainEntity> domainEntities) 
        : base(domainEntities) { }

    public override string ItemTitle 
        => Constant.AdminDomainItem.AuthenticationCompanies.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.AuthenticationCompanies.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.AuthenticationCompanies.Page;
}
