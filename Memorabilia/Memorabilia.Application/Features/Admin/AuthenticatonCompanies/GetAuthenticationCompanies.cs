namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAuthenticationCompanies() : IQuery<Entity.AuthenticationCompany[]>
{
    public class Handler : QueryHandler<GetAuthenticationCompanies, Entity.AuthenticationCompany[]>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<Entity.AuthenticationCompany[]> Handle(GetAuthenticationCompanies query)
            => await _authenticationCompanyRepository.GetAll();
    }
}
