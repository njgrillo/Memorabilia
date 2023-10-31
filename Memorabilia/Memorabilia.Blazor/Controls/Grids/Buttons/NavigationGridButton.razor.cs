namespace Memorabilia.Blazor.Controls.Grids.Buttons;

public partial class NavigationGridButton
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Color Color { get; set; }
        = Color.Primary;

    [Parameter]
    public string NavigationPath { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; }
        = Icons.Material.Outlined.ModeEditOutline;

    [Parameter]
    public string TooltipText { get; set; }
        = "Edit";
}
