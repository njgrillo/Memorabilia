using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes
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
                GameStyleType gameStyleType;

                if (command.IsNew)
                {
                    gameStyleType = new GameStyleType(command.Name, command.Abbreviation);
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
