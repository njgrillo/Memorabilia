using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleTypes() : IQuery<GameStyleTypesViewModel>
{
    public class Handler : QueryHandler<GetGameStyleTypes, GameStyleTypesViewModel>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<GameStyleTypesViewModel> Handle(GetGameStyleTypes query)
        {
            return new GameStyleTypesViewModel(await _gameStyleTypeRepository.GetAll());
        }
    }
}
