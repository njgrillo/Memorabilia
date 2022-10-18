using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record SaveAuthenticationCompany(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAuthenticationCompany>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task Handle(SaveAuthenticationCompany request)
        {
            AuthenticationCompany authenticationCompany;

            if (request.ViewModel.IsNew)
            {
                authenticationCompany = new AuthenticationCompany(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _authenticationCompanyRepository.Add(authenticationCompany);

                return;
            }

            authenticationCompany = await _authenticationCompanyRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _authenticationCompanyRepository.Delete(authenticationCompany);

                return;
            }

            authenticationCompany.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _authenticationCompanyRepository.Update(authenticationCompany);
        }
    }
}
