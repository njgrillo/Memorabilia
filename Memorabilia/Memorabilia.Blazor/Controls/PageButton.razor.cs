#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class PageButton : ComponentBase
{
    [Parameter]
    public string ButtonText { get; set; } = "Save";

    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Submit;

    [Parameter]
    public Color Color { get; set; } = Color.Info;

    [Parameter]
    public MudBlazor.Size Size { get; set; } = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; } = Icons.Material.Filled.Save;

    [Parameter]
    public Variant Variant { get; set; } = Variant.Filled;
}
