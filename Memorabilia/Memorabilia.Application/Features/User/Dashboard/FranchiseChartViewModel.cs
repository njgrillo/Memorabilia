using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class FranchiseChartViewModel : DashboardItemViewModel
{
    public FranchiseChartViewModel() { }

    public FranchiseChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var franchises = memorabiliaItems.SelectMany(item => item.Teams.Select(team => team.Team.Franchise));
        var franchiseNames = franchises.Select(franchise => franchise.Name).Distinct();

        Labels = franchiseNames.ToArray();

        var counts = new List<double>();

        foreach (var franchiseName in franchiseNames)
        {
            counts.Add(franchises.Count(franchise => franchise.Name == franchiseName));
        }

        DataNew = counts.ToArray();
    }
}
