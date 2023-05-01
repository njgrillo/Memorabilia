namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaPurchaseTypeData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaPurchaseTypeData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetMemorabiliaPurchaseTypeData query)
        {
            var purchaseTypeIds = _repository.GetPurchaseTypeIds(query.UserId);
            var purchaseTypeNames = purchaseTypeIds.Select(purchaseTypeId => Domain.Constants.PurchaseType.Find(purchaseTypeId).Name)
                                                   .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var purchaseTypeName in purchaseTypeNames)
            {
                var purchaseType = Domain.Constants.PurchaseType.Find(purchaseTypeName);
                var count = purchaseTypeIds.Count(purchaseTypeId => purchaseTypeId == purchaseType.Id);

                counts.Add(count);
                labels.Add($"{purchaseTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
