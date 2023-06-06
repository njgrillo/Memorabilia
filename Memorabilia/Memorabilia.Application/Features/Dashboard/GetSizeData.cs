namespace Memorabilia.Application.Features.Dashboard;

public record GetSizeData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetSizeData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetSizeData query)
        {
            var sizeIds = _repository.GetSizeIds(query.UserId);
            var sizeNames = sizeIds.Select(sizeId => Constant.Size.Find(sizeId).Name)
                                   .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var sizeName in sizeNames)
            {
                var size = Constant.Size.Find(sizeName);
                var count = sizeIds.Count(sizeId => sizeId == size.Id);

                counts.Add(count);
                labels.Add($"{sizeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
