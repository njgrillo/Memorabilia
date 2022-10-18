using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record GetAuthenticationCompany(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetAuthenticationCompany, DomainViewModel>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetAuthenticationCompany query)
        {
            return new DomainViewModel(await _authenticationCompanyRepository.Get(query.Id));
        }
    }
}
