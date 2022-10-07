using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public class SaveGameStyleType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            GameStyleType gameStyleType;

            if (command.IsNew)
            {
                gameStyleType = new GameStyleType(command.Name, command.Abbreviation);
                await _gameStyleTypeRepository.Add(gameStyleType);

                return;
            }

            gameStyleType = await _gameStyleTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _gameStyleTypeRepository.Delete(gameStyleType);

                return;
            }

            gameStyleType.Set(command.Name, command.Abbreviation);

            await _gameStyleTypeRepository.Update(gameStyleType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
