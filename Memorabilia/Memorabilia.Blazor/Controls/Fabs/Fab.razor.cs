namespace Memorabilia.Blazor.Controls.Fabs;

public partial class Fab
{
    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task FabClicked()
    {
        await OnClick.InvokeAsync();
    }
}
