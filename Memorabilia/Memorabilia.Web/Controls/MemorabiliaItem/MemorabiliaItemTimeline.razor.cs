using Framework.Extension;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.MemorabiliaItem
{
    public partial class MemorabiliaItemTimeline : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EditModeType EditMode { get; set; } = EditModeType.Add;

        [Parameter]
        public string ItemTypeName { get; set; }

        [Parameter]
        public MudBlazor.Severity MemorabiliaEditDetailAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string MemorabiliaEditDetailAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color MemorabiliaEditDetailColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity MemorabiliaEditImageAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string MemorabiliaEditImageAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color MemorabiliaEditImageColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Severity MemorabiliaEditItemAlertSeverity { get; set; } = MudBlazor.Severity.Info;

        [Parameter]
        public string MemorabiliaEditItemAlertTitle { get; set; }

        [Parameter]
        public MudBlazor.Color MemorabiliaEditItemColor { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Parameter]
        public MemorabiliaItemStep MemorabiliaItemStep { get; set; }

        private string _mudAlertClass;

        protected override void OnInitialized()
        {
            _mudAlertClass = MemorabiliaId > 0 ? "can-click" : string.Empty;

            MemorabiliaEditDetailAlertTitle = MemorabiliaItemStep.Detail.Name;
            MemorabiliaEditImageAlertTitle = MemorabiliaItemStep.Image.Name;
            MemorabiliaEditItemAlertTitle = MemorabiliaItemStep.Item.Name;

            if (MemorabiliaItemStep == MemorabiliaItemStep.Detail)
            {
                MemorabiliaEditItemAlertSeverity = MudBlazor.Severity.Success;
                MemorabiliaEditItemColor = MudBlazor.Color.Success;
                return;
            }

            if (MemorabiliaItemStep == MemorabiliaItemStep.Image)
            {
                MemorabiliaEditDetailAlertSeverity = MudBlazor.Severity.Success;
                MemorabiliaEditDetailColor = MudBlazor.Color.Success;
                MemorabiliaEditItemAlertSeverity = MudBlazor.Severity.Success;
                MemorabiliaEditItemColor = MudBlazor.Color.Success;
                return;
            }
        }

        private string GetMudAlertStyle(MemorabiliaItemStep memorabiliaItemStep)
        {
            return MemorabiliaItemStep == memorabiliaItemStep ? "border: 1px solid black;" : string.Empty;
        }

        private void Navigate(string item = null)
        {
            if (MemorabiliaId == 0)
                return;

            if (item.IsNullOrEmpty())
            {
                NavigationManager.NavigateTo($"Memorabilia/Edit/{MemorabiliaId}");
                return;
            }

            NavigationManager.NavigateTo($"Memorabilia/{item}/Edit/{MemorabiliaId}");
        }
    }
}
