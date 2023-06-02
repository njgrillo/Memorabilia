namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectStatus
{
    [Parameter]
    public int CompletedCount { get; set; }

    [Parameter]
    public int InProgressCount { get; set; }

    [Parameter]
    public int NotStartedCount { get; set; }
}
