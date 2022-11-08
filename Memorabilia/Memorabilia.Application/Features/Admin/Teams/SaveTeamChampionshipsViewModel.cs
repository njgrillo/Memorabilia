using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamChampionshipsViewModel : SaveViewModel
{
    public SaveTeamChampionshipsViewModel() { }

    public SaveTeamChampionshipsViewModel(int teamId)
    {
        TeamId = teamId;
    }

    public SaveTeamChampionshipsViewModel(int teamId, List<SaveTeamChampionshipViewModel> championships)
    {
        TeamId = teamId;
        Championships = championships;
    }

    public override string BackNavigationPath => $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Leagues.Item}/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public bool CanHaveConference => SportLeagueLevel != SportLeagueLevel.MajorLeagueBaseball;

    public List<SaveTeamChampionshipViewModel> Championships { get; set; } = new();

    public override string ContinueNavigationPath => AdminDomainItem.Teams.Page;

    public override EditModeType EditModeType => Championships.Any() ? EditModeType.Update : EditModeType.Add;

    public string ImageFileName => Domain.Constants.ImageFileName.ChampionshipTypes;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Championships";

    public SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public TeamStep TeamStep => TeamStep.Championship;
}
