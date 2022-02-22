namespace Memorabilia.Application.Features.Admin.Team
{
    public class TeamLeagueViewModel
    {
        private readonly Domain.Entities.TeamLeague _teamLeague;

        public TeamLeagueViewModel() { }

        public TeamLeagueViewModel(Domain.Entities.TeamLeague teamLeague)
        {
            _teamLeague = teamLeague;
        }

        public int? BeginYear => _teamLeague.BeginYear;

        public int LeagueId => _teamLeague.LeagueId;

        public int? EndYear => _teamLeague.EndYear;

        public int Id => _teamLeague.Id;

        public int TeamId => _teamLeague.TeamId;
    }
}
