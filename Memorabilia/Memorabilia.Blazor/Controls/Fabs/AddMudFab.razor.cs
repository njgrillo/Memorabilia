namespace Memorabilia.Blazor.Controls.Fabs;

public partial class AddMudFab
{
    [Parameter]
    public Color Color { get; set; }
        = Color.Primary;

    [Parameter]
    public EventCallback OnAdd { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }

    [Parameter]
    public string StartIcon { get; set; }
        = Icons.Material.Outlined.AddCircleOutline;

    [Parameter]
    public string TooltipText { get; set; }
        = "Add";

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task ButtonClicked()
    {
        await OnAdd.InvokeAsync();
    }
}
