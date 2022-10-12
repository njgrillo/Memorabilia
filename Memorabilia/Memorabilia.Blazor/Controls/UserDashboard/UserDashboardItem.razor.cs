#nullable disable

namespace Memorabilia.Blazor.Controls.UserDashboard;

public partial class UserDashboardItem : ComponentBase
{
    [Parameter]
    public double[] Data { get; set; }

    [Parameter]
    public DashboardItem DashboardItem { get; set; }

    [Parameter]
    public string[] Labels { get; set; }
}
