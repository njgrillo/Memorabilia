﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class SpotChartRule : DashboardItemRule, IDashboardItemRule
    {
        public override DashboardItem DashboardItem { get; set; }

        public bool Applies(DashboardItem dashboardItem)
        {
            DashboardItem = dashboardItem;

            return dashboardItem == DashboardItem.SpotDonutChart ||
                   dashboardItem == DashboardItem.SpotPieChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new SpotChartViewModel(DashboardItem, memorabiliaItems);
        }
    }
}
