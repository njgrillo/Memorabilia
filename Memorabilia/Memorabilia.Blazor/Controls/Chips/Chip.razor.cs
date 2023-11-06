namespace Memorabilia.Blazor.Controls.Chips;

public partial class Chip
{
    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string Text { get; set; }

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
