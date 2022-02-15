using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Team
{
    public class TeamsViewModel : ViewModel
    {
        public TeamsViewModel() { }

        public TeamsViewModel(IEnumerable<Domain.Entities.Team> teams)
        {
            Teams = teams.Select(team => new TeamViewModel(team))
                         .OrderBy(team => team.FranchiseName)
                         .ThenBy(team => team.BeginYear)
                         .ToList();
        }

        public override string ItemTitle => "Team";

        public override string PageTitle => "Teams";

        public override string RoutePrefix => "Teams";

        public List<TeamViewModel> Teams { get; set; } = new();
    }
}
