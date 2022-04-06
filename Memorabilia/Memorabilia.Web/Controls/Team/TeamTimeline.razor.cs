using Framework.Extension;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Team
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
        public MudBlazor.Severity TeamConferenceEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string TeamConferenceEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color TeamConferenceEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity TeamDivisionEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string TeamDivisionEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color TeamDivisionEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity TeamEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string TeamEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color TeamEditColor { get; set; } = MudBlazor.Color.Info;      
        
        [Parameter]
        public int TeamId { get; set; }

        [Parameter]
        public MudBlazor.Severity TeamLeagueEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string TeamLeagueEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color TeamLeagueEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public TeamStep TeamStep { get; set; }

        private string _mudAlertClass;

        protected override void OnInitialized()
        {
            _mudAlertClass = TeamId > 0 ? "can-click" : string.Empty;

            TeamConferenceEditAlertTitle = TeamStep.Conference.Name;
            TeamDivisionEditAlertTitle = TeamStep.Division.Name;
            TeamEditAlertTitle = TeamStep.Team.Name;      
            TeamLeagueEditAlertTitle = TeamStep.League.Name;

            if (TeamStep == TeamStep.Division)
            {
                TeamEditAlertSeverity = MudBlazor.Severity.Success;
                TeamEditColor = MudBlazor.Color.Success;
                return;
            }

            if (TeamStep == TeamStep.Conference)
            {
                TeamDivisionEditAlertSeverity = MudBlazor.Severity.Success;
                TeamDivisionEditColor = MudBlazor.Color.Success;
                TeamEditAlertSeverity = MudBlazor.Severity.Success;
                TeamEditColor = MudBlazor.Color.Success;                
                return;
            }

            if (TeamStep == TeamStep.League)
            {
                TeamDivisionEditAlertSeverity = MudBlazor.Severity.Success;
                TeamDivisionEditColor = MudBlazor.Color.Success;
                TeamConferenceEditAlertSeverity = MudBlazor.Severity.Success;
                TeamConferenceEditColor = MudBlazor.Color.Success;
                TeamEditAlertSeverity = MudBlazor.Severity.Success;
                TeamEditColor = MudBlazor.Color.Success;
                return;
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
