namespace Memorabilia.Application.Features.Dashboard;

public class DashboardItemModel
{
    public DashboardItemModel() { }

    public Constant.DashboardItem DashboardItem { get; set; }

    public List<List<object>> Data { get; set; }

    public double[] DataNew { get; set; }

    public string[] Labels { get; set; }
}
