using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class SizeChartViewModel : DashboardItemViewModel
{
    public SizeChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var sizes = memorabiliaItems.Select(item => item.Size);
        var sizeNames = sizes.Select(size => Size.Find(size.SizeId).Name).Distinct();

        Labels = sizeNames.ToArray();

        var counts = new List<double>();

        foreach (var sizeName in sizeNames)
        {
            counts.Add(sizes.Count(size => size.SizeId == Size.Find(sizeName).Id));
        }

        DataNew = counts.ToArray();
    }
}
