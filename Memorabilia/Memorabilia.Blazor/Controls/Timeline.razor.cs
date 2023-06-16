namespace Memorabilia.Blazor.Controls;

public partial class Timeline
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public TimelineOrientation Orientation { get; set; } 
        = TimelineOrientation.Horizontal;

    [Parameter]
    public TimelinePosition Position { get; set; } 
        = TimelinePosition.Top;
}
