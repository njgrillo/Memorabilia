namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies
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
                return new AuthenticationCompaniesViewModel(await _authenticationCompanyRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AuthenticationCompaniesViewModel> { }
    }
}
