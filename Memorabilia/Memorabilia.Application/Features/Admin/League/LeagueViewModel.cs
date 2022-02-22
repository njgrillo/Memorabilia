namespace Memorabilia.Application.Features.Admin.League
{
    public class LeagueViewModel
    {
        private readonly Domain.Entities.League _league;

        public LeagueViewModel() { }

        public LeagueViewModel(Domain.Entities.League league)
        {
            _league = league;
        }

        public string Abbreviation => _league.Abbreviation;

        public int Id => _league.Id;

        public string Name => _league.Name;

        public int SportLeagueLevelId => _league.SportLeagueLevelId;

        public string SportLeagueLevelName => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;
    }
}
