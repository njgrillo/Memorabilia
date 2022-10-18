using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record GetSportLeagueLevel(int Id) : IQuery<SportLeagueLevelViewModel>
{
    public class Handler : QueryHandler<GetSportLeagueLevel, SportLeagueLevelViewModel>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<SportLeagueLevelViewModel> Handle(GetSportLeagueLevel query)
        {
            return new SportLeagueLevelViewModel(await _sportLeagueLevelRepository.Get(query.Id));
        }
    }
}
