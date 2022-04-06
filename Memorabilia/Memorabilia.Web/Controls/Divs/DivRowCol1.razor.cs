using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Divs
{
    public partial class DivRowCol1 : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment ContentColumn2 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn3 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn4 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn5 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn6 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn7 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn8 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn9 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn10 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn11 { get; set; }

        [Parameter]
        public RenderFragment ContentColumn12 { get; set; }

        [Parameter]
        public bool Hidden { get; set; }

        [Parameter]
        public string LeftPadding { get; set; }
    }
}
