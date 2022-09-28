using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams
{
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
                    return $"Teams/Edit/{TeamId}";

                return $"Team/Conference/Edit/{TeamId}/{SportLeagueLevel.Id}";
            }
        }

        public bool CanHaveConference => SportLeagueLevel != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

        public override string ContinueNavigationPath
        {
            get
            {
                var nextStep = SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball ? "League" : "Conference";

                return $"Team/{nextStep}/Edit/{Id}/{SportLeagueLevel?.Id}";
            }
        }

        public List<SaveTeamDivisionViewModel> Divisions { get; set; } = new();

        public override EditModeType EditModeType => Divisions.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Teams";

        public string ImagePath => "images/divisions.png";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Divisions";

        public Domain.Constants.SportLeagueLevel SportLeagueLevel { get; set; }

        public int TeamId { get; set; }

        public TeamStep TeamStep => TeamStep.Division;
    }
}
