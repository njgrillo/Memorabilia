namespace Memorabilia.Blazor.Controls.Panels;

public partial class ExpansionPanel
{
    [Parameter]
    public bool CanExpand { get; set; }
        = true;

    [Parameter]
    public RenderFragment ChildContent { get; set; }    

    [Parameter]
    public bool Expanded { get; set; }
        = true;

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
