using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class MemorabiliaConditionChartViewModel : DashboardItemViewModel
{
    public MemorabiliaConditionChartViewModel() { }

    public MemorabiliaConditionChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var conditions = memorabiliaItems.Select(item => item.Condition);
        var conditionNames = conditions.Select(condition => condition.Name).Distinct();

        Labels = conditionNames.ToArray();

        var counts = new List<double>();

        foreach (var conditionName in conditionNames)
        {
            counts.Add(conditions.Count(condition => condition.Name == conditionName));
        }

        DataNew = counts.ToArray();
    }
}
