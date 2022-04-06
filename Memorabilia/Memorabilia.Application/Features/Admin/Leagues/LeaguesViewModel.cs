using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Leagues
{
    public class LeaguesViewModel : ViewModel
    {
        public LeaguesViewModel() { }

        public LeaguesViewModel(IEnumerable<League> leagues)
        {
            Leagues = leagues.Select(league => new LeagueViewModel(league))
                             .OrderBy(league => league.Name)
                             .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "League";

        public List<LeagueViewModel> Leagues { get; set; } = new();

        public override string PageTitle => "Leagues";

        public override string RoutePrefix => "Leagues";
    }
}
