using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaPurchaseTypeData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetMemorabiliaPurchaseTypeData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaPurchaseTypeData query)
        {
            int[] purchaseTypeIds 
                = repository.GetPurchaseTypeIds(applicationStateService.CurrentUser.Id);

            string[] purchaseTypeNames 
                = purchaseTypeIds.Select(purchaseTypeId => Constant.PurchaseType.Find(purchaseTypeId).Name)
                                 .Distinct()
                                 .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string purchaseTypeName in purchaseTypeNames)
            {
                var purchaseType = Constant.PurchaseType.Find(purchaseTypeName);
                int count = purchaseTypeIds.Count(purchaseTypeId => purchaseTypeId == purchaseType.Id);

                counts.Add(count);
                labels.Add($"{purchaseTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
