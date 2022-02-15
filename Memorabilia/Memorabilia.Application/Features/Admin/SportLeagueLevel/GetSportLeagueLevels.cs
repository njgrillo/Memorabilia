using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

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
                var sportLeagueLevels = await _sportLeagueLevelRepository.GetAll().ConfigureAwait(false);

                var viewModel = new SportLeagueLevelsViewModel(sportLeagueLevels);

                return viewModel;
            }
        }

        public class Query : IQuery<SportLeagueLevelsViewModel>
        {
            public Query() { }
        }
    }
}
