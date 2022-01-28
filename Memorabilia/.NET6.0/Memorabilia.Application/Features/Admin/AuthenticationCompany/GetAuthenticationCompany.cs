using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class GetAuthenticationCompany
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IAuthenticationCompanyRepository _authenticationCompanyRepository;

            public Handler(IAuthenticationCompanyRepository authenticationCompanyRepository)
            {
                _authenticationCompanyRepository = authenticationCompanyRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var authenticationCompany = await _authenticationCompanyRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(authenticationCompany);

                return viewModel;
            }
        }
    }
}
