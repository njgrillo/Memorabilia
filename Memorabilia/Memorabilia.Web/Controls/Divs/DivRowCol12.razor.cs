using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Divs
{
    public partial class DivRowCol12 : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
