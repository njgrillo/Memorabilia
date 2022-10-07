using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class CostChartViewModel : DashboardItemViewModel
{
    public CostChartViewModel() { }

    public CostChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var memorabiliaCostTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Acquisition?.Cost ?? 0);
        var autographsCostTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Autographs.Select(autograph => autograph.Acquisition?.Cost ?? 0).Sum());

        Labels = new List<string>() { "Memorabilia", "Autographs" }.ToArray();
        DataNew = new List<double>() { (double)memorabiliaCostTotal, (double)autographsCostTotal }.ToArray();
    }
}
