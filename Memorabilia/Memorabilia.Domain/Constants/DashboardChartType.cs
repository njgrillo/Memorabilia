namespace Memorabilia.Domain.Constants;

public sealed class DashboardChartType : DomainItemConstant
{
    public static readonly DashboardChartType Bar = new (3, "Bar");
    public static readonly DashboardChartType Donut = new (4, "Donut");
    public static readonly DashboardChartType Pie = new (1, "Pie");
    public static readonly DashboardChartType StackedColumn = new (2, "Stacked Column");

    private DashboardChartType(int id, string name) 
        : base(id, name) { }

    public static readonly DashboardChartType[] All =
    [
        Bar,
        Donut,
        Pie,
        StackedColumn
    ];

    public static DashboardChartType Find(int id)
        => All.SingleOrDefault(dashboardChartType => dashboardChartType.Id == id);
}
