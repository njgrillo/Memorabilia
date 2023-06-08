namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompany(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetAuthenticationCompany, DomainModel>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<DomainModel> Handle(GetAuthenticationCompany query)
        {
            return new DomainModel(await _authenticationCompanyRepository.Get(query.Id));
        }
    }
}
