namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaPurchaseTypeData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetMemorabiliaPurchaseTypeData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaPurchaseTypeData query)
        {
            int[] purchaseTypeIds = _repository.GetPurchaseTypeIds(query.UserId);
            string[] purchaseTypeNames = purchaseTypeIds.Select(purchaseTypeId => Constant.PurchaseType.Find(purchaseTypeId).Name)
                                                        .Distinct()
                                                        .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string purchaseTypeName in purchaseTypeNames)
            {
                var purchaseType = Constant.PurchaseType.Find(purchaseTypeName);
                var count = purchaseTypeIds.Count(purchaseTypeId => purchaseTypeId == purchaseType.Id);

                counts.Add(count);
                labels.Add($"{purchaseTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
