namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public record SaveAuthenticationCompany(DomainEditModel AuthenticationCompany) : ICommand
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

            if (request.AuthenticationCompany.IsNew)
            {
                authenticationCompany = new Entity.AuthenticationCompany(request.AuthenticationCompany.Name, 
                                                                         request.AuthenticationCompany.Abbreviation);

                await _authenticationCompanyRepository.Add(authenticationCompany);

                return;
            }

            authenticationCompany = await _authenticationCompanyRepository.Get(request.AuthenticationCompany.Id);

            if (request.AuthenticationCompany.IsDeleted)
            {
                await _authenticationCompanyRepository.Delete(authenticationCompany);

                return;
            }

            authenticationCompany.Set(request.AuthenticationCompany.Name, 
                                      request.AuthenticationCompany.Abbreviation);

            await _authenticationCompanyRepository.Update(authenticationCompany);
        }
    }
}
