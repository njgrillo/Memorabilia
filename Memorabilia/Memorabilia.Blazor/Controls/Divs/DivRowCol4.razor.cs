namespace Memorabilia.Blazor.Controls.Divs;

public partial class DivRowCol4 : ComponentBase
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public RenderFragment ContentColumn2 { get; set; }

    [Parameter]
    public RenderFragment ContentColumn3 { get; set; }

    [Parameter]
    public bool Hidden { get; set; }

    [Parameter]
    public string LeftPadding { get; set; }
}
