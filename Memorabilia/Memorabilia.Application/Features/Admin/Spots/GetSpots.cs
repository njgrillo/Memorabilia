using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Spots
{
    public class GetSpots
    {
        public class Handler : QueryHandler<Query, SpotsViewModel>
        {
            private readonly ISpotRepository _spotRepository;

            public Handler(ISpotRepository spotRepository)
            {
                _spotRepository = spotRepository;
            }

            protected override async Task<SpotsViewModel> Handle(Query query)
            {
                return new SpotsViewModel(await _spotRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SpotsViewModel> { }
    }
}
