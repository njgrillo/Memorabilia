namespace Memorabilia.Blazor.Controls.Panels;

public partial class ExpansionPanels
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool MultiExpansion { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
