using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GameStyleType
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
                var gameStyleTypes = await _gameStyleTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new GameStyleTypesViewModel(gameStyleTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<GameStyleTypesViewModel> { }
    }
}
