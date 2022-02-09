using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AuthenticType
{
    public class SaveAuthenticType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAuthenticTypeRepository _authenticTypeRepository;

            public Handler(IAuthenticTypeRepository authenticTypeRepository)
            {
                _authenticTypeRepository = authenticTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.AuthenticType authenticType;

                if (command.IsNew)
                {
                    authenticType = new Domain.Entities.AuthenticType(command.Name, command.Abbreviation);
                    await _authenticTypeRepository.Add(authenticType).ConfigureAwait(false);

                    return;
                }

                authenticType = await _authenticTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _authenticTypeRepository.Delete(authenticType).ConfigureAwait(false);

                    return;
                }

                authenticType.Set(command.Name, command.Abbreviation);

                await _authenticTypeRepository.Update(authenticType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel)
            {
            }
        }
    }
}
