namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamConferencesEditModel : EditModel
{
    public TeamConferencesEditModel() { }

    public TeamConferencesEditModel(int teamId) 
    {
        TeamId = teamId;
    }

    public TeamConferencesEditModel(int teamId, List<TeamConferenceEditModel> conferences)
    {
        TeamId = teamId;
        Conferences = conferences;
    }

    public override string BackNavigationPath
        => SportLeagueLevel == Constant.SportLeagueLevel.MajorLeagueBaseball
            ? $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Divisions.Item}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel.Id}"
            : $"{Constant.AdminDomainItem.Teams.Title}/{Constant.EditModeType.Update.Name}/{TeamId}";
    
    public bool CanHaveConference 
        => SportLeagueLevel != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public List<TeamConferenceEditModel> Conferences { get; set; } 
        = [];

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Leagues.Item}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public override Constant.EditModeType EditModeType 
        => Conferences.Count != 0
            ? Constant.EditModeType.Update 
            : Constant.EditModeType.Add;

    public override string ExitNavigationPath
        => Constant.AdminDomainItem.Teams.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Conferences.ImageFileName;

    public override string ItemTitle
        => Constant.AdminDomainItem.Conferences.Item;

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update 
            ? Constant.EditModeType.Update.Name 
            : Constant.EditModeType.Add.Name)} {Constant.AdminDomainItem.Conferences.Title}";

    public Constant.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public Constant.TeamStep TeamStep 
        => Constant.TeamStep.Conference;
}
