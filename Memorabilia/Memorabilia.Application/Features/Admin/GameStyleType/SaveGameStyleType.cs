using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GameStyleType
{
    public class SaveGameStyleType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IGameStyleTypeRepository _gameStyleTypeRepository;

            public Handler(IGameStyleTypeRepository gameStyleTypeRepository)
            {
                _gameStyleTypeRepository = gameStyleTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.GameStyleType gameStyleType;

                if (command.IsNew)
                {
                    gameStyleType = new Domain.Entities.GameStyleType(command.Name, command.Abbreviation);
                    await _gameStyleTypeRepository.Add(gameStyleType).ConfigureAwait(false);

                    return;
                }

                gameStyleType = await _gameStyleTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _gameStyleTypeRepository.Delete(gameStyleType).ConfigureAwait(false);

                    return;
                }

                gameStyleType.Set(command.Name, command.Abbreviation);

                await _gameStyleTypeRepository.Update(gameStyleType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
