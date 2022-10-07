using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public class GetAuthenticationCompanies
{
    public class Handler : QueryHandler<Query, AuthenticationCompaniesViewModel>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<AuthenticationCompaniesViewModel> Handle(Query query)
        {
            return new AuthenticationCompaniesViewModel(await _authenticationCompanyRepository.GetAll());
        }
    }

    public class Query : IQuery<AuthenticationCompaniesViewModel> { }
}
