namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectPriority
{
    [Parameter]
    public int MustHaveCount { get; set; }

    [Parameter]
    public int NiceToHaveCount { get; set; }

    [Parameter]
    public int NoWayCount { get; set; }

    [Parameter]
    public int TakeItOrLeaveItCount { get; set; }

    [Parameter]
    public int WatchingCount { get; set; }
}
