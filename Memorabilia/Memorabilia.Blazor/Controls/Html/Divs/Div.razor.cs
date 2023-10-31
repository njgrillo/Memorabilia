namespace Memorabilia.Blazor.Controls.Html.Divs;

public partial class Div
{
    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool Hidden { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> KeyDown { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    private async void OnKeyDown(KeyboardEventArgs e)
    {
        await KeyDown.InvokeAsync(e);
    }
}
