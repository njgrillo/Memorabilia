using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Teams
{
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
                    return $"Team/Division/Edit/{TeamId}/{SportLeagueLevel.Id}";

                return $"Teams/Edit/{TeamId}";
            }
        }

        public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

        public List<SaveTeamConferenceViewModel> Conferences { get; set; } = new();

        public override string ContinueNavigationPath => $"Team/Division/Edit/{TeamId}/{SportLeagueLevel?.Id}";

        public override EditModeType EditModeType => Conferences.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        public string ImagePath => "images/conferences.jpg";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Conferences";

        public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

        public int TeamId { get; set; }

        public TeamStep TeamStep => TeamStep.Conference;
    }
}
