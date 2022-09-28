namespace Memorabilia.Application.Features.Admin.Pewters
{
    public class GetPewter
    {
        public class Handler : QueryHandler<Query, PewterViewModel>
        {
            private readonly IPewterRepository _pewterRepository;

            public Handler(IPewterRepository pewterRepository)
            {
                _pewterRepository = pewterRepository;
            }

            protected override async Task<PewterViewModel> Handle(Query query)
            {
                return new PewterViewModel(await _pewterRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PewterViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
