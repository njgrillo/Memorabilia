using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class TeamsViewModel : ViewModel
    {
        public TeamsViewModel() { }

        public TeamsViewModel(IEnumerable<Team> teams)
        {
            Teams = teams.Select(team => new TeamViewModel(team))
                         .OrderBy(team => team.FranchiseName)
                         .ThenBy(team => team.BeginYear)
                         .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Team";

        public override string PageTitle => "Teams";

        public override string RoutePrefix => "Teams";

        public List<TeamViewModel> Teams { get; set; } = new();
    }
}
