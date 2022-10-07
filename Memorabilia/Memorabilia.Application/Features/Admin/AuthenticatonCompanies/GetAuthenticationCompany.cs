using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public class GetAuthenticationCompany
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _authenticationCompanyRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
