using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetBrandData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetBrandData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetBrandData query)
        {
            int[] brandIds 
                = repository.GetBrandIds(applicationStateService.CurrentUser.Id);

            string[] brandNames 
                = brandIds.Select(brandId => Constant.Brand.Find(brandId).Name)
                          .Distinct()
                          .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string brandName in brandNames)
            {
                var brand = Constant.Brand.Find(brandName);
                var count = brandIds.Count(brandId => brandId == brand.Id);

                counts.Add(count);
                labels.Add($"{brandName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
