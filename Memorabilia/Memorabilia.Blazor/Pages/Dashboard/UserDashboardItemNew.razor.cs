namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class UserDashboardItemNew
{
    [Parameter]
    public RenderFragment Content { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public string Title { get; set; }
}
