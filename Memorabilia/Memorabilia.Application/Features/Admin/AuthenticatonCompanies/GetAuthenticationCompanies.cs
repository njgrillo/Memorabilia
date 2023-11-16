namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompanies() : IQuery<Entity.AuthenticationCompany[]>
{
    public class Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository) 
        : QueryHandler<GetAuthenticationCompanies, Entity.AuthenticationCompany[]>
    {
        protected override async Task<Entity.AuthenticationCompany[]> Handle(GetAuthenticationCompanies query)
            => await authenticationCompanyRepository.GetAll();
    }
}
