using Memorabilia.Application.Features.User.Dashboard;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Services.Dashboard
{
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
}
