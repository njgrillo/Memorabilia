using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Spot
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
                var spots = await _spotRepository.GetAll().ConfigureAwait(false);

                var viewModel = new SpotsViewModel(spots);

                return viewModel;
            }
        }

        public class Query : IQuery<SpotsViewModel>
        {
        }
    }
}
