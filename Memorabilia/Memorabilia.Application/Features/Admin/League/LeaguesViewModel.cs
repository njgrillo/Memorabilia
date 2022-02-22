using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.League
{
    public class LeaguesViewModel : ViewModel
    {
        public LeaguesViewModel() { }

        public LeaguesViewModel(IEnumerable<Domain.Entities.League> leagues)
        {
            Leagues = leagues.Select(league => new LeagueViewModel(league))
                             .OrderBy(league => league.Name)
                             .ToList();
        }        

        public override string ItemTitle => "League";

        public List<LeagueViewModel> Leagues { get; set; } = new();

        public override string PageTitle => "Leagues";

        public override string RoutePrefix => "Leagues";
    }
}
