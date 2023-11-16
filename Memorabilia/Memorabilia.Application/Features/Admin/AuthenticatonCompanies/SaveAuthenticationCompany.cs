namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveAuthenticationCompany(DomainEditModel AuthenticationCompany) 
    : ICommand
{
    public class Handler(IDomainRepository<Entity.AuthenticationCompany> authenticationCompanyRepository) 
        : CommandHandler<SaveAuthenticationCompany>
    {
        protected override async Task Handle(SaveAuthenticationCompany request)
        {
            Entity.AuthenticationCompany authenticationCompany;

            if (request.AuthenticationCompany.IsNew)
            {
                authenticationCompany = new Entity.AuthenticationCompany(request.AuthenticationCompany.Name, 
                                                                         request.AuthenticationCompany.Abbreviation);

                await authenticationCompanyRepository.Add(authenticationCompany);

                return;
            }

            authenticationCompany = await authenticationCompanyRepository.Get(request.AuthenticationCompany.Id);

            if (request.AuthenticationCompany.IsDeleted)
            {
                await authenticationCompanyRepository.Delete(authenticationCompany);

                return;
            }

            authenticationCompany.Set(request.AuthenticationCompany.Name, 
                                      request.AuthenticationCompany.Abbreviation);

            await authenticationCompanyRepository.Update(authenticationCompany);
        }
    }
}
