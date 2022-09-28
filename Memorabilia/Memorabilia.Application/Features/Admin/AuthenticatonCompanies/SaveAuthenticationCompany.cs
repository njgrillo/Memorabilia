using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies
{
    public class SaveAuthenticationCompany
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAuthenticationCompanyRepository _authenticationCompanyRepository;

            public Handler(IAuthenticationCompanyRepository authenticationCompanyRepository)
            {
                _authenticationCompanyRepository = authenticationCompanyRepository;
            }

            protected override async Task Handle(Command command)
            {
                AuthenticationCompany authenticationCompany;

                if (command.IsNew)
                {
                    authenticationCompany = new AuthenticationCompany(command.Name, command.Abbreviation);
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

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
