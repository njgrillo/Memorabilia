namespace Memorabilia.Application.Features.Admin.Sports
{
    public class GetSport
    {
        public class Handler : QueryHandler<Query, SportViewModel>
        {
            private readonly ISportRepository _sportRepository;

            public Handler(ISportRepository sportRepository)
            {
                _sportRepository = sportRepository;
            }

            protected override async Task<SportViewModel> Handle(Query query)
            {
                return new SportViewModel(await _sportRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SportViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
