namespace Memorabilia.Application.Features.Dashboard;

public record GetBrandData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetBrandData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetBrandData query)
        {
            int[] brandIds = _repository.GetBrandIds(_applicationStateService.CurrentUser.Id);
            string[] brandNames = brandIds.Select(brandId => Constant.Brand.Find(brandId).Name)
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
