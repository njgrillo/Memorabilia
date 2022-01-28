using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class SaveAuthenticationCompany
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IAuthenticationCompanyRepository _authenticationCompanyRepository;

            public Handler(IAuthenticationCompanyRepository authenticationCompanyRepository)
            {
                _authenticationCompanyRepository = authenticationCompanyRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
            {
                Domain.Entities.AuthenticationCompany authenticationCompany;

                if (command.IsNew)
                {
                    authenticationCompany = new Domain.Entities.AuthenticationCompany(command.Name, command.Abbreviation);
                    await _authenticationCompanyRepository.Add(authenticationCompany).ConfigureAwait(false);

                    return;
                }

                authenticationCompany = await _authenticationCompanyRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _authenticationCompanyRepository.Delete(authenticationCompany).ConfigureAwait(false);

                    return;
                }

                authenticationCompany.Set(command.Name, command.Abbreviation);

                await _authenticationCompanyRepository.Update(authenticationCompany).ConfigureAwait(false);
            }
        }        
    }
}
