using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class PageFooter : ComponentBase
    {
        [Parameter]
        public string NavigationPath { get; set; }

        [Parameter]
        public string NavigationPathText { get; set; } = "Back";
    }
}
