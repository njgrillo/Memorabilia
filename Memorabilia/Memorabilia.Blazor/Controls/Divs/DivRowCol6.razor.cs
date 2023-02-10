using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Memorabilia.Blazor.Controls.Divs;

public partial class DivRowCol6 : ComponentBase
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public RenderFragment ContentColumn2 { get; set; }

    [Parameter]
    public string Column1Style { get; set; }

    [Parameter]
    public string Column2Style { get; set; }

    [Parameter]
    public bool Hidden { get; set; }

    [Parameter]
    public string LeftPadding { get; set; }
}
