namespace Memorabilia.Application.Features.Admin.Teams
{
    public class SaveTeamLeagueViewModel : SaveViewModel
    {
        public SaveTeamLeagueViewModel() { }

        public SaveTeamLeagueViewModel(TeamLeagueViewModel teamLeague)
        {
            Id = teamLeague.Id;
            LeagueId = teamLeague.LeagueId;
            TeamId = teamLeague.TeamId;
            BeginYear = teamLeague.BeginYear;
            EndYear = teamLeague.EndYear;
        }

        public int? BeginYear { get; set; }        

        public int? EndYear { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName => Domain.Constants.League.Find(LeagueId)?.Name;

        public int TeamId { get; set; }
    }
}
