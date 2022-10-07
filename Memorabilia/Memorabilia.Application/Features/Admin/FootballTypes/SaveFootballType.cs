using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public class SaveFootballType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            FootballType footballType;

            if (command.IsNew)
            {
                footballType = new FootballType(command.Name, command.Abbreviation);
                await _footballTypeRepository.Add(footballType);

                return;
            }

            footballType = await _footballTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _footballTypeRepository.Delete(footballType);

                return;
            }

            footballType.Set(command.Name, command.Abbreviation);

            await _footballTypeRepository.Update(footballType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
