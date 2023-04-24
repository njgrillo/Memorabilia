

namespace Memorabilia.Blazor.Controls.Divs;

public partial class DivRowCol12 : ComponentBase
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public bool Hidden { get; set; }
}
