namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompany(int Id) : IQuery<Entity.AuthenticationCompany>
{
    public class Handler : QueryHandler<GetAuthenticationCompany, Entity.AuthenticationCompany>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<Entity.AuthenticationCompany> Handle(GetAuthenticationCompany query)
            => await _authenticationCompanyRepository.Get(query.Id);
    }
}
