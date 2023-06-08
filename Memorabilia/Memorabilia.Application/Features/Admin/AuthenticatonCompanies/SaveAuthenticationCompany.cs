namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record SaveAuthenticationCompany(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveAuthenticationCompany>
    {
        private readonly IDomainRepository<Entity.AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task Handle(SaveAuthenticationCompany request)
        {
            Entity.AuthenticationCompany authenticationCompany;

            if (request.ViewModel.IsNew)
            {
                authenticationCompany = new Entity.AuthenticationCompany(request.ViewModel.Name, request.ViewModel.Abbreviation);

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
