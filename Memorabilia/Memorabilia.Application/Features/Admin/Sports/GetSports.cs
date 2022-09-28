namespace Memorabilia.Application.Features.Admin.Sports
{
    public class GetSports
    {
        public class Handler : QueryHandler<Query, SportsViewModel>
        {
            private readonly ISportRepository _sportRepository;

            public Handler(ISportRepository sportRepository)
            {
                _sportRepository = sportRepository;
            }

            protected override async Task<SportsViewModel> Handle(Query query)
            {
                return new SportsViewModel(await _sportRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SportsViewModel> { }
    }
}
