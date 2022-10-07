using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BammerTypes;

public class SaveBammerType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            BammerType bammerType;

            if (command.IsNew)
            {
                bammerType = new BammerType(command.Name, command.Abbreviation);

                await _bammerTypeRepository.Add(bammerType);

                return;
            }

            bammerType = await _bammerTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _bammerTypeRepository.Delete(bammerType);

                return;
            }

            bammerType.Set(command.Name, command.Abbreviation);

            await _bammerTypeRepository.Update(bammerType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
