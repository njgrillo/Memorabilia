#nullable disable

namespace Memorabilia.Blazor.Controls.Team
{
    public partial class TeamTimeline : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public bool DisplayConference { get; set; } = true;

        [Parameter]
        public EditModeType EditMode { get; set; } = EditModeType.Add;

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        [Parameter]
        public Severity TeamChampionshipEditAlertSeverity { get; set; } = Severity.Info;

        [Parameter]
        public string TeamChampionshipEditAlertTitle { get; set; }

        [Parameter]
        public Color TeamChampionshipEditColor { get; set; } = Color.Info;

        [Parameter]
        public Severity TeamConferenceEditAlertSeverity { get; set; } = Severity.Info;

        [Parameter]
        public string TeamConferenceEditAlertTitle { get; set; }

        [Parameter]
        public Color TeamConferenceEditColor { get; set; } = Color.Info;

        [Parameter]
        public Severity TeamDivisionEditAlertSeverity { get; set; } = Severity.Info;

        [Parameter]
        public string TeamDivisionEditAlertTitle { get; set; }

        [Parameter]
        public Color TeamDivisionEditColor { get; set; } = Color.Info;

        [Parameter]
        public Severity TeamEditAlertSeverity { get; set; } = Severity.Info;

        [Parameter]
        public string TeamEditAlertTitle { get; set; }

        [Parameter]
        public Color TeamEditColor { get; set; } = Color.Info;

        [Parameter]
        public int TeamId { get; set; }

        [Parameter]
        public Severity TeamLeagueEditAlertSeverity { get; set; } = Severity.Info;

        [Parameter]
        public string TeamLeagueEditAlertTitle { get; set; }

        [Parameter]
        public Color TeamLeagueEditColor { get; set; } = Color.Info;

        [Parameter]
        public TeamStep TeamStep { get; set; }

        private string _mudAlertClass;

        protected override void OnInitialized()
        {
            _mudAlertClass = TeamId > 0 ? "can-click" : string.Empty;

            TeamConferenceEditAlertTitle = TeamStep.Conference.Name;
            TeamChampionshipEditAlertTitle = TeamStep.Championship.Name;
            TeamDivisionEditAlertTitle = TeamStep.Division.Name;
            TeamEditAlertTitle = TeamStep.Team.Name;
            TeamLeagueEditAlertTitle = TeamStep.League.Name;

            if (TeamStep == TeamStep.Division)
            {
                TeamEditAlertSeverity = Severity.Success;
                TeamEditColor = Color.Success;
                return;
            }

            if (TeamStep == TeamStep.Conference)
            {
                TeamDivisionEditAlertSeverity = Severity.Success;
                TeamDivisionEditColor = Color.Success;
                TeamEditAlertSeverity = Severity.Success;
                TeamEditColor = Color.Success;
                return;
            }

            if (TeamStep == TeamStep.League)
            {
                TeamDivisionEditAlertSeverity = Severity.Success;
                TeamDivisionEditColor = Color.Success;
                TeamConferenceEditAlertSeverity = Severity.Success;
                TeamConferenceEditColor = Color.Success;
                TeamEditAlertSeverity = Severity.Success;
                TeamEditColor = Color.Success;
                return;
            }

            if (TeamStep == TeamStep.Championship)
            {
                TeamDivisionEditAlertSeverity = Severity.Success;
                TeamDivisionEditColor = Color.Success;
                TeamConferenceEditAlertSeverity = Severity.Success;
                TeamConferenceEditColor = Color.Success;
                TeamLeagueEditAlertSeverity = Severity.Success;
                TeamLeagueEditColor = Color.Success;
                TeamEditAlertSeverity = Severity.Success;
                TeamEditColor = Color.Success;
            }
        }

        private string GetMudAlertStyle(TeamStep teamStep)
        {
            return TeamStep == teamStep ? "border: 1px solid black;" : string.Empty;
        }

        private void Navigate(string item = null)
        {
            if (TeamId == 0)
                return;

            if (item.IsNullOrEmpty())
            {
                NavigationManager.NavigateTo($"Teams/Edit/{TeamId}");
                return;
            }

            NavigationManager.NavigateTo($"Team/{item}/Edit/{TeamId}/{SportLeagueLevel.Id}");
        }
    }
}
