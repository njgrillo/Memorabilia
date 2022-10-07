using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class GetSportLeagueLevel
{
    public class Handler : QueryHandler<Query, SportLeagueLevelViewModel>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<SportLeagueLevelViewModel> Handle(Query query)
        {
            return new SportLeagueLevelViewModel(await _sportLeagueLevelRepository.Get(query.Id));
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
