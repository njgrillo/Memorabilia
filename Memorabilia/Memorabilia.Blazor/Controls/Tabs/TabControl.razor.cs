namespace Memorabilia.Blazor.Controls.Tabs;

public partial class TabControl
{
    [Parameter]
    public bool Centered { get; set; }
        = true;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public Color Color { get; set; }
}
