using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Spot
{
    public class GetSpot
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly ISpotRepository _spotRepository;

            public Handler(ISpotRepository spotRepository)
            {
                _spotRepository = spotRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var spot = await _spotRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(spot);

                return viewModel;
            }
        }
    }
}
