using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public class GetGameStyleTypes
{
    public class Handler : QueryHandler<Query, GameStyleTypesViewModel>
    {
        private readonly IDomainRepository<GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<GameStyleTypesViewModel> Handle(Query query)
        {
            return new GameStyleTypesViewModel(await _gameStyleTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<GameStyleTypesViewModel> { }
}
