namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamDivisionsEditModel : EditModel
{
    public TeamDivisionsEditModel() { }

    public TeamDivisionsEditModel(int teamId) 
    { 
        TeamId = teamId;
    }

    public TeamDivisionsEditModel(int teamId, List<TeamDivisionEditModel> divisions)
    {
        TeamId = teamId;
        Divisions = divisions;
    }

    public override string BackNavigationPath
    {
        get
        {
            if (SportLeagueLevel == null)
                return string.Empty;

            if (SportLeagueLevel == Constant.SportLeagueLevel.MajorLeagueBaseball)
                return $"{Constant.AdminDomainItem.Teams.Title}/{Constant.EditModeType.Update.Name}/{TeamId}";

            return $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Conferences.Item}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel.Id}";
        }
    }

    public bool CanHaveConference 
        => SportLeagueLevel != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath
    {
        get
        {
            var nextStep = SportLeagueLevel == Constant.SportLeagueLevel.MajorLeagueBaseball 
                ? Constant.AdminDomainItem.Leagues.Item 
                : Constant.AdminDomainItem.Conferences.Item;

            return $"{Constant.AdminDomainItem.Teams.Item}/{nextStep}/{Constant.EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";
        }
    }

    public List<TeamDivisionEditModel> Divisions { get; set; } 
        = new();

    public override Constant.EditModeType EditModeType 
        => Divisions.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Teams.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Divisions.ImageFileName;

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} {Constant.AdminDomainItem.Divisions.Title}";

    public Constant.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public Constant.TeamStep TeamStep 
        => Constant.TeamStep.Division;
}
