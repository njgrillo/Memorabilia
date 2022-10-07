using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class CostBarChartViewModel : DashboardItemViewModel
{
    public CostBarChartViewModel() { }

    public CostBarChartViewModel(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = DashboardItem.CostBarChart;

        var memorabiliaCostTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Acquisition?.Cost ?? 0);
        var autographsCostTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Autographs.Select(autograph => autograph.Acquisition?.Cost ?? 0).Sum());
        var totalCost = memorabiliaCostTotal + autographsCostTotal;
        var itemTypes = memorabiliaItems.Select(item => item.ItemType);
        var data = new List<List<object>>();
        var objectList = new List<object>();
        var distinctItemTypeNames = itemTypes.Select(itemType => itemType.Name).Distinct();

        objectList = new List<object>
        {
            string.Empty,
            "Cost ($)"
        };

        data.Add(objectList);

        objectList = new List<object>
        {
            "Memorabilia",
            memorabiliaCostTotal
        };

        data.Add(objectList);

        objectList = new List<object>
        {
            "Autographs",
            autographsCostTotal
        };

        data.Add(objectList);

        objectList = new List<object>
        {
            "Total",
            totalCost
        };

        data.Add(objectList);

        Data = data;
    }
}
