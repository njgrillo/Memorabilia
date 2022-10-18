using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompanies() : IQuery<AuthenticationCompaniesViewModel>
{
    public class Handler : QueryHandler<GetAuthenticationCompanies, AuthenticationCompaniesViewModel>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<AuthenticationCompaniesViewModel> Handle(GetAuthenticationCompanies query)
        {
            return new AuthenticationCompaniesViewModel(await _authenticationCompanyRepository.GetAll());
        }
    }
}
