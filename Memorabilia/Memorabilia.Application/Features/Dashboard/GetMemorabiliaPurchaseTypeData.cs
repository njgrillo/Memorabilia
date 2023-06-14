namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaPurchaseTypeData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetMemorabiliaPurchaseTypeData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaPurchaseTypeData query)
        {
            int[] purchaseTypeIds = _repository.GetPurchaseTypeIds(_applicationStateService.CurrentUser.Id);
            string[] purchaseTypeNames = purchaseTypeIds.Select(purchaseTypeId => Constant.PurchaseType.Find(purchaseTypeId).Name)
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
