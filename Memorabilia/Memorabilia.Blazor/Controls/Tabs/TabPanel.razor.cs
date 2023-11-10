namespace Memorabilia.Blazor.Controls.Tabs;

public partial class TabPanel
{  
    [Parameter]
    public Color BadgeColor { get; set; }

    [Parameter]
    public object BadgeData { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public bool DisplayBadge { get; set; }

    [Parameter]
    public bool Expanded { get; set; }
        = true;

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
