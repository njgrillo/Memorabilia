namespace Memorabilia.Blazor.Pages.Dashboard;

public class DashboardChartItem : ComponentBase
{
    [Parameter]
    public DashboardItem DashboardItem { get; set; }

    [Parameter]
    public double[] Data { get; set; }

    [Parameter]
    public string[] Labels { get; set; }
}
