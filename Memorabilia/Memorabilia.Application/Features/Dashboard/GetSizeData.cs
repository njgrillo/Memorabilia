namespace Memorabilia.Application.Features.Dashboard;

public record GetSizeData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetSizeData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetSizeData query)
        {
            var sizeIds = _repository.GetSizeIds(query.UserId);
            var sizeNames = sizeIds.Select(sizeId => Domain.Constants.Size.Find(sizeId).Name)
                                   .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var sizeName in sizeNames)
            {
                var size = Domain.Constants.Size.Find(sizeName);
                var count = sizeIds.Count(sizeId => sizeId == size.Id);

                counts.Add(count);
                labels.Add($"{sizeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
