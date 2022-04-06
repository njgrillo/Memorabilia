using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls.Divs
{
    public partial class DivPad2 : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
