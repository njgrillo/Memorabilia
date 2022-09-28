using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class EstimatedValueBarChartRule : IDashboardItemRule
    {
        public bool Applies(DashboardItem dashboardItem)
        {
            return dashboardItem == DashboardItem.EstimatedValueBarChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new EstimatedValueBarChartViewModel(memorabiliaItems);
        }
    }
}
