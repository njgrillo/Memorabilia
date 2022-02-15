using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class GetAuthenticationCompanies
    {
        public class Handler : QueryHandler<Query, AuthenticationCompaniesViewModel>
        {
            private readonly IAuthenticationCompanyRepository _authenticationCompanyRepository;

            public Handler(IAuthenticationCompanyRepository authenticationCompanyRepository)
            {
                _authenticationCompanyRepository = authenticationCompanyRepository;
            }

            protected override async Task<AuthenticationCompaniesViewModel> Handle(Query query)
            {
                var authenticationCompanies = await _authenticationCompanyRepository.GetAll().ConfigureAwait(false);

                var viewModel = new AuthenticationCompaniesViewModel(authenticationCompanies);

                return viewModel;
            }
        }

        public class Query : IQuery<AuthenticationCompaniesViewModel> { }
    }
}
