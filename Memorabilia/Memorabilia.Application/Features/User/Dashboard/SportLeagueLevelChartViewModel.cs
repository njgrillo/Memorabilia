using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class SportLeagueLevelChartViewModel : DashboardItemViewModel
{
    public SportLeagueLevelChartViewModel() { }

    public SportLeagueLevelChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var sportLeagueLevels = memorabiliaItems.SelectMany(item => item.Teams.Select(team => team.Team.Franchise.SportLeagueLevel));
        var sportLeagueLevelNames = sportLeagueLevels.Select(sportLeagueLevel => sportLeagueLevel.Name).Distinct();

        Labels = sportLeagueLevelNames.ToArray();

        var counts = new List<double>();

        foreach (var sportLeagueLevelName in sportLeagueLevelNames)
        {
            counts.Add(sportLeagueLevels.Count(sportLeagueLevel => sportLeagueLevel.Name == sportLeagueLevelName));
        }

        DataNew = counts.ToArray();
    }
}
