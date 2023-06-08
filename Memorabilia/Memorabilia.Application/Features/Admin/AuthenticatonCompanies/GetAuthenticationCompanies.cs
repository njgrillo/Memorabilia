namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompanies() : IQuery<AuthenticationCompaniesModel>
{
    public class Handler : QueryHandler<GetAuthenticationCompanies, AuthenticationCompaniesModel>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<AuthenticationCompaniesModel> Handle(GetAuthenticationCompanies query)
        {
            return new AuthenticationCompaniesModel(await _authenticationCompanyRepository.GetAll());
        }
    }
}
