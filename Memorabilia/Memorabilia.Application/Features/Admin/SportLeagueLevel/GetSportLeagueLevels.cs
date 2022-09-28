namespace Memorabilia.Application.Features.Admin.SportLeagueLevel
{
    public class GetSportLeagueLevels
    {
        public class Handler : QueryHandler<Query, SportLeagueLevelsViewModel>
        {
            private readonly ISportLeagueLevelRepository _sportLeagueLevelRepository;

            public Handler(ISportLeagueLevelRepository sportLeagueLevelRepository)
            {
                _sportLeagueLevelRepository = sportLeagueLevelRepository;
            }

            protected override async Task<SportLeagueLevelsViewModel> Handle(Query query)
            {
                return new SportLeagueLevelsViewModel(await _sportLeagueLevelRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SportLeagueLevelsViewModel>
        {
            public Query() { }
        }
    }
}
