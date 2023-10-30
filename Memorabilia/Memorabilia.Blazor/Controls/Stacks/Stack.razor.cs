namespace Memorabilia.Blazor.Controls.Stacks;

public partial class Stack
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public bool IsRow { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
