using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GameStyleType
{
    public class GetGameStyleType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IGameStyleTypeRepository _gameStyleTypeRepository;

            public Handler(IGameStyleTypeRepository gameStyleTypeRepository)
            {
                _gameStyleTypeRepository = gameStyleTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var gameStyleType = await _gameStyleTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(gameStyleType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
