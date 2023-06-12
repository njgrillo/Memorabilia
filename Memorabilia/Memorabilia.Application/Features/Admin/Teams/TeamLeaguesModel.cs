namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamLeaguesModel : EditModel
{
    public TeamLeaguesModel() { }

    public TeamLeaguesModel(int teamId)
    {
        TeamId = teamId;
    }

    public TeamLeaguesModel(int teamId, List<TeamLeagueEditModel> leagues)
    {
        TeamId = teamId;
        Leagues = leagues;
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Divisions.Item}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public bool CanHaveConference 
        => SportLeagueLevel != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.Teams.Item}/Championship/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public override Constant.EditModeType EditModeType 
        => Leagues.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public string ImageFileName 
        => Constant.AdminDomainItem.Leagues.ImageFileName;

    public List<TeamLeagueEditModel> Leagues { get; set; } 
        = new();

    public Constant.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public Constant.TeamStep TeamStep 
        => Constant.TeamStep.League;
}
