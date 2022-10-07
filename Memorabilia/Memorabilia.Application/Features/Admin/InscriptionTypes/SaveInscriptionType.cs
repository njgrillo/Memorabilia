using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public class SaveInscriptionType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            InscriptionType inscriptionType;

            if (command.IsNew)
            {
                inscriptionType = new InscriptionType(command.Name, command.Abbreviation);

                await _inscriptionTypeRepository.Add(inscriptionType);

                return;
            }

            inscriptionType = await _inscriptionTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _inscriptionTypeRepository.Delete(inscriptionType);

                return;
            }

            inscriptionType.Set(command.Name, command.Abbreviation);

            await _inscriptionTypeRepository.Update(inscriptionType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
