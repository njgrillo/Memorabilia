using Framework.Extension;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Autographs
{
    public partial class AutographTimeline : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int AutographId { get; set; }

        [Parameter]
        public EditModeType EditMode { get; set; } = EditModeType.Add;

        [Parameter]
        public MudBlazor.Severity AutographAuthenticationEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string AutographAuthenticationEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color AutographAuthenticationEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity AutographEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string AutographEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color AutographEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity AutographImageEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string AutographImageEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color AutographImageEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity AutographInscriptionEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string AutographInscriptionEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color AutographInscriptionEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity AutographSpotEditAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string AutographSpotEditAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color AutographSpotEditColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public AutographStep AutographStep { get; set; }

        [Parameter]
        public bool DisplaySpot { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private string _mudAlertClass;

        protected override void OnInitialized()
        {
            _mudAlertClass = AutographId > 0 ? "can-click" : string.Empty;

            AutographAuthenticationEditAlertTitle = AutographStep.Authentication.Name;
            AutographEditAlertTitle = AutographStep.Autograph.Name;
            AutographImageEditAlertTitle = AutographStep.Image.Name;
            AutographInscriptionEditAlertTitle = AutographStep.Inscription.Name;

            if (DisplaySpot)
                AutographSpotEditAlertTitle = AutographStep.Spot.Name;

            if (AutographStep == AutographStep.Inscription)
            {
                AutographEditAlertSeverity = MudBlazor.Severity.Success;
                AutographEditColor = MudBlazor.Color.Success;
                return;
            }

            if (AutographStep == AutographStep.Authentication)
            {
                AutographEditAlertSeverity = MudBlazor.Severity.Success;
                AutographEditColor = MudBlazor.Color.Success;
                AutographInscriptionEditAlertSeverity = MudBlazor.Severity.Success;
                AutographInscriptionEditColor = MudBlazor.Color.Success;                
                return;
            }

            if (DisplaySpot && AutographStep == AutographStep.Spot)
            {
                AutographAuthenticationEditAlertSeverity = MudBlazor.Severity.Success;
                AutographAuthenticationEditColor = MudBlazor.Color.Success;
                AutographEditAlertSeverity = MudBlazor.Severity.Success;
                AutographEditColor = MudBlazor.Color.Success;
                AutographInscriptionEditAlertSeverity = MudBlazor.Severity.Success;
                AutographInscriptionEditColor = MudBlazor.Color.Success;                
                return;
            }

            if (AutographStep == AutographStep.Image)
            {
                AutographAuthenticationEditAlertSeverity = MudBlazor.Severity.Success;
                AutographAuthenticationEditColor = MudBlazor.Color.Success;
                AutographEditAlertSeverity = MudBlazor.Severity.Success;
                AutographEditColor = MudBlazor.Color.Success;
                AutographInscriptionEditAlertSeverity = MudBlazor.Severity.Success;
                AutographInscriptionEditColor = MudBlazor.Color.Success;

                if (DisplaySpot)
                {
                    AutographSpotEditAlertSeverity = MudBlazor.Severity.Success;
                    AutographSpotEditColor = MudBlazor.Color.Success;
                }

                return;
            }
        }

        private string GetMudAlertStyle(AutographStep autographStep)
        {
            return AutographStep == autographStep ? "border: 1px solid black;" : string.Empty;
        }

        private void Navigate(string item = null)
        {
            if (AutographId == 0)
                return;

            if (item.IsNullOrEmpty())
            {
                NavigationManager.NavigateTo($"Autographs/Edit/{MemorabiliaId}/{AutographId}");
                return;
            }

            NavigationManager.NavigateTo($"Autographs/{item}/Edit/{AutographId}");
        }
    }
}
