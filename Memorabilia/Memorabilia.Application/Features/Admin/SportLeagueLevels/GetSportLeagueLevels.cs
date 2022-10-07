using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class GetSportLeagueLevels
{
    public class Handler : QueryHandler<Query, SportLeagueLevelsViewModel>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<SportLeagueLevelsViewModel> Handle(Query query)
        {
            return new SportLeagueLevelsViewModel(await _sportLeagueLevelRepository.GetAll());
        }
    }

    public class Query : IQuery<SportLeagueLevelsViewModel>
    {
        public Query() { }
    }
}
