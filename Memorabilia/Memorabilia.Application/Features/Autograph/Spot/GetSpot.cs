namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class GetSpot
    {
        public class Handler : QueryHandler<Query, SpotViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<SpotViewModel> Handle(Query query)
            {
                return new SpotViewModel(await _autographRepository.Get(query.AutographId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SpotViewModel>
        {
            public Query(int autographId)
            {
                AutographId = autographId;
            }

            public int AutographId { get; }
        }
    }
}
