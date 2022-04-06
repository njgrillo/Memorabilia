using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class TeamLeagueViewModel
    {
        private readonly TeamLeague _teamLeague;

        public TeamLeagueViewModel() { }

        public TeamLeagueViewModel(TeamLeague teamLeague)
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
