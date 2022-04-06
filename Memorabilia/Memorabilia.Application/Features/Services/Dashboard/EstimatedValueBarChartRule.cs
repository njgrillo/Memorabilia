using Memorabilia.Application.Features.User.Dashboard;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;

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
