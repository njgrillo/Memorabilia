namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompany(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository) 
        : QueryHandler<GetAuthenticationCompany, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetAuthenticationCompany query)
            => await authenticationCompanyRepository.Get(query.Id);
    }
}
