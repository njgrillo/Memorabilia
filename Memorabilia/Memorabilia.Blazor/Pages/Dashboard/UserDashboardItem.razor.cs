namespace Memorabilia.Blazor.Pages.Dashboard;

public partial class UserDashboardItem
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public string Title { get; set; }
}
