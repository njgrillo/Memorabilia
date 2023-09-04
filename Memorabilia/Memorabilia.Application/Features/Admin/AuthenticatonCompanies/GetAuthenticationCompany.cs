namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAuthenticationCompany(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetAuthenticationCompany, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetAuthenticationCompany query)
            => await _authenticationCompanyRepository.Get(query.Id);
    }
}
