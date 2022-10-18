using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public record GetSportLeagueLevels() : IQuery<SportLeagueLevelsViewModel>
{
    public class Handler : QueryHandler<GetSportLeagueLevels, SportLeagueLevelsViewModel>
    {
        private readonly IDomainRepository<SportLeagueLevel> _sportLeagueLevelRepository;

        public Handler(IDomainRepository<SportLeagueLevel> sportLeagueLevelRepository)
        {
            _sportLeagueLevelRepository = sportLeagueLevelRepository;
        }

        protected override async Task<SportLeagueLevelsViewModel> Handle(GetSportLeagueLevels query)
        {
            var sportLeagueLevels = (await _sportLeagueLevelRepository.GetAll())
                                        .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                        .ThenBy(sportLeagueLevel => sportLeagueLevel.Name);

            return new SportLeagueLevelsViewModel(sportLeagueLevels);
        }
    }
}
