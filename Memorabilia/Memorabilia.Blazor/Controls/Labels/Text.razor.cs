﻿namespace Memorabilia.Blazor.Controls.Labels;

public partial class Text : ThemedControl
{
    [Parameter]
    public string Content { get; set; }

    private string _style;

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
        _style = ApplicationStateService.IsDarkMode
            ? "color:white;"
            : string.Empty;

        StateHasChanged();
    }
}
