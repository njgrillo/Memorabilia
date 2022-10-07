using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamConferencesViewModel : SaveViewModel
{
    public SaveTeamConferencesViewModel() { }

    public SaveTeamConferencesViewModel(int teamId) 
    {
        TeamId = teamId;
    }

    public SaveTeamConferencesViewModel(int teamId, List<SaveTeamConferenceViewModel> conferences)
    {
        TeamId = teamId;
        Conferences = conferences;
    }

    public override string BackNavigationPath
    {
        get
        {
            if (SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball)
                return $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Divisions.Item}/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel.Id}";

            return $"{AdminDomainItem.Teams.Title}/{EditModeType.Update.Name}/{TeamId}";
        }
    }

    public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

    public List<SaveTeamConferenceViewModel> Conferences { get; set; } = new();

    public override string ContinueNavigationPath => $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Divisions.Item}/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public override EditModeType EditModeType => Conferences.Any() ? EditModeType.Update : EditModeType.Add;

    public string ImagePath => AdminDomainItem.Conferences.ImagePath;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {AdminDomainItem.Conferences.Title}";

    public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public TeamStep TeamStep => TeamStep.Conference;
}
