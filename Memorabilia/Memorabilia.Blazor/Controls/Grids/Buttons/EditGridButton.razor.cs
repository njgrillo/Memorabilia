namespace Memorabilia.Blazor.Controls.Grids.Buttons;

public partial class EditGridButton
{
    [Parameter]
    public Color Color { get; set; }
        = Color.Primary;

    [Parameter]
    public EventCallback OnEdit { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; }
        = Icons.Material.Outlined.ModeEditOutline;

    [Parameter]
    public string TooltipText { get; set; }
        = "Edit";

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task ButtonClicked()
    {
        await OnEdit.InvokeAsync();
    }
}
