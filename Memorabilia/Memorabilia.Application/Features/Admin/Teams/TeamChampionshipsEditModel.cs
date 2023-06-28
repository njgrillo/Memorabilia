namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamChampionshipsEditModel : EditModel
{
    public TeamChampionshipsEditModel() { }

    public TeamChampionshipsEditModel(int teamId)
    {
        TeamId = teamId;
    }

    public TeamChampionshipsEditModel(int teamId, List<TeamChampionshipEditModel> championships)
    {
        TeamId = teamId;
        Championships = championships;
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Leagues.Item}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public bool CanHaveConference 
        => SportLeagueLevel != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public List<TeamChampionshipEditModel> Championships { get; set; } 
        = new();

    public override string ContinueNavigationPath 
        => Constant.AdminDomainItem.Teams.Page;

    public override Constant.EditModeType EditModeType 
        => Championships.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public override string ExitNavigationPath
        => Constant.AdminDomainItem.Teams.Page;

    public string ImageFileName 
        => Constant.ImageFileName.ChampionshipTypes;

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} Championships";

    public Constant.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public Constant.TeamStep TeamStep 
        => Constant.TeamStep.Championship;
}
