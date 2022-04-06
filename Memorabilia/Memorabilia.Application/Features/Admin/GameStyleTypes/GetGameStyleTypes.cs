using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GameStyleTypes
{
    public class GetGameStyleTypes
    {
        public class Handler : QueryHandler<Query, GameStyleTypesViewModel>
        {
            private readonly IGameStyleTypeRepository _gameStyleTypeRepository;

            public Handler(IGameStyleTypeRepository gameStyleTypeRepository)
            {
                _gameStyleTypeRepository = gameStyleTypeRepository;
            }

            protected override async Task<GameStyleTypesViewModel> Handle(Query query)
            {
                return new GameStyleTypesViewModel(await _gameStyleTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<GameStyleTypesViewModel> { }
    }
}
