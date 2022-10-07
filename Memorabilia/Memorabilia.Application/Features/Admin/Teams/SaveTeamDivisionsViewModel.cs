using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamDivisionsViewModel : SaveViewModel
{
    public SaveTeamDivisionsViewModel() { }

    public SaveTeamDivisionsViewModel(int teamId) 
    { 
        TeamId = teamId;
    }

    public SaveTeamDivisionsViewModel(int teamId, List<SaveTeamDivisionViewModel> divisions)
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

            if (SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball)
                return $"{AdminDomainItem.Teams.Title}/{EditModeType.Update.Name}/{TeamId}";

            return $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Conferences.Item}/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel.Id}";
        }
    }

    public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath
    {
        get
        {
            var nextStep = SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball 
                ? AdminDomainItem.Leagues.Item 
                : AdminDomainItem.Conferences.Item;

            return $"{AdminDomainItem.Teams.Item}/{nextStep}/{EditModeType.Update.Name}/{Id}/{SportLeagueLevel?.Id}";
        }
    }

    public List<SaveTeamDivisionViewModel> Divisions { get; set; } = new();

    public override EditModeType EditModeType => Divisions.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => AdminDomainItem.Teams.Page;

    public string ImagePath => AdminDomainItem.Divisions.ImagePath;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {AdminDomainItem.Divisions.Title}";

    public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public TeamStep TeamStep => TeamStep.Division;
}
