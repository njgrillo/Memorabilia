using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.InscriptionType
{
    public class SaveInscriptionType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IInscriptionTypeRepository _inscriptionTypeRepository;

            public Handler(IInscriptionTypeRepository inscriptionTypeRepository)
            {
                _inscriptionTypeRepository = inscriptionTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.InscriptionType inscriptionType;

                if (command.IsNew)
                {
                    inscriptionType = new Domain.Entities.InscriptionType(command.Name, command.Abbreviation);
                    await _inscriptionTypeRepository.Add(inscriptionType).ConfigureAwait(false);

                    return;
                }

                inscriptionType = await _inscriptionTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _inscriptionTypeRepository.Delete(inscriptionType).ConfigureAwait(false);

                    return;
                }

                inscriptionType.Set(command.Name, command.Abbreviation);

                await _inscriptionTypeRepository.Update(inscriptionType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
