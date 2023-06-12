namespace Memorabilia.Application.Features.Dashboard;

public record GetBrandData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetBrandData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetBrandData query)
        {
            int[] brandIds = _repository.GetBrandIds(query.UserId);
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
