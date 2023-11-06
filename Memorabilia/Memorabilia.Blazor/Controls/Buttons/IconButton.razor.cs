namespace Memorabilia.Blazor.Controls.Buttons;

public partial class IconButton
{
    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public Edge Edge { get; set; }

    [Parameter]
    public string Icon { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task Click()
    {
        await OnClick.InvokeAsync();
    }
}
