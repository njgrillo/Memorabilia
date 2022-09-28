#nullable disable

namespace Memorabilia.Blazor.Controls
{
    public partial class PageFooter : ComponentBase
    {
        [Parameter]
        public string NavigationPath { get; set; }

        [Parameter]
        public string NavigationPathText { get; set; } = "Back";
    }
}
