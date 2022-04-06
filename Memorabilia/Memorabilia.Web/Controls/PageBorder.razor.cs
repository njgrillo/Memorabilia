using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class PageBorder : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
