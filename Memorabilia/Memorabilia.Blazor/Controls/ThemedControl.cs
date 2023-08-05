namespace Memorabilia.Blazor.Controls;

public abstract class ThemedControl : ComponentBase
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    public abstract void OnThemeChanged();

    protected override void OnInitialized()
    {
        Courier.Subscribe<ThemeChangedNotification>(OnThemeChanged);
    }

    private void OnThemeChanged(ThemeChangedNotification notification)
        => OnThemeChanged();
}
