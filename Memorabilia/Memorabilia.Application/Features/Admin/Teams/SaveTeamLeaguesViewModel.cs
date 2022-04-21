using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class SaveTeamLeaguesViewModel : SaveViewModel
    {
        public SaveTeamLeaguesViewModel() { }

        public SaveTeamLeaguesViewModel(int teamId)
        {
            TeamId = teamId;
        }

        public SaveTeamLeaguesViewModel(int teamId, List<SaveTeamLeagueViewModel> leagues)
        {
            TeamId = teamId;
            Leagues = leagues;
        }

        public override string BackNavigationPath => $"Team/Division/Edit/{TeamId}/{SportLeagueLevel?.Id}";

        public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

        public override string ContinueNavigationPath => $"Team/Championship/Edit/{TeamId}/{SportLeagueLevel?.Id}";

        public override EditModeType EditModeType => Leagues.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        public string ImagePath => "images/leagues.jpg";

        public List<SaveTeamLeagueViewModel> Leagues { get; set; } = new();

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Leagues";

        public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

        public int TeamId { get; set; }

        public TeamStep TeamStep => TeamStep.League;
    }
}
