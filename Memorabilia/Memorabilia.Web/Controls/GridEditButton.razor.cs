using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class GridEditButton : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string NavigationPath { get; set; }
    }
}
