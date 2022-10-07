using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompanies;

public class SaveAuthenticationCompany
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<AuthenticationCompany> _authenticationCompanyRepository;

        public Handler(IDomainRepository<AuthenticationCompany> authenticationCompanyRepository)
        {
            _authenticationCompanyRepository = authenticationCompanyRepository;
        }

        protected override async Task Handle(Command command)
        {
            AuthenticationCompany authenticationCompany;

            if (command.IsNew)
            {
                authenticationCompany = new AuthenticationCompany(command.Name, command.Abbreviation);

                await _authenticationCompanyRepository.Add(authenticationCompany);

                return;
            }

            authenticationCompany = await _authenticationCompanyRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _authenticationCompanyRepository.Delete(authenticationCompany);

                return;
            }

            authenticationCompany.Set(command.Name, command.Abbreviation);

            await _authenticationCompanyRepository.Update(authenticationCompany);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
