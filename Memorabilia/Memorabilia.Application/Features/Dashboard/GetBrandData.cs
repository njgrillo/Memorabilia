namespace Memorabilia.Application.Features.Dashboard;

public record GetBrandData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetBrandData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetBrandData query)
        {
            var brandIds = _repository.GetBrandIds(query.UserId);
            var brandNames = brandIds.Select(brandId => Domain.Constants.Brand.Find(brandId).Name)
                                     .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var brandName in brandNames)
            {
                var brand = Domain.Constants.Brand.Find(brandName);
                var count = brandIds.Count(brandId => brandId == brand.Id);

                counts.Add(count);
                labels.Add($"{brandName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
