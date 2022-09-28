#nullable disable

namespace Memorabilia.Blazor.Controls.Team
{
    public partial class TeamLeagueEditor : ComponentBase
    {
        [Parameter]
        public List<SaveTeamLeagueViewModel> Leagues { get; set; } = new();

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        private SaveTeamLeagueViewModel _viewModel = new();

        private void Add()
        {
            Leagues.Add(_viewModel);

            _viewModel = new SaveTeamLeagueViewModel();
        }

        private void Remove(int leagueId, int? beginYear)
        {
            var league = Leagues.SingleOrDefault(league => league.LeagueId == leagueId && league.BeginYear == beginYear);

            if (league == null)
                return;

            league.IsDeleted = true;
        }
    }
}
