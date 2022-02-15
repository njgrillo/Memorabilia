using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevel
{
    public class GetSportLeagueLevel
    {
        public class Handler : QueryHandler<Query, SportLeagueLevelViewModel>
        {
            private readonly ISportLeagueLevelRepository _sportLeagueLevelRepository;

            public Handler(ISportLeagueLevelRepository sportLeagueLevelRepository)
            {
                _sportLeagueLevelRepository = sportLeagueLevelRepository;
            }

            protected override async Task<SportLeagueLevelViewModel> Handle(Query query)
            {
                var sportLeagueLevel = await _sportLeagueLevelRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new SportLeagueLevelViewModel(sportLeagueLevel);

                return viewModel;
            }
        }

        public class Query : IQuery<SportLeagueLevelViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
