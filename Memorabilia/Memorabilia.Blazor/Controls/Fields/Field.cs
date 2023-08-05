namespace Memorabilia.Blazor.Controls.Fields;

public abstract class Field : ThemedControl
{
    [Parameter]
    public bool DisplaySkeleton { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public Variant Variant { get; set; }
        = Variant.Outlined;

    protected string Theme { get; set; }

    protected override void OnInitialized()
    {
        SetTheme();

        base.OnInitialized();
    }

    public override void OnThemeChanged()
    {
        SetTheme();
    }

    private void SetTheme()
    {
        Theme = ApplicationStateService.IsDarkMode
            ? "color:white;"
            : string.Empty;

        Variant = ApplicationStateService.IsDarkMode
            ? Variant.Filled
            : Variant.Outlined;

        StateHasChanged();
    }
}
