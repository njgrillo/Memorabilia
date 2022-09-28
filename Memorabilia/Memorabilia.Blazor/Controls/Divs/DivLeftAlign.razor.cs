#nullable disable

namespace Memorabilia.Blazor.Controls.Divs
{
    public partial class DivLeftAlign : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public bool Hidden { get; set; }
    }
}
