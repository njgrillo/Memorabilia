namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamsModel : Model
{
    public TeamsModel() { }

    public TeamsModel(IEnumerable<Entity.Team> teams)
    {
        Teams = teams.Select(team => new TeamModel(team))
                     .OrderBy(team => team.FranchiseName)
                     .ThenBy(team => team.BeginYear)
                     .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.Teams.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Teams.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Teams.Page;

    public List<TeamModel> Teams { get; set; } 
        = new();
}
