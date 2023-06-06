using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamsViewModel : Model
{
    public TeamsViewModel() { }

    public TeamsViewModel(IEnumerable<Team> teams)
    {
        Teams = teams.Select(team => new TeamViewModel(team))
                     .OrderBy(team => team.FranchiseName)
                     .ThenBy(team => team.BeginYear)
                     .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.Teams.Item;

    public override string PageTitle => AdminDomainItem.Teams.Title;

    public override string RoutePrefix => AdminDomainItem.Teams.Page;

    public List<TeamViewModel> Teams { get; set; } = new();
}
