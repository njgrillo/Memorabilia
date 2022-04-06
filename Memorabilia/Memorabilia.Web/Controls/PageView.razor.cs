using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls
{
    public partial class PageView : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }    

        [Parameter]
        public string AddRoute { get; set; }

        [Parameter]
        public string AddTitle { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public bool DisplayAddButton { get; set; } = true;

        [Parameter]
        public bool DisplayPageHeader { get; set; } = true;   

        [Parameter]
        public string NavigationPath { get; set; }

        [Parameter]
        public string NavigationPathText { get; set; } = "Back";

        [Parameter]
        public EventCallback OnLoad { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        public async Task Load()
        {
            await OnLoad.InvokeAsync().ConfigureAwait(false);
        }
    }
}
