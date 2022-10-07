using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public class CostBarChartRule : IDashboardItemRule
{
    public bool Applies(DashboardItem dashboardItem)
    {
        return dashboardItem == DashboardItem.CostBarChart;
    }

    public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        return new CostBarChartViewModel(memorabiliaItems);
    }
}
