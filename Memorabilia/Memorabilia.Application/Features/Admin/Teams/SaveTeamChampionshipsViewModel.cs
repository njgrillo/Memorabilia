using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Teams
{
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

        public override string BackNavigationPath => $"Team/Leage/Edit/{TeamId}/{SportLeagueLevel?.Id}";

        public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

        public List<SaveTeamChampionshipViewModel> Championships { get; set; } = new();

        public override string ContinueNavigationPath => "Teams";

        public override EditModeType EditModeType => Championships.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        public string ImagePath => "images/championtypes.jpg";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Championships";

        public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

        public int TeamId { get; set; }

        public TeamStep TeamStep => TeamStep.Championship;
    }
}
