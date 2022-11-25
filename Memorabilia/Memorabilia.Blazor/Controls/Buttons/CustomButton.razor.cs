namespace Memorabilia.Blazor.Controls.Buttons;

public partial class CustomButton : ComponentBase
{
    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Submit;

    [Parameter]
    public Color Color { get; set; } = Color.Info;

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; } = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; } = string.Empty;

    [Parameter]
    public string Text { get; set; } = string.Empty;

    [Parameter]
    public Variant Variant { get; set; } = Variant.Filled;
}
