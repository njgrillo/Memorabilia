using Framework.Extension;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonTimeline : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }    

        [Parameter]
        public EditModeType EditMode { get; set; } = EditModeType.Add;

        [Parameter]
        public MudBlazor.Severity PersonEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string PersonEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color PersonEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public int PersonId { get; set; }

        [Parameter]
        public MudBlazor.Severity PersonOccupationEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string PersonOccupationEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color PersonOccupationEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity PersonHallOfFameEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string PersonHallOfFameEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color PersonHallOfFameEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity PersonTeamEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string PersonTeamEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color PersonTeamEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public PersonStep PersonStep { get; set; }

        private string _mudAlertClass;

        protected override void OnInitialized()
        {
            _mudAlertClass = PersonId > 0 ? "can-click" : string.Empty;

            PersonEditAlertTitle = PersonStep.Person.Name;
            PersonHallOfFameEditAlertTitle = PersonStep.HallOfFame.Name;
            PersonOccupationEditAlertTitle = PersonStep.Occupation.Name;            
            PersonTeamEditAlertTitle = PersonStep.Team.Name;

            if (PersonStep == PersonStep.Occupation)
            {
                PersonEditAlertSeverity = MudBlazor.Severity.Success;
                PersonEditColor = MudBlazor.Color.Success;
                return;
            }

            if (PersonStep == PersonStep.Team)
            {
                PersonEditAlertSeverity = MudBlazor.Severity.Success;
                PersonEditColor = MudBlazor.Color.Success;
                PersonOccupationEditAlertSeverity = MudBlazor.Severity.Success;
                PersonOccupationEditColor = MudBlazor.Color.Success;
                return;
            }

            if (PersonStep == PersonStep.HallOfFame)
            {
                PersonEditAlertSeverity = MudBlazor.Severity.Success;
                PersonEditColor = MudBlazor.Color.Success;
                PersonOccupationEditAlertSeverity = MudBlazor.Severity.Success;
                PersonOccupationEditColor = MudBlazor.Color.Success;
                PersonTeamEditAlertSeverity = MudBlazor.Severity.Success;
                PersonTeamEditColor = MudBlazor.Color.Success;
                return;
            }
        }

        private string GetMudAlertStyle(PersonStep personStep)
        {
            return PersonStep == personStep ? "border: 1px solid black;" : string.Empty;
        }

        private void Navigate(string item = null)
        {
            if (PersonId == 0)
                return;

            if (item.IsNullOrEmpty())
            {
                NavigationManager.NavigateTo($"People/Edit/{PersonId}");
                return;
            }

            NavigationManager.NavigateTo($"People/{item}/Edit/{PersonId}");
        }
    }
}
