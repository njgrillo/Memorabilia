namespace Memorabilia.Blazor.Controls.Grids.Toolbar;

public partial class ToolbarSearchField
{
    [Parameter]
    public Adornment Adornment { get; set; }
        = Adornment.Start;

    [Parameter]
    public string AdornmentIcon { get; set; }
        = Icons.Material.Filled.Search;

    [Parameter]
    public string Class { get; set; }
        = "mt-0";

    [Parameter]
    public MudBlazor.Size IconSize { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string Placeholder { get; set; }
        = "Search";

    [Parameter]
    public string SearchText { get; set; }

    [Parameter]
    public EventCallback<string> SearchTextChanged { get; set; }
}
