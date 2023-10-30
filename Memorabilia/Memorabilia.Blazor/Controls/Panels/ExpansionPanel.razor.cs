namespace Memorabilia.Blazor.Controls.Panels;

public partial class ExpansionPanel
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }    

    [Parameter]
    public bool Expanded { get; set; }
        = true;

    [Parameter]
    public string Text { get; set; }
}
