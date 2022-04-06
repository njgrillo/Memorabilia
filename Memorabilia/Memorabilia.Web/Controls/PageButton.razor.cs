using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class PageButton : ComponentBase
    {
        [Parameter]
        public string ButtonText { get; set; } = "Save";

        [Parameter]
        public MudBlazor.ButtonType ButtonType { get; set; } = MudBlazor.ButtonType.Submit;

        [Parameter]
        public MudBlazor.Color Color { get; set; } = MudBlazor.Color.Info;

        [Parameter]
        public MudBlazor.Size Size { get; set; } = MudBlazor.Size.Medium;

        [Parameter]
        public string StartIcon { get; set; } = MudBlazor.Icons.Material.Filled.Save;

        [Parameter]
        public MudBlazor.Variant Variant { get; set; } = MudBlazor.Variant.Filled;
    }
}
