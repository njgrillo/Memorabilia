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
                         .ThenBy(team => team.BeginYear);
        }

        public override string PageTitle => "Teams";

        public IEnumerable<TeamViewModel> Teams { get; set; } = Enumerable.Empty<TeamViewModel>();
    }
}
