namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamEditModel : EditModel, IWithName, IWithValue<int>
{
    public TeamEditModel() { }

    public TeamEditModel(TeamModel model)
    {
        Abbreviation = model.Abbreviation;
        BeginYear = model.BeginYear;
        DisplayName = model.DisplayName;
        EndYear = model.EndYear;
        Franchise = Constant.Franchise.Find(model.FranchiseId);
        Id = model.Id;
        Location = model.Location;
        Name = model.Name;
        Nickname = model.Nickname;
        SportLeagueLevelId = model.SportLeagueLevel.Id;
    }

    public string Abbreviation { get; set; }

    public int? BeginYear { get; set; }

    public bool CanHaveConference 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId) != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.Teams.Item}/{Constant.AdminDomainItem.Divisions.Item}/{Constant.EditModeType.Update.Name}/{Id}/{SportLeagueLevelId}";

    public bool DisplayFranchise 
        => Id == 0;

    public string DisplayName { get; set; }

    public int? EndYear { get; set; }

    public override string ExitNavigationPath
        => Constant.AdminDomainItem.Teams.Page;

    public Constant.Franchise Franchise { get; set; }

    public string ImageFileName 
        => Constant.AdminDomainItem.Teams.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Teams.Item;

    public string Location { get; set; }

    public override string Name { get; set; }

    public string Nickname { get; set; }

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId);

    public int SportLeagueLevelId { get; set; }

    public Constant.Sport[] Sports 
        => SportLeagueLevel != null 
        ? new[] { SportLeagueLevel.Sport }
        : Array.Empty<Constant.Sport>();

    public Constant.TeamStep TeamStep 
        => Constant.TeamStep.Team;

    string IWithName.Name 
        => DisplayName;

    int IWithValue<int>.Value 
        => Id;
}
