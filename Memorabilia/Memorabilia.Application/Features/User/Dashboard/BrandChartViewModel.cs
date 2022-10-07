using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard;

public class BrandChartViewModel : DashboardItemViewModel
{
    public BrandChartViewModel() { }

    public BrandChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        DashboardItem = dashboardItem;

        var brands = memorabiliaItems.Where(item => item.Brand?.BrandId > 0).Select(item => item.Brand);
        var brandNames = brands.Select(brand => Brand.Find(brand.BrandId).Name).Distinct();

        Labels = brandNames.ToArray();

        var counts = new List<double>();

        foreach (var brandName in brandNames)
        {
            counts.Add(brands.Count(brand => brand.BrandId == Brand.Find(brandName).Id));
        }

        DataNew = counts.ToArray();
    }
}
