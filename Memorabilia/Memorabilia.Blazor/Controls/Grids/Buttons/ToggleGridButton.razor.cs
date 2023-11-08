namespace Memorabilia.Blazor.Controls.Grids.Buttons;

public partial class ToggleGridButton
{
    [Parameter]
    public EventCallback Collapsed { get; set; }

    [Parameter]
    public EventCallback Expanded { get; set; }

    [Parameter]
    public EventCallback Toggled { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    private bool _expanded;

    private string _icon
        = Icons.Material.Filled.ExpandMore;

    public async Task Clicked()
    {
        _expanded = !_expanded;
        _icon =
            _icon == Icons.Material.Filled.ExpandMore
                  ? Icons.Material.Filled.ExpandLess
                  : Icons.Material.Filled.ExpandMore;

        if (_expanded)
        {
            await Expanded.InvokeAsync();
        }
        else
        {
            await Collapsed.InvokeAsync();
        }

        await Toggled.InvokeAsync();
    }
}
