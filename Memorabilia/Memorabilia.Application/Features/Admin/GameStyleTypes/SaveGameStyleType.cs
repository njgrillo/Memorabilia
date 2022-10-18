using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record SaveGameStyleType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveGameStyleType>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task Handle(SaveGameStyleType request)
        {
            GameStyleType gameStyleType;

            if (request.ViewModel.IsNew)
            {
                gameStyleType = new GameStyleType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _gameStyleTypeRepository.Add(gameStyleType);

                return;
            }

            gameStyleType = await _gameStyleTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _gameStyleTypeRepository.Delete(gameStyleType);

                return;
            }

            gameStyleType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _gameStyleTypeRepository.Update(gameStyleType);
        }
    }
}
